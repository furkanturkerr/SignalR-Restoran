using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.SliderDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TAdd(new Slider()
            {
                Tıtle1 = createSliderDto.Tıtle1,
                Tıtle2 = createSliderDto.Tıtle2,
                Tıtle3 = createSliderDto.Tıtle3,
                Description1 = createSliderDto.Description1,
                Description2 = createSliderDto.Description2,
                Description3 = createSliderDto.Description3,
            });
            return Ok("Özellik bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Özellik bilgisi silindi");
        }
    
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderId = updateSliderDto.SliderId,
                Tıtle1 = updateSliderDto.Tıtle1,
                Description1 = updateSliderDto.Description1,
                Tıtle2 = updateSliderDto.Tıtle2,
                Description2 = updateSliderDto.Description2,
                Tıtle3 = updateSliderDto.Tıtle3,
                Description3 = updateSliderDto.Description3
            });
            return Ok("Özellik bilgisi güncellendi");
        }
    }

}
