using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.CategoryDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers;
    
[Route("api/[controller]")] 
[ApiController] 
public class CategoryController : ControllerBase 
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }
        
    [HttpGet]
    public IActionResult CategoryList()
    {
        var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
        return Ok(values);
    }

    [HttpGet("CategoryCount")]
    public IActionResult CategoryCount()
    {
        return Ok(_categoryService.TCategoryCount());
    }
    
    [HttpGet("AcctiveCategoryCount")]
    public IActionResult AcctiveCategoryCount()
    {
        return Ok(_categoryService.TActiveCategoryCount());
    }
    
    [HttpGet("PassiveCategoryCount")]
    public IActionResult PassiveCategoryCount()
    {
        return Ok(_categoryService.TPassiveCategoryCount());
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
    {
        _categoryService.TAdd(new Category()
        {
            CategoryName = createCategoryDto.CategoryName,
            Status = true
        });
        return Ok("Kategori eklendi");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var value = _categoryService.TGetById(id);
        _categoryService.TDelete(value);
        return Ok("Kategori silindi");
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var value = _categoryService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        _categoryService.TUpdate(new Category()
        {
            CategoryName = updateCategoryDto.CategoryName,
            CategoryId = updateCategoryDto.CategoryId,
            Status = true
        });
        return Ok("Kategori güncellendi");
    }
}
