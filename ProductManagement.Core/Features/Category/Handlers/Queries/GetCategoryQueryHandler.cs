using AutoMapper;
using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Features.Category.Requests.Queries;
using ProductManagement.Service.Services.Abstracts;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.Category.Handlers.Queries
{
	public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public GetCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
		{
			return _mapper.Map<CategoryDto>(await _categoryService.GetCategoryById(request.Id));
		}
	}
}
