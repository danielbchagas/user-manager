using MassTransit;

namespace User.API.Configurations;

public static class MassTransitConfiguration
{
    public static void ConfigureMassTransit(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(bus =>
        {
            bus.UsingRabbitMq((ctx, busConfigurator) =>
            {
                busConfigurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));
            });
        });
    }
}