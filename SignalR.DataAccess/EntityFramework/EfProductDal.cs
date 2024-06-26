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
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> ProductWithCategory()
        {
            var _context = new SignalRContext();
            var values = _context.Products.Include(x => x.Category).ToList();
            return values;
        }
    }
}
