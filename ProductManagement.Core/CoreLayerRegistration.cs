using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductManagement.Core
{
	public static class CoreLayerRegistration
	{
		public static IServiceCollection ConfigureCoreLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}
