using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Persistence.Repositories.Abstracts;
using ProductManagement.Service.Services.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Service.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepo;

		public CategoryService(ICategoryRepository categoryRepo)
		{
			_categoryRepo = categoryRepo;
		}

		public async Task<Category> CreateCategory(Category category)
		{
			if (_categoryRepo.GetTableNoTracking().Where(c => c.Name.Equals(category.Name)).Any())
				return null;

			var x = await _categoryRepo.AddAsync(category);
			return x;
		}

		public async Task<ICollection<Category>> GetCategories()
		{
			return await _categoryRepo.GetAllAsync();
		}

		public async Task<Category> GetCategoryById(string Id)
		{
			var x = await _categoryRepo.GetByIdAsync(Id);
			return x;
		}

		public IQueryable<Category> GetQuerableForPagination(string search)
		{
			var quearable = _categoryRepo.GetTableNoTracking().AsQueryable();
			if (search != null)
				quearable = quearable.Where(c => c.Name.Contains(search));
			return quearable;
		}

		public async Task<bool> IsNameExist(string Name)
		{
			return await _categoryRepo.GetTableNoTracking().AnyAsync(x => x.Name.ToUpper().Equals(Name == null ? "" : Name.ToUpper()));
		}
	}
}
