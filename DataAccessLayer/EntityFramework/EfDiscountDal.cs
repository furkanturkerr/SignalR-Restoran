using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
{
    public EfDiscountDal(SignalRContext context) : base(context)
    {
    }

    public void ChangeStatusTrue(int id)
    {
        using var context = new SignalRContext();
        var value = context.Discounts.Find(id);
        value.Status = true;
        context.SaveChanges();
    }

    public void ChangeStatusFalse(int id)
    {
        using var context = new SignalRContext();
        var value = context.Discounts.Find(id);
        value.Status = false;
        context.SaveChanges();
    }
}