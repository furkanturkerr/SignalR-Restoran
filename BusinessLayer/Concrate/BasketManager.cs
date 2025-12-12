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

    public void TAdd(Basket entity)
    {
        _basketDal.Add(entity);
    }

    public void TUpdate(Basket entity)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Basket entity)
    {
        throw new NotImplementedException();
    }

    public List<Basket> TGetListAll()
    {
        throw new NotImplementedException();
    }

    public Basket TGetById(int id)
    {
        throw new NotImplementedException();
    }
}