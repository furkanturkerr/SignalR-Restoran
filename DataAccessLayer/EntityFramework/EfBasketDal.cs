using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfBasketDal : GenericRepository<Basket>, IBasketDal
{
    private IBasketDal _basketDalImplementation;

    public  EfBasketDal(SignalRContext context) : base(context)
    {
    }

    public List<Basket> GetBasketsByMenuTableNumber(int id)
    {
        using var context = new SignalRContext();
        return context.Baskets.Where(b => b.MenuTableId == id).Include(y=>y.Product).ToList();    
    }
}