using MediatR;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Extensions;
using ProductManagement.Core.Features.Category.Requests.Queries;
using ProductManagement.Core.Models;
using ProductManagement.Service.Services.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.Category.Handlers.Queries
{
	public class GetCategoryPaginatedListQueryHandler : ResponseHandler,
														IRequestHandler<GetCategoryPaginatedListQuery, Response<ICollection<CategoryListDto>>>
	{
		private readonly ICategoryService _categoryService;

		public GetCategoryPaginatedListQueryHandler(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<Response<ICollection<CategoryListDto>>> Handle(GetCategoryPaginatedListQuery request, CancellationToken cancellationToken)
		{
			var querable = _categoryService.GetQuerableForPagination(request.Search)
								.Select(x => new CategoryListDto { Id = x.Id.ToString(), Name = x.Name });

			var response = await querable.ToPaginatedList(request.CurrentPage, request.PageSize);
			response.StatusCode = System.Net.HttpStatusCode.OK;
			response.Message = "Successfull Request";

			return response;

		}
	}
}
