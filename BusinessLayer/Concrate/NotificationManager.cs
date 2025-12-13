using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrate;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;
    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }
    public void TAdd(Notification entity)
    {
        _notificationDal.Add(entity);
    }

    public void TUpdate(Notification entity)
    {
        _notificationDal.Update(entity);
    }

    public void TDelete(Notification entity)
    {
        _notificationDal.Delete(entity);
    }

    public List<Notification> TGetListAll()
    {
        return _notificationDal.GetListAll();
    }

    public Notification TGetById(int id)
    {
        return _notificationDal.GetById(id);
    }

    public int TNotificationCountByStatusFalse()
    {
        return _notificationDal.NotificationCountByStatusFalse();
    }

    public List<Notification> TGetAllNotificationsByFalse()
    {
        return _notificationDal.GetAllNotificationsByFalse();
    }

    public void TNotificationRead(int id)
    {
        _notificationDal.NotificationRead(id);
    }

    public void TNotNotificationRead(int id)
    {
        _notificationDal.NotNotificationRead(id);
    }
}