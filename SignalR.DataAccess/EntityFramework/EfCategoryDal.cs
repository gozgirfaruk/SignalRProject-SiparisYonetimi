using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccess.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext _context;
        public EfCategoryDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            var value =_context.Categories.Where(x=>x.Status==true).Count();
            return value;
        }

        public int GetCategoryCount()
        {
            return _context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            var value = _context.Categories.Where(x=>x.Status==false).Count();
            return value;
        }
    }
}
