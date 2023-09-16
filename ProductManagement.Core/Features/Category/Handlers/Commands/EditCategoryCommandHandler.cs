using AutoMapper;
using MediatR;
using ProductManagement.Core.Features.Category.Requests.Commands;
using ProductManagement.Core.Models;
using ProductManagement.Service.Services.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.Category.Handlers.Commands
{
	public class EditCategoryCommandHandler : ResponseHandler,
											  IRequestHandler<EditCategoryCommand, Response<string>>
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public EditCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
		{
			if (!await _categoryService.IsCategoryExist(request.CategoryEditDto.Id))
				return NotFound<string>();

			var result = await _categoryService.EditCategory(_mapper.Map<Domain.Entities.Category>(request.CategoryEditDto));

			if (result == "success")
				return Success($"The data with id ({request.CategoryEditDto.Id}) updated successfully.");

			return BadRequest<string>();
		}
	}
}
