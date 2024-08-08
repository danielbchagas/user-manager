using MassTransit;
using UserManager.Customers.Api.Infrastructure.Services;

namespace UserManager.Customers.Api.Configurations;

public static class MassTransitConfiguration
{
    public static void ConfigureMassTransit(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(bus =>
        {
            bus.UsingRabbitMq((ctx, busConfigurator) =>
            {
                busConfigurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));
                
                busConfigurator.ReceiveEndpoint("usermanager.users", ep =>
                {
                    ep.ConfigureConsumer<MessageConsumer>(ctx);
                });
            });
        });
        
        builder.Services.AddMassTransitHostedService();
        builder.Services.AddHostedService<MessageReceiver>();
    }
}