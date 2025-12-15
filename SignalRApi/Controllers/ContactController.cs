using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.CategoryDTO;
using DTOLayer.ContactDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _mapper = mapper;
            _contactService = contactService;
        }
        
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                Location = createContactDto.Location,
                FooterDescription = createContactDto.FooterDescription,
                PhoneNumber = createContactDto.PhoneNumber,
                Mail = createContactDto.Mail,
                FooterTitle = createContactDto.FooterTitle,
                Opendays = createContactDto.Opendays,
                OpendaysDescription = createContactDto.OpendaysDescription,
                OpenHours = createContactDto.OpenHours
            });
            return Ok("İletişim bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim bilgisi silindi");
        }
    
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactId = updateContactDto.ContactId,
                Location = updateContactDto.Location,
                FooterDescription = updateContactDto.FooterDescription,
                PhoneNumber = updateContactDto.PhoneNumber,
                Mail = updateContactDto.Mail,
                FooterTitle = updateContactDto.FooterTitle,
                Opendays = updateContactDto.Opendays,
                OpendaysDescription = updateContactDto.OpendaysDescription,
                OpenHours = updateContactDto.OpenHours
            });
            return Ok("İletişim bilgisi güncellendi");
        }
    }
}
