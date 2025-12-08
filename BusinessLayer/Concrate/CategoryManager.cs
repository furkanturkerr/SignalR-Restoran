using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrate;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    public void TAdd(Category entity)
    {
        _categoryDal.Add(entity);
    }

    public void TUpdate(Category entity)
    {
        _categoryDal.Update(entity);
    }

    public void TDelete(Category entity)
    {
        _categoryDal.Delete(entity);
    }

    public List<Category> TGetListAll()
    {
        return _categoryDal.GetListAll();
    }

    public Category TGetById(int id)
    {
        return _categoryDal.GetById(id);
    }

    public int TCategoryCount()
    {
        return _categoryDal.CategoryCount();
    }

    public int TActiveCategoryCount()
    {
        return _categoryDal.ActiveCategoryCount();
    }

    public int TPassiveCategoryCount()
    {
        return _categoryDal.PassiveCategoryCount();
    }
}