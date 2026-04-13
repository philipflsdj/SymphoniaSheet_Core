

using SS.Application.Configurations.Notificacoes;

namespace SS.Application.Configurations.Interfaces
{
    public interface INotificationHandler
    {
        bool HasNotifications();
        IReadOnlyCollection<AppNotification> GetNotifications();
    }
}
