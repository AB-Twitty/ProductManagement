using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core.DTOs.User;
using ProductManagement.Core.Features.User.Requests.Commands;
using ProductManagement.Domain.MetaData;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
	[ApiController]
	public class UserController : ApiBaseController
	{
		[HttpPost(Router.UserRouting.Create)]
		public async Task<IActionResult> Create([FromBody] CreateUserDto user) =>
			Respond(await Mediator.Send(new CreateUserCommand { UserDto = user }));
	}
}
