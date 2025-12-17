using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface IMenuTableService : IGenericService<MenuTable>
{
    int MenuTableCount();
    void TchangeMasaTablestatusTrue(int id);
    void TchangeMasaTablestatusFalse(int id);
}