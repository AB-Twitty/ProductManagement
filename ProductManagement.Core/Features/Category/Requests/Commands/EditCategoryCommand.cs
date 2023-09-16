using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Models;

namespace ProductManagement.Core.Features.Category.Requests.Commands
{
	public class EditCategoryCommand : IRequest<Response<string>>
	{
		public CategoryEditDto CategoryEditDto { get; set; }
	}
}
