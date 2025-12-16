using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ContactDTO;
using DTOLayer.DiscountDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _mapper = mapper;
            _discountService = discountService;
        }
        
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);
            return Ok("İndirim bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim bilgisi silindi");
        }
    
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("İndirim bilgisi güncellendi");
        }
        
        [HttpGet("ChangeStatusTrue/{id}")]
        public IActionResult ChangeStatusTrue(int id)
        {
            _discountService.TChangeStatusTrue(id);
            return Ok("Ürün indirimi aktif hale getirildi");
        }
        
        [HttpGet("ChangeStatusFalse/{id}")]
        public IActionResult ChangeStatusFalse(int id)
        {
            _discountService.TChangeStatusFalse(id);
            return Ok("Ürün aktif hale getirildi");
        }
    }
}
