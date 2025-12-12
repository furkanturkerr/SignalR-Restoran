using EntityLayer.Entities;

namespace DataAccessLayer.Abstract;

public interface IBasketDal : IGenericDal<Basket>
{
    List<Basket> GetBasketsByMenuTableNumber(int id);
}