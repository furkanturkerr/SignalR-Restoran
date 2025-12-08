using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface ICategoryService : IGenericService<Category>
{
    public int TCategoryCount();
    int TActiveCategoryCount();
    int TPassiveCategoryCount();
}