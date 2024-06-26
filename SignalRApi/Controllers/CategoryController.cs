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
            var values = _categoryService.TGetListAll();
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
            var values = _categoryService.TGetById(id);
            return Ok(values);
        }
    }
}
