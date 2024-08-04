using MassTransit;
using UserManager.Users.Api.Entities;

namespace UserManager.Users.Api.Infrastructure.Services;

public interface IMessageSender
{
    Task SendMessageAsync(Message message);
}

public class MessageSender(ISendEndpointProvider sendEndpointProvider) : IMessageSender
{
    public async Task SendMessageAsync(Message message)
    {
        var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:usermanager.users"));

        await sendEndpoint.Send(message);
    }
}