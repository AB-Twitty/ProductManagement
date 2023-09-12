using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Persistence.Context;
using ProductManagement.Persistence.Repositories.Abstracts;

namespace ProductManagement.Persistence.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		private readonly DbSet<Category> _categories;

		public CategoryRepository(ProductDbContext context) : base(context)
		{
			_categories = context.Categories;
		}


	}
}
