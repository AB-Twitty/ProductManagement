using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductManagement.Core.DTOs.User;
using ProductManagement.Core.Extensions;
using ProductManagement.Core.Features.User.Requests.Queries;
using ProductManagement.Core.Models;
using ProductManagement.Identity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Core.Features.User.Handlers.Queries
{
	public class GetUserPaginatedListQueryHandler : ResponseHandler,
													IRequestHandler<GetUserPaginatedListQuery, Response<ICollection<UserListItemDto>>>
	{
		private readonly UserManager<AppUser> _userManager;

		public GetUserPaginatedListQueryHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<Response<ICollection<UserListItemDto>>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
		{
			var querable = _userManager.Users.AsQueryable()
				.Select(x => new UserListItemDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
					UserName = x.UserName,
				});

			var response = await querable.ToPaginatedList(request.CurrentPage, request.PageSize);
			response.StatusCode = System.Net.HttpStatusCode.OK;
			response.Message = "Successfull Request";

			return response;
		}
	}
}
