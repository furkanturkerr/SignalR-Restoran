using EntityLayer.Entities;

namespace DataAccessLayer.Abstract;

public interface IMenuTableDal : IGenericDal<MenuTable>
{
    public int MenuTableCount();
    void changeMasaTablestatusTrue(int id);
    void changeMasaTablestatusFalse(int id);
}