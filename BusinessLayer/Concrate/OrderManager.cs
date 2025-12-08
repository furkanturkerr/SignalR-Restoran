using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrate;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;
    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }
    public void TAdd(Order entity)
    {
        _orderDal.Add(entity);
    }

    public void TUpdate(Order entity)
    {
        _orderDal.Update(entity);
    }

    public void TDelete(Order entity)
    {
        _orderDal.Delete(entity);
    }

    public List<Order> TGetListAll()
    {
        return _orderDal.GetListAll();
    }

    public Order TGetById(int id)
    {
        return _orderDal.GetById(id);
    }
}