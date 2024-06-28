using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderDetailMenager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailMenager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity);
        }

        public OrderDetail TGetById(int id)
        {
            return _orderDetailDal.GetById(id);
        }

        public List<OrderDetail> TGetListAll()
        {
            return _orderDetailDal.GetListAll();
        }

        public void TInsert(OrderDetail entity)
        {
            _orderDetailDal.Insert(entity);
        }

        public void TUpdate(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }
    }
}
