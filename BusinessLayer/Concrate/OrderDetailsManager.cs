using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrate;

public class OrderDetailsManager : IOrderDetailsService
{
    private readonly IOrderDetailDal _orderDetailDal;
    public OrderDetailsManager(IOrderDetailDal orderDetailDal)
    {
        _orderDetailDal = orderDetailDal;
    }
    public void TAdd(OrderDetail entity)
    {
        _orderDetailDal.Add(entity);
    }

    public void TUpdate(OrderDetail entity)
    {
        _orderDetailDal.Update(entity);
    }

    public void TDelete(OrderDetail entity)
    {
        _orderDetailDal.Delete(entity);
    }

    public List<OrderDetail> TGetListAll()
    {
        return _orderDetailDal.GetListAll();
    }

    public OrderDetail TGetById(int id)
    {
        return _orderDetailDal.GetById(id);
    }
}