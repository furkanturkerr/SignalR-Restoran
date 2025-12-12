using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrate;

public class BasketManager : IBasketService
{
    private readonly IBasketDal _basketDal;

    public BasketManager(IBasketDal basketDal)
    {
        _basketDal = basketDal;
    } 
    public List<Basket> TGetBasketsByMenuTableNumber(int id)
    {
        return _basketDal.GetBasketsByMenuTableNumber(id);
    }
}