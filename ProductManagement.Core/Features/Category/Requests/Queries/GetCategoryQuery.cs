using MediatR;
using ProductManagement.Core.DTOs.Category;

namespace ProductManagement.Core.Features.Category.Requests.Queries
{
	public class GetCategoryQuery : IRequest<CategoryDto>
	{
		public string Id { get; set; }
	}
}
