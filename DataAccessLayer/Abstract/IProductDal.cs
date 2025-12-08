using EntityLayer.Entities;

namespace DataAccessLayer.Abstract;

public interface IProductDal : IGenericDal<Product>
{
    List<Product> GetProductWithCategories();
    int ProductCount();
    int ProductCountByCategoryNameHamburger();
    int ProductCountByCategoryNameDrink();
    decimal ProductPriceAvg();
    string ProducNameByPriceMax();
    string ProducNameByPriceMin();
}