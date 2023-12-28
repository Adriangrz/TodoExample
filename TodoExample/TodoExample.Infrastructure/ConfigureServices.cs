using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using TodoExample.Infrastructure.Persistence;

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

 
           // services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();


            return services;
        }
    }
}

