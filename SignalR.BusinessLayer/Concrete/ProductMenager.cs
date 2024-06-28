using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductMenager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductMenager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> TProductWithCategory()
        {
            return _productDal.ProductWithCategory();
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
           return _productDal.GetListAll();
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public int TGetProductCount()
        {
            return _productDal.GetProductCount();
        }

        public int TProductCountByHamburger()
        {
            return _productDal.ProductCountByHamburger();
        }

        public int TProductCountByDrink()
        {
            return _productDal.ProductCountByDrink();
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public string TProductPriceMax()
        {
           return _productDal.ProductPriceMax();
        }

        public string TProductPriceMin()
        {
            return _productDal.ProductPriceMin();
        }

        public decimal TProductPriceByHamburger()
        {
            return _productDal.ProductPriceByHamburger();
        }
    }
}
