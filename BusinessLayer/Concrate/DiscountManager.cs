using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrate;

public class DiscountManager : IDiscountService
{
    private readonly IDiscountDal _discountDal;
    public DiscountManager(IDiscountDal discountDal)
    {
        _discountDal = discountDal;
    }
    public void TAdd(Discount entity)
    {
        _discountDal.Add(entity);
    }

    public void TUpdate(Discount entity)
    {
        _discountDal.Update(entity);
    }

    public void TDelete(Discount entity)
    {
        _discountDal.Delete(entity);
    }

    public List<Discount> TGetListAll()
    {
        return _discountDal.GetListAll();
    }

    public Discount TGetById(int id)
    {
        return _discountDal.GetById(id);
    }

    public void TChangeStatusTrue(int id)
    {
        _discountDal.ChangeStatusTrue(id);
    }

    public void TChangeStatusFalse(int id)
    {
        _discountDal.ChangeStatusFalse(id);
    }
}