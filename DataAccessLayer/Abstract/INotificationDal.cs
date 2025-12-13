using EntityLayer.Entities;

namespace DataAccessLayer.Abstract;

public interface INotificationDal : IGenericDal<Notification>
{
    int NotificationCountByStatusFalse();
    List<Notification> GetAllNotificationsByFalse();
    void NotificationRead(int id);
    void NotNotificationRead(int id);
}