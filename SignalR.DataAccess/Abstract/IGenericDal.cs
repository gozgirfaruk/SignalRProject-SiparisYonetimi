namespace SignalR.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Delete(T entity);
        void Update(T entity);
        void Insert(T entity);
        T GetById(int id);
        List<T> GetListAll();
    }
}
