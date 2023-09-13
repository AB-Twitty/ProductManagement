using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Entities;
using System;

namespace ProductManagement.Persistence.Configurations
{
	public class CategoryConfigurations : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(
				new Category
				{
					//Id = "1cd7b23b-cb2e-4602-bcbf-edd148bde44b",
					Id = Guid.NewGuid(),
					Name = "Electronics",
					Description = "This category will hold products characterised as electronics.",
					IsActive = true,
				},
				new Category
				{
					//Id = "2cd7b23b-cb2e-4602-bcbf-edd148bde44b",
					Id = Guid.NewGuid(),
					Name = "Books",
					Description = "This category will hold products characterised as books",
					IsActive = true,
				},
				new Category
				{
					//Id = "3cd7b23b-cb2e-4602-bcbf-edd148bde44b",
					Id = Guid.NewGuid(),
					Name = "Clothes",
					Description = "This category will hold products characterised as clothes",
					IsActive = true,
				}
			);
		}
	}
}
