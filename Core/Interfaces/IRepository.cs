namespace Core.Interfaces
{
	public interface IRepository<T> where T : class
    {
        Task<T> GetById(string id);
        Task<IEnumerable<T>> List();
        T Add(T entity);
        Task Delete(string id);
        void Edit(T entity);
        Task Save();
    }
}

