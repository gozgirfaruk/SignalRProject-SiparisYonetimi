using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccess.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;
        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int GetProductCount()
        {
            var value = _context.Products.Count();
            return value;
        }

        public int ProductCountByDrink()
        {
            var value = _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.Name == "İçecek").Select(x => x.CategoryID).FirstOrDefault())).Count();
            return value;
        }

        public int ProductCountByHamburger()
        {
            var value = _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.Name == "Hamburger").Select(x => x.CategoryID).FirstOrDefault())).Count();
            return value;
        }

        public decimal ProductPriceAvg()
        {
            return _context.Products.Average(x=> x.Price);
        }

        public decimal ProductPriceByHamburger()
        {
            return _context.Products.Where(x => x.ProductID == (_context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w=>w.Price);
        }

        public string ProductPriceMax()
        {
            var value = _context.Products.Where(x=>x.Price==(_context.Products.Max(y=>y.Price))).Select(z=>z.Name).FirstOrDefault();
          
            return value;
        }

        public string ProductPriceMin()
        {
            var value = _context.Products.Where(x=>x.Price==(_context.Products.Min(y=>y.Price))).Select(c=>c.Name).FirstOrDefault();
            return value;
        }

        public List<Product> ProductWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return values;
        }
    }
}
