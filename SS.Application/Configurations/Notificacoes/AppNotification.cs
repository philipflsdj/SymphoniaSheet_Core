using MediatR;
using SS.Application.Configurations.Notificacoes;



namespace SS.Application.Configurations.Notificacoes
{
    public class AppNotification : INotification
    {
        public string Key { get; }
        public string Message { get; }

        public AppNotification(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
