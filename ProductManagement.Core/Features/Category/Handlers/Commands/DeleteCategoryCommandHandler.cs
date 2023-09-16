using MediatR;
using ProductManagement.Core.Features.Category.Requests.Commands;
using ProductManagement.Core.Models;
using ProductManagement.Service.Services.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.Category.Handlers.Commands
{
	public class DeleteCategoryCommandHandler : ResponseHandler,
												IRequestHandler<DeleteCategoryCommand, Response<string>>
	{
		private readonly ICategoryService _categoryService;

		public DeleteCategoryCommandHandler(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _categoryService.GetCategoryById(request.Id);

			if (category == null)
				return NotFound<string>();

			var result = await _categoryService.DeleteCategory(category);

			if (result == "success") return Deleted<string>();

			return BadRequest<string>();
		}
	}
}
