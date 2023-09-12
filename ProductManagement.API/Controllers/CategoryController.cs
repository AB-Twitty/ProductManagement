using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core.Features.Category.Requests.Queries;
using ProductManagement.Domain.MetaData;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet(Router.CategoryRouting.List)]
		public async Task<IActionResult> GetCategories() =>
			Ok(await _mediator.Send(new GetCategoryListQuery()));

		[HttpGet(Router.CategoryRouting.GetById)]
		public async Task<IActionResult> GetCategoryById(string id) =>
			Ok(await _mediator.Send(new GetCategoryQuery { Id = id }));
	}
}
