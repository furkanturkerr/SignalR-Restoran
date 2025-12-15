using EntityLayer.Entities;

namespace DataAccessLayer.Abstract;

public interface IDiscountDal : IGenericDal<Discount>
{
    void ChangeStatusTrue(int id);
    void ChangeStatusFalse(int id);
}