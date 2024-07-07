﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketMenager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketMenager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TDelete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }

        public Basket TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Basket entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
