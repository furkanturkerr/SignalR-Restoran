using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
    public EfCategoryDal(SignalRContext context) : base(context)
    {
    }

    public int CategoryCount()
    {
        using var context = new SignalRContext();
        return context.Categories.Count();
    }

    public int ActiveCategoryCount()
    {
        using var context = new SignalRContext();
        return context.Categories.Where(x => x.Status == true).Count();
    }

    public int PassiveCategoryCount()
    {
        using var context = new SignalRContext();
        return context.Categories.Where(x => x.Status == false).Count();
    }
}