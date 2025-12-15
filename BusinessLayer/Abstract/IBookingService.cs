
using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface IBookingService : IGenericService<Booking>
{
    void TBookingStatusApprove(int id);
    void TBookingStatusReject(int id);
}