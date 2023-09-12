using AutoMapper;
using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Features.Category.Requests.Queries;
using ProductManagement.Core.Models;
using ProductManagement.Service.Services.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.Category.Handlers.Queries
{
	public class GetCategoryQueryHandler : ResponseHandler, IRequestHandler<GetCategoryQuery, Response<CategoryDto>>
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public GetCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public async Task<Response<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
		{
			var category = await _categoryService.GetCategoryById(request.Id);
			if (category == null)
				return NotFound<CategoryDto>();

			return Success(_mapper.Map<CategoryDto>(category));
		}
	}
}
