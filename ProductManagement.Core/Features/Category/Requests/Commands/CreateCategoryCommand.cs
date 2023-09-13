using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Models;

namespace ProductManagement.Core.Features.Category.Requests.Commands
{
	public class CreateCategoryCommand : IRequest<Response<CategoryDto>>
	{
		public CategoryCreateDto CategoryCreateDto { get; set; }
	}
}
