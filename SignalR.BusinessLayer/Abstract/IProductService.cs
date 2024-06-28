using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TProductWithCategory();
        int TGetProductCount();
        int TProductCountByHamburger();
        int TProductCountByDrink();
        decimal TProductPriceAvg();
        string TProductPriceMax();
        string TProductPriceMin();
        decimal TProductPriceByHamburger();
    }
}
