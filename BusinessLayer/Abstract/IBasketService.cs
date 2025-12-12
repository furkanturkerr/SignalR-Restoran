using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface IBasketService : IGenericService<Basket>
{
    List<Basket> TGetBasketsByMenuTableNumber(int id);
}