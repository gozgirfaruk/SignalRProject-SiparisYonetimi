using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var _context=new SignalRContext();
            return _context.Orders.Where(x=>x.Description== "Ödenmedi").Count();

        }

        public decimal LastOrder()
        {
            using var _context = new SignalRContext();
            var value = _context.Orders.OrderByDescending(x=>x.OrderID).Select(y=>y.TotalPrice).FirstOrDefault();
            return value;
        }

        public decimal TodayTotalPrice()
        {
            using var _context=new SignalRContext();
            return _context.Orders.Where(x=>x.Date==DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y=>y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var _context = new SignalRContext();
            return _context.Orders.Count();
        }
    }
}
