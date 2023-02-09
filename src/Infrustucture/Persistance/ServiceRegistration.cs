using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("memoryDb");
            });
            serviceCollection.AddTransient<IProductRepository,ProductRepository>();
            
        }
    }
}
