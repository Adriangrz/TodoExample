using Microsoft.EntityFrameworkCore;

using Core.Entities;

namespace Infrastructure.Persistence
{
	public class ApplicationDbContext: DbContext
	{
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

