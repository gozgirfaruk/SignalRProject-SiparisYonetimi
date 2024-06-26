using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
         List<Product> ProductWithCategory();
    }
}
