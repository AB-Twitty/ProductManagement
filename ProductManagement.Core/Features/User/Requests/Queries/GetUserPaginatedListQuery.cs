using MediatR;
using ProductManagement.Core.DTOs.User;
using ProductManagement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core.Features.User.Requests.Queries
{
	public class GetUserPaginatedListQuery : IRequest<Response<ICollection<UserListItemDto>>>
	{
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public string? Search { get; set; }
	}
}
