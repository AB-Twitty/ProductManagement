﻿using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Persistence.Context
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{

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