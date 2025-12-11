using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfSliderDal : GenericRepository<Slider>, ISliderDal
{
    public EfSliderDal(SignalRContext context) : base(context)
    {
    }
}