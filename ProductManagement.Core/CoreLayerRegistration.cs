using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Core.Models;
using System.Reflection;

namespace ProductManagement.Core
{
	public static class CoreLayerRegistration
	{
		public static IServiceCollection ConfigureCoreLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			return services;
		}
	}
}
