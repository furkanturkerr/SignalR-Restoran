using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfBookingDal : GenericRepository<Booking>, IBookingDal
{
    public EfBookingDal(SignalRContext context) : base(context)
    {
    }

    public void BookingStatusApprove(int id)
    {
        using var context = new SignalRContext();
        var value = context.Bookings.Find(id);
        value.Description = "Rezervasyon Onaylandı";
        context.SaveChanges();
    }

    public void BookingStatusReject(int id)
    {
        using var context = new SignalRContext();
        var value = context.Bookings.Find(id);
        value.Description = "Rezervasyon İptal Edildi";
        context.SaveChanges();
    }
}