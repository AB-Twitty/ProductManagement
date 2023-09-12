using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Persistence.Context;

namespace ProductManagement.Persistence
{
	public static class PersistenceLayerRegistration
	{
		public static IServiceCollection ConfigurePersistenceLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ProductDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("ProductConnectionString")));


			return services;
		}
	}
}
