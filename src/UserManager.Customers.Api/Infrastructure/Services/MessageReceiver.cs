using MassTransit;
using UserManager.BuildingBlocks;

namespace UserManager.Customers.Api.Infrastructure.Services;

public class MessageReceiver(IBusControl busControl) : BackgroundService
{
    private readonly IBusControl _busControl = busControl;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return _busControl.StartAsync(stoppingToken);
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await _busControl.StopAsync(stoppingToken);
    }
}

public class MessageConsumer : IConsumer<Message>
{
    public Task Consume(ConsumeContext<Message> context)
    {
        return Task.CompletedTask;
    }
}
