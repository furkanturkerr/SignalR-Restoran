using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface IDiscountService : IGenericService<Discount>
{
    void TChangeStatusTrue(int id);
    void TChangeStatusFalse(int id);
}