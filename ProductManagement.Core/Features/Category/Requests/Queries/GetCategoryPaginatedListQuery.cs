using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core.Features.Category.Requests.Queries
{
	public class GetCategoryPaginatedListQuery : IRequest<Response<ICollection<CategoryListDto>>>
	{
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public string? Search { get; set; }
		public string[]? OrderBy { get; set; }
	}
}
