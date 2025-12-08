using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product> , IProductDal
{
    public EfProductDal(SignalRContext context) : base(context)
    {
    }

    public List<Product> GetProductWithCategories()
    {
        var context = new SignalRContext();
        var values = context.Products.Include(x=>x.Category).ToList();
        return values;
    }

    public int ProductCount()
    {
        using var context = new SignalRContext();
        return context.Products.Count();
    }

    public int ProductCountByCategoryNameHamburger()
    {
        using var context = new SignalRContext();
        return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y=>y.CategoryName
        =="Hamburger").Select(z=>z.CategoryId).FirstOrDefault())).Count();
    }

    public int ProductCountByCategoryNameDrink()
    {
        using var context = new SignalRContext();
        return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y=>y.CategoryName
            =="İçecek").Select(z=>z.CategoryId).FirstOrDefault())).Count();
    }
}