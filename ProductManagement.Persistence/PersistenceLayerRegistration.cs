using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Persistence.Context;
using ProductManagement.Persistence.Repositories;
using ProductManagement.Persistence.Repositories.Abstracts;

namespace ProductManagement.Persistence
{
	public static class PersistenceLayerRegistration
	{
		public static IServiceCollection ConfigurePersistenceLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ProductDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("ProductConnectionString")));

			services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddTransient<ICategoryRepository, CategoryRepository>();

			return services;
		}
	}
}
