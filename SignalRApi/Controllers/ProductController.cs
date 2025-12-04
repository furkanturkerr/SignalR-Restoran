using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ProductDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
               ImageUrl = createProductDto.ImageUrl,
               Price = createProductDto.Price,
               ProductDescription = createProductDto.ProductDescription,
               ProductName = createProductDto.ProductName,
               Status = createProductDto.Status
            });
            return Ok("Ürün bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün bilgisi silindi");
        }
    
        [HttpGet("GetProduct")]
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
                Status = updateProductDto.Status
            });
            return Ok("Ürün bilgisi güncellendi");
        }
    }

}
