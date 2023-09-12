using AutoMapper;
using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Features.Category.Requests.Queries;
using ProductManagement.Core.Models;
using ProductManagement.Service.Services.Abstracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.Category.Handlers.Queries
{
	public class GetCategoryListQueryHandler : ResponseHandler, IRequestHandler<GetCategoryListQuery, Response<ICollection<CategoryListDto>>>
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public GetCategoryListQueryHandler(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public async Task<Response<ICollection<CategoryListDto>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
		{
			return Success<ICollection<CategoryListDto>>(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetCategories()));
		}
	}
}
