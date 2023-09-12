using ProductManagement.Domain.Entities;
using ProductManagement.Persistence.Repositories.Abstracts;
using ProductManagement.Service.Services.Abstracts;
using System.Collections.Generic;
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

		public async Task<ICollection<Category>> GetCategories()
		{
			return await _categoryRepo.GetAllAsync();
		}

		public async Task<Category> GetCategoryById(string Id)
		{
			return await _categoryRepo.GetByIdAsync(Id);
		}
	}
}
