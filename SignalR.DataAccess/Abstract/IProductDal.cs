using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
         List<Product> ProductWithCategory();
        int GetProductCount();
        int ProductCountByHamburger();
        int ProductCountByDrink();
        decimal ProductPriceAvg();
        string ProductPriceMax();
        string ProductPriceMin();
        decimal ProductPriceByHamburger();
    }
}
