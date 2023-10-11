using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductManagement.Core.Features.User.Requests.Commands;
using ProductManagement.Core.Models;
using ProductManagement.Identity.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.User.Handlers.Commands
{
	public class CreateUserCommandHandler : ResponseHandler,
											IRequestHandler<CreateUserCommand, Response<string>>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public CreateUserCommandHandler(IMapper mapper, UserManager<AppUser> userManager)
		{
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			if (await _userManager.FindByEmailAsync(request.UserDto.Email) != null)
				return BadRequest<string>("Email is Already Exists.");

			if (await _userManager.FindByNameAsync(request.UserDto.UserName) != null)
				return BadRequest<string>("Username is Already Exists.");

			var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(request.UserDto), request.UserDto.Password);

			if (!result.Succeeded)
				return BadRequest<string>(result.Errors.FirstOrDefault().Description);

			return Created<string>("User Account is Created.");
		}
	}
}
