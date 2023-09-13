using ProductManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Service.Services.Abstracts
{
	public interface ICategoryService
	{
		Task<Category> GetCategoryById(string Id);
		Task<ICollection<Category>> GetCategories();
		Task<Category> CreateCategory(Category category);
	}
}
