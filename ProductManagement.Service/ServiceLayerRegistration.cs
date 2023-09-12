using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Service.Services;
using ProductManagement.Service.Services.Abstracts;

namespace ProductManagement.Service
{
	public static class ServiceLayerRegistration
	{
		public static IServiceCollection ConfigureServiceLayer(this IServiceCollection services)
		{
			services.AddTransient<ICategoryService, CategoryService>();

			return services;
		}
	}
}
