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
        return _menuTableDal.GetListAll();
    }

    public MenuTable TGetById(int id)
    {
        return _menuTableDal.GetById(id);
    }

    public int MenuTableCount()
    {
        return _menuTableDal.MenuTableCount();
    }
}