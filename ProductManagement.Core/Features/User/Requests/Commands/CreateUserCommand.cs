using MediatR;
using ProductManagement.Core.DTOs.User;
using ProductManagement.Core.Models;

namespace ProductManagement.Core.Features.User.Requests.Commands
{
	public class CreateUserCommand : IRequest<Response<string>>
	{
		public CreateUserDto UserDto { get; set; }
	}
}
