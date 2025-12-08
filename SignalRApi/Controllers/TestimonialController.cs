using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.TestimonialDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }
        
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial
            {
                Name = createTestimonialDto.Name,
                Title = createTestimonialDto.Title,
                Command = createTestimonialDto.Command,
                ImageUrl = createTestimonialDto.ImageUrl,
                Status = createTestimonialDto.Status
            });
            return Ok("Yorum bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Yorum bilgisi silindi");
        }
    
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                Command = updateTestimonialDto.Command,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = updateTestimonialDto.Status
            });
            return Ok("Yorum bilgisi güncellendi");
        }
    }

}
