using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Identity.Models;

namespace ProductManagement.Identity.Configurations
{
	public class UserConfigurations : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			var hasher = new PasswordHasher<AppUser>();

			builder.HasData(
				new AppUser
				{
					Id = "1cd7b23b-cb2e-4602-bcbf-edd148bde44b",
					FirstName = "Admin",
					LastName = "System",
					UserName = "Admin",
					NormalizedUserName = "ADMIN",
					Email = "admin@localhost.com",
					NormalizedEmail = "ADMIN@LOCALHOST.COM",
					EmailConfirmed = false,
					PasswordHash = hasher.HashPassword(null, "P@ssword1")
				}
			);
		}
	}
}
