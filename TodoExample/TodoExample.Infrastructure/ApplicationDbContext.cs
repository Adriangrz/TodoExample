using Microsoft.EntityFrameworkCore;

using TodoExample.Core.Entities;

namespace TodoExample.Infrastructure.Persistence
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

