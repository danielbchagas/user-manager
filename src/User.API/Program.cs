using MassTransit;
using Microsoft.AspNetCore.Identity;
using User.API.Configurations;
using User.API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurations
builder.ConfigureIdentity();
builder.ConfigureEntityFramework();
builder.ConfigureMassTransit();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

app.MapPost("/publish", async (UserManager<IdentityUser> userManager, HttpContext httpContext, IPublishEndpoint publishEndpoint, Message message, CancellationToken stoppingToken) =>
{
    var user = await userManager.GetUserAsync(httpContext.User);
    
    if (user == null) return Results.Unauthorized();

    message.Update(user);
    
    await publishEndpoint.Publish(message, stoppingToken);
    return Results.Ok();
})
.RequireAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
