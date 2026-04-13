using MediatR;
using SS.Application.Configurations.Notificacoes;

namespace SS.Application.Configurations.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublishNotificationAsync(AppNotification notification);
        Task<TResponse> SendCommandAsync<TResponse>(IRequest<TResponse> command);
    }
}
