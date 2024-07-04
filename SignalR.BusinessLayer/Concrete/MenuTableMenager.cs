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
            throw new NotImplementedException();
        }

        public MenuTable TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MenuTable> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TInsert(MenuTable entity)
        {
            throw new NotImplementedException();
        }

        public int TMenuTableCount()
        {
            return _tableDal.MenuTableCount();
        }

        public void TUpdate(MenuTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
