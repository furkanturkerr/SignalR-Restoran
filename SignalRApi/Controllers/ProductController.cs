using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrate;
using DTOLayer.ProductDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }
        
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }
        
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        
        [HttpGet("ProductCountDrink")]
        public IActionResult ProductCountDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }
        
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x=>x.Category).Select(y=>new ResultProductWithCategory()
            {
                ProductDescription = y.ProductDescription,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                Status = y.Status,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
               ImageUrl = createProductDto.ImageUrl,
               Price = createProductDto.Price,
               ProductDescription = createProductDto.ProductDescription,
               ProductName = createProductDto.ProductName,
               Status = createProductDto.Status,
               CategoryId = createProductDto.CategoryId
            });
            return Ok("Ürün bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün bilgisi silindi");
        }
    
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                ProductId = updateProductDto.ProductId,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductDescription = updateProductDto.ProductDescription,
                ProductName = updateProductDto.ProductName,
                Status = updateProductDto.Status,
                CategoryId = updateProductDto.CategoryId
            });
            return Ok("Ürün bilgisi güncellendi");
        }
    }

}
