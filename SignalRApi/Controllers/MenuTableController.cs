using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.MenuTableDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;
        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _mapper = mapper;
            _menuTableService = menuTableService;
        }
        
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.MenuTableCount());
        }
        
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto cratemenuTableDto)
        {
            cratemenuTableDto.Status = false;
            var value = _mapper.Map<MenuTable>(cratemenuTableDto);
            _menuTableService.TAdd(value);
            return Ok("Masa eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Masa silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            updateMenuTableDto.Status = false;
            var value = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(value);
            return Ok("Masa Güncellendi");
        }
    
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(_mapper.Map<GetMenuTableDto>(value));
        }
    }
}
