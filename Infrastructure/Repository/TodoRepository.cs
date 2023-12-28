using Core.Entities;
using Core.Interfaces;

using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class TodoRepository : IRepository<Todo>
	{
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Todo Add(Todo entity) => _context.Todos.Add(entity).Entity;

        public void Delete(Todo entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Todo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> List()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

