using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core.Features.Category.Requests.Queries
{
	public class GetCategoryListQuery : IRequest<Response<ICollection<CategoryListDto>>>
	{
	}
}
