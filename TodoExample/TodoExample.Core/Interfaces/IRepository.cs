namespace TodoExample.Core.Interfaces
{
	public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> List();
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        Task Save();
    }
}

