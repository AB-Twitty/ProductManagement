using ProductManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Service.Services.Abstracts
{
	public interface ICategoryService
	{
		Task<Category> GetCategoryById(string Id);
		Task<ICollection<Category>> GetCategories();
		Task<Category> CreateCategory(Category category);
		Task<bool> IsNameExist(string Name);
		IQueryable<Category> GetQuerableForPagination(string search);
		Task<bool> IsNameExistExcludeSelf(string key, string id);
		Task<bool> IsCategoryExist(string id);
		Task<string> EditCategory(Category category);
		Task<string> DeleteCategory(Category category);
	}
}
