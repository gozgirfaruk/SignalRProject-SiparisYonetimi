using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTable(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListMenuTableWithProductName")]
        public IActionResult BasketListMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListProductName
            {
                BasketID = z.BasketID,
                MenuTableID = z.MenuTableID,
                Count = z.Count,
                Price = z.Price,
                ProductID = z.ProductID,
                ProductName = z.Product.Name,
                TotalPrice = z.TotalPrice
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto dto)
        {
            using var context = new SignalRContext();
            _basketService.TInsert(new Basket()
            {
               ProductID = dto.ProductID,
                Count = 1,
                MenuTableID = 5,
                Price = context.Products.Where(x => x.ProductID == dto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0

            });
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBasket(int id)
        {
            var values = _basketService.TGetById(id);
            _basketService.TDelete(values);
            return Ok();
        }
    }
}
