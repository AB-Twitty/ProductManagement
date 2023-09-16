using MediatR;
using ProductManagement.Core.Models;

namespace ProductManagement.Core.Features.Category.Requests.Commands
{
	public class DeleteCategoryCommand : IRequest<Response<string>>
	{
		public string Id { get; set; }
	}
}
