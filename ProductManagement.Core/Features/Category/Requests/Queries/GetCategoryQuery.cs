using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Models;

namespace ProductManagement.Core.Features.Category.Requests.Queries
{
	public class GetCategoryQuery : IRequest<Response<CategoryDto>>
	{
		public string Id { get; set; }
	}
}
