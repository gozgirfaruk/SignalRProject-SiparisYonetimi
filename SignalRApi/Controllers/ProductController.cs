using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var values = _productService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProductDto)
        {
            _productService.TInsert(_mapper.Map<Product>(createProductDto));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(_mapper.Map<Product>(updateProductDto));
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            return Ok();
        }
        [HttpGet("ProductWithCategoryList")]
        public IActionResult ProductWithCategoryList()
        {
            var _context = new SignalRContext();
            var values = _context.Products.Include(x => x.Category).Select(y => new GetProductWithCategoryDto
            {
                Description = y.Description,
                Image = y.Image,
                Name = y.Name,
                Price = y.Price,
                ProductID = y.ProductID,
                Status = y.Status,
                CategoryName = y.Category.Name
            }).ToList();
            return Ok(values);
        }
    }
}
