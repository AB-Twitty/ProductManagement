using MediatR;
using ProductManagement.Core.DTOs.Category;
using System.Collections.Generic;

namespace ProductManagement.Core.Features.Category.Requests.Queries
{
	public class GetCategoryListQuery : IRequest<ICollection<CategoryListDto>>
	{
	}
}
