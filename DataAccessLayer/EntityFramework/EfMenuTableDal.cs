using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
{
    public EfMenuTableDal(SignalRContext context) : base(context)
    {
    }

    public int MenuTableCount()
    {
        using var context = new SignalRContext();
        return context.MenuTables.Count();
    }

    public void changeMasaTablestatusTrue(int id)
    {
        using var context = new SignalRContext();
        var value = context.MenuTables.Where(x => x.MenuTableId == id).FirstOrDefault();
        value.Status = true;
        context.SaveChanges();
    }

    public void changeMasaTablestatusFalse(int id)
    {
        using var context = new SignalRContext();
        var value = context.MenuTables.Where(x => x.MenuTableId == id).FirstOrDefault();
        value.Status = false;
        context.SaveChanges();
    }
}