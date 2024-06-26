namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TDelete(T entity);
        void TUpdate(T entity);
        void TInsert(T entity);
        T TGetById(int id);
        List<T> TGetListAll();
    }
}
