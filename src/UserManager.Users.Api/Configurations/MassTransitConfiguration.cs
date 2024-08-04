using MassTransit;
using MassTransit.Transports.Fabric;
using UserManager.Users.Api.Entities;
using UserManager.Users.Api.Infrastructure.Services;

namespace UserManager.Users.Api.Configurations;

public static class MassTransitConfiguration
{
    public static void ConfigureMassTransit(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(bus =>
        {
            bus.UsingRabbitMq((ctx, busConfigurator) =>
            {
                busConfigurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));
                
                busConfigurator.Publish<Message>(p =>
                {
                    p.ExchangeType = nameof(ExchangeType.Direct);
                    p.BindQueue("usermanager.users", "usermanager.users");
                });
            });
        });
        
        builder.Services.AddScoped<IMessageSender, MessageSender>();
    }
}