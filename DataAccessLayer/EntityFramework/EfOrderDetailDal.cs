using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfOrderDetailDal : GenericRepository<OrderDetail> , IOrderDetailDal
{
    public EfOrderDetailDal(SignalRContext context) : base(context)
    {
    }
}