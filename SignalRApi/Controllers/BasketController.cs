using BusinessLayer.Abstract;
using DataAccessLayer.Concrate;
using DTOLayer.BasketDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.TGetBasketsByMenuTableNumber(id);
            return Ok(values); 
        }
        
        [HttpGet("BasketListByMenuWithProductName")]
        public IActionResult BasketListByMenuWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableId == id)
                .Select(x => new ResultBasketListWithProduct()
                {
                    BasketId = x.BasketId,
                    Count = x.Count,
                    MenuTableId = x.MenuTableId,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    TotalPrice = x.TotalPrice
                }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                Price = context.Products.Where(x=>x.ProductId == createBasketDto.ProductId)
                    .Select(y=>y.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Ürün silindi");
        }
    }
}
