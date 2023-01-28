using Amazon.SimpleNotificationService.Model;

namespace Example.Api.Messaging;

public interface ISnsMessenger
{
    Task<PublishResponse> PublishMessageAsync<T>(T message);
}