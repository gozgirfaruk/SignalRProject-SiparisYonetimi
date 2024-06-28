using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        int GetCategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
    }
}
