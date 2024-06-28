using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto dto)
        {
            var values = _mapper.Map<Category>(dto);
            _categoryService.TInsert(values);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            var values = _mapper.Map<Category>(dto);
            _categoryService.TUpdate(values);
            return Ok();
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var values =_mapper.Map<GetCategoryDto>(_categoryService.TGetById(id));
            return Ok(values);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TGetCategoryCount());
        }

        [HttpGet("ActiveCategory")]
        public IActionResult ActiveCategory()
        {
            return Ok(_categoryService.TActiveCategoryCount());

        }
        [HttpGet("PassiveCategory")]
        public IActionResult PassiveCategory()
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }
    }
}
