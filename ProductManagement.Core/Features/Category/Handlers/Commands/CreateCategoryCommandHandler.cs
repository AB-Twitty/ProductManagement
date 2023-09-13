using AutoMapper;
using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Features.Category.Requests.Commands;
using ProductManagement.Core.Models;
using ProductManagement.Service.Services.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.Category.Handlers.Commands
{
	public class CreateCategoryCommandHandler : ResponseHandler, IRequestHandler<CreateCategoryCommand, Response<CategoryDto>>
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public async Task<Response<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var m = _mapper.Map<Domain.Entities.Category>(request.CategoryCreateDto);
			var response = await _categoryService.CreateCategory(m);
			if (response == null) return UnprocessableEntity<CategoryDto>();
			return Created(_mapper.Map<CategoryDto>(response));
		}
	}
}
