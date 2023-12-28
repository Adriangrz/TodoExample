namespace Core.Interfaces
{
	public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> List();
        T Add(T entity);
        Task Delete(Guid id);
        void Edit(T entity);
        Task Save();
    }
}

