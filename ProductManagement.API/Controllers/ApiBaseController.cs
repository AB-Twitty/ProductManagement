using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Core.Models;
using System.Net;

namespace ProductManagement.API.Controllers
{
	[ApiController]
	public class ApiBaseController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator
		{
			get => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
		}

		public ObjectResult Respond<T>(Response<T> response) where T : class
		{
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					return new OkObjectResult(response);
				case HttpStatusCode.Created:
					return new CreatedResult(string.Empty, response);
				case HttpStatusCode.Unauthorized:
					return new UnauthorizedObjectResult(response);
				case HttpStatusCode.NotFound:
					return new NotFoundObjectResult(response);
				case HttpStatusCode.BadRequest:
					return new BadRequestObjectResult(response);
				case HttpStatusCode.UnprocessableEntity:
					return new UnprocessableEntityObjectResult(response);
				default:
					return new BadRequestObjectResult(response);
			}
		}
	}
}
