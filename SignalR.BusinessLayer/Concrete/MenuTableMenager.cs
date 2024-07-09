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
    public class MenuTableMenager : IMenuTableService
    {
        private readonly IMenuTableDal _tableDal;

        public MenuTableMenager(IMenuTableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public void TDelete(MenuTable entity)
        {
            _tableDal.Delete(entity);
        }

        public MenuTable TGetById(int id)
        {
            return _tableDal.GetById(id);
        }

        public List<MenuTable> TGetListAll()
        {
            return _tableDal.GetListAll();
        }

        public void TInsert(MenuTable entity)
        {
            _tableDal.Insert(entity);
        }

        public int TMenuTableCount()
        {
            return _tableDal.MenuTableCount();
        }

        public void TUpdate(MenuTable entity)
        {
            _tableDal.Update(entity);
        }
    }
}
