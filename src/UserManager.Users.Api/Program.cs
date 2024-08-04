using MassTransit;
using Microsoft.AspNetCore.Identity;
using UserManager.Users.Api.Configurations;
using UserManager.Users.Api.Entities;
using UserManager.Users.Api.Infrastructure.Services;
using UserManager.BuildingBlocks;

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

app.MapPost("/publish", async (UserManager<IdentityUser> userManager, HttpContext httpContext, IMessageSender messageSender) =>
{
    var user = await userManager.GetUserAsync(httpContext.User);
    
    if (user == null) return Results.Unauthorized();

    var message = new Message(user.Id, user.Email);
    var validation = message.IsValid();

    if (validation.status == false)
    {
        var response = new ApiReponse(validation.status, validation.messages);
        return Results.BadRequest(response);
    }
    
    await messageSender.SendMessageAsync(message);
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
