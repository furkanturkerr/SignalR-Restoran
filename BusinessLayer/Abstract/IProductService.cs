using EntityLayer.Entities;

namespace BusinessLayer.Abstract;

public interface IProductService : IGenericService<Product>
{
    List<Product> TGetProductWithCategories();
    int TProductCount();
    int TProductCountByCategoryNameHamburger();
    int TProductCountByCategoryNameDrink();
}