using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Persistence;
using Core.Interfaces;
using Infrastructure.Repository;
using Core.Entities;

namespace TodoExample.Infrastructure
{
	public static class ConfigureServices
	{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("TodoExampleDb");

            });

 
            services.AddScoped<IRepository<Todo>, TodoRepository>();

            return services;
        }
    }
}

