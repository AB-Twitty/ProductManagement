using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Bases;
using ProductManagement.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.Context
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{

		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entity in ChangeTracker.Entries<BaseEntity>())
			{
				entity.Entity.UpdatedBy = "Admin";
				entity.Entity.LastUpdatedDate = DateTime.UtcNow;

				if (entity.State == EntityState.Added)
				{
					entity.Entity.Id = Guid.NewGuid().ToString();
				}
			}


			return base.SaveChangesAsync(cancellationToken);
		}

		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<SubCategory> SubCategories { get; set; }
		public virtual DbSet<SellerCategory> SellerCategories { get; set; }
		public virtual DbSet<SellerSubCategory> SellerSubCategories { get; set; }
		public virtual DbSet<Varient> Varients { get; set; }
		public virtual DbSet<VarientValue> VarientValues { get; set; }
		public virtual DbSet<Gallery> Galleries { get; set; }
		public virtual DbSet<Product> Products { get; set; }
	}
}
