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
}