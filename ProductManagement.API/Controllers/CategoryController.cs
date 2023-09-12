using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.MetaData;
using System;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
	[ApiController]
	public class CategoryController : ControllerBase
	{


		[HttpGet(Router.CategoryRouting.List)]
		public Task<IActionResult> GetCategories() =>
			throw new NotImplementedException();

		[HttpGet(Router.CategoryRouting.GetById)]
		public Task<IActionResult> GetCategoryById(string id) =>
			throw new NotImplementedException();
	}
}
