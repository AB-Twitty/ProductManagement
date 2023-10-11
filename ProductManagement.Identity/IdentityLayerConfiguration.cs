using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Identity.Context;
using ProductManagement.Identity.Models;
using System;

namespace ProductManagement.Identity
{
	public static class IdentityLayerConfiguration
	{
		public static IServiceCollection ConfigureIdentityLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppIdentityDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString")));


			services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				//Lockout options
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.AllowedForNewUsers = true;
				options.Lockout.MaxFailedAccessAttempts = 5;

				//Signin options
				options.SignIn.RequireConfirmedEmail = false;

				//User options
				options.User.RequireUniqueEmail = true;

				//Password options
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 6;
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredUniqueChars = 1;

			}).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();


			return services;
		}
	}
}
