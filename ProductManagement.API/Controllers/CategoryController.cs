﻿using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.Features.Category.Requests.Commands;
using ProductManagement.Core.Features.Category.Requests.Queries;
using ProductManagement.Domain.MetaData;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
	[ApiController]
	public class CategoryController : ApiBaseController
	{
		[HttpGet(Router.CategoryRouting.List)]
		public async Task<IActionResult> GetCategories() =>
			Respond(await Mediator.Send(new GetCategoryListQuery()));

		[HttpGet(Router.CategoryRouting.Paginated)]
		public async Task<IActionResult> GetCategoriesPaginated([FromQuery] GetCategoryPaginatedListQuery query) =>
			Respond(await Mediator.Send(query));

		[HttpGet(Router.CategoryRouting.GetById)]
		public async Task<IActionResult> GetCategoryById([FromRoute] string id) =>
			Respond(await Mediator.Send(new GetCategoryQuery { Id = id }));

		[HttpPost(Router.CategoryRouting.Create)]
		public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto createDto) =>
			Respond(await Mediator.Send(new CreateCategoryCommand { CategoryCreateDto = createDto }));

		[HttpPut(Router.CategoryRouting.Update)]
		public async Task<IActionResult> UpdateCategory([FromBody] CategoryEditDto editDto) =>
			Respond(await Mediator.Send(new EditCategoryCommand { CategoryEditDto = editDto }));

		[HttpDelete(Router.CategoryRouting.Delete)]
		public async Task<IActionResult> DeleteCategory([FromRoute] string id) =>
			Respond(await Mediator.Send(new DeleteCategoryCommand { Id = id }));
	}
}
