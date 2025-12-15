
using EntityLayer.Entities;

namespace DataAccessLayer.Abstract;

public interface IBookingDal : IGenericDal<Booking>
{
    void BookingStatusApprove(int id);
    void BookingStatusReject(int id);
}