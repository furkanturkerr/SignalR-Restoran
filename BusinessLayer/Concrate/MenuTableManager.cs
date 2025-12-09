using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrate;

public class MenuTableManager : IMenuTableService
{
    private readonly IMenuTableDal _menuTableDal;
    public MenuTableManager(IMenuTableDal menuTableDal)
    {
        _menuTableDal = menuTableDal;
    }
    public void TAdd(MenuTable entity)
    {
       _menuTableDal.Add(entity);
    }

    public void TUpdate(MenuTable entity)
    {
        _menuTableDal.Update(entity);
    }

    public void TDelete(MenuTable entity)
    {
        _menuTableDal.Delete(entity);
    }

    public List<MenuTable> TGetListAll()
    {
        throw new NotImplementedException();
    }

    public MenuTable TGetById(int id)
    {
        throw new NotImplementedException();
    }

    public int MenuTableCount()
    {
        return _menuTableDal.MenuTableCount();
    }
}