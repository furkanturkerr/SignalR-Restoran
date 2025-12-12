using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface INotificationService : IGenericService<Notification>
{
    int TNotificationCountByStatusFalse();
    List<Notification> TGetAllNotificationsByFalse();
}