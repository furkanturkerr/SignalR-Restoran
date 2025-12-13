using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationDal(SignalRContext context) : base(context)
    {
    }

    public int NotificationCountByStatusFalse()
    {
        using var context = new SignalRContext();
        return context.Notifications.Where(x => x.Status == false).Count();
    }

    public List<Notification> GetAllNotificationsByFalse()
    {
        using var context = new SignalRContext();
        return context.Notifications.Where(x => x.Status == false).ToList();
    }

    public void NotificationRead(int id)
    {
        using var context = new SignalRContext();
        var values = context.Notifications.Find(id);
        values.Status = true;
        context.SaveChanges();
    }

    public void NotNotificationRead(int id)
    {
        using var context = new SignalRContext();
        var values = context.Notifications.Find(id);
        values.Status = false;
        context.SaveChanges();
    }
}