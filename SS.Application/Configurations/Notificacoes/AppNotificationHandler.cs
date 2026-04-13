using MediatR;
using SS.Application.Configurations.Interfaces;

namespace SS.Application.Configurations.Notificacoes
{
    public class AppNotificationHandler : INotificationHandler<AppNotification>, INotificationHandler
    {
        private readonly List<AppNotification> _notifications = new();

        public Task Handle(AppNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public bool HasNotifications() => _notifications.Any();

        public IReadOnlyCollection<AppNotification> GetNotifications() => _notifications.AsReadOnly();
    }
}
