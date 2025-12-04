using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DiscountDTO;
using DTOLayer.FeatureDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _mapper = mapper;
            _featureService = featureService;
        }
        
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature
            {
                Title1 = createFeatureDto.Title1,
                Description1 = createFeatureDto.Description1,
                Title2 = createFeatureDto.Title2,
                Description2 = createFeatureDto.Description2,
                Title3 = createFeatureDto.Title3,
                Description3 = createFeatureDto.Description3
            });
            return Ok("Özellik bilgisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Özellik bilgisi silindi");
        }
    
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature
            {
                FeatureId = updateFeatureDto.FeatureId,
                Title1 = updateFeatureDto.Title1,
                Description1 = updateFeatureDto.Description1,
                Title2 = updateFeatureDto.Title2,
                Description2 = updateFeatureDto.Description2,
                Title3 = updateFeatureDto.Title3,
                Description3 = updateFeatureDto.Description3
            });
            return Ok("Özellik bilgisi güncellendi");
        }
    }

}
