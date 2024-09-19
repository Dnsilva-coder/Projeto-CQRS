
namespace Eventos.IO.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler1
    {
        Task Handle(DomainNotification notification, CancellationToken cancellationToken);
    }
}