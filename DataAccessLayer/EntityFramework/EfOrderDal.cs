using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfOrderDal : GenericRepository<Order> , IOrderDal
{
    public EfOrderDal(SignalRContext context) : base(context)
    {
    }

    public int TotalOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Count();
    }

    public int ActiveOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
    }

    public decimal LastOrderTotalPrice()
    {
        using var context = new SignalRContext();
        return context.Orders.OrderByDescending(x=>x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
    }
}