using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface IBasketService
{
    List<Basket> TGetBasketsByMenuTableNumber(int id);
}