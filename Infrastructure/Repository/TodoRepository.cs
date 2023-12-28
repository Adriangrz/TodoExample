using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;

using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task Delete(string id)
        {
            Todo todo = await _context.Todos.FindAsync(id) ?? throw new NotFoundException(id);
            
            _context.Todos.Remove(todo);
        }

        public void Edit(Todo entity) => _context.Entry(entity).State = EntityState.Modified;
        

        public async Task<Todo> GetById (string id) => await _context.Todos.FindAsync(id) ?? throw new NotFoundException(id);

        public async Task<IEnumerable<Todo>> List() => await _context.Todos.ToListAsync();

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

