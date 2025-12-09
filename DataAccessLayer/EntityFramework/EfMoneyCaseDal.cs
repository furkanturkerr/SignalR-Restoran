using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
{
    private IMoneyCaseDal _moneyCaseDalImplementation;

    public EfMoneyCaseDal(SignalRContext context) : base(context)
    {
    }

    public decimal MoneyCaseTotalPrice()
    {
        using var context = new SignalRContext();
        return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
    }
}