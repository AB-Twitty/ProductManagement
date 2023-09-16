using System;
using System.Collections.Generic;

namespace ProductManagement.Core.Models
{
	public class PaginatedResponse<T> : Response<ICollection<T>> where T : class
	{
		public PaginatedResponse(int totalItems, bool succeded = true, ICollection<T> data = null,
			string message = null, int currentPage = 1, int pageSize = 10) : base(data, message)
		{
			TotalItems = totalItems;
			PageSize = pageSize;
			Succeded = succeded;
			CurrentPage = currentPage;
			TotalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
		}

		public PaginatedResponse(string message, bool succeded = true) : base(message, succeded)
		{
		}

		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public bool HasNextPage { get => CurrentPage < TotalPages; }
		public bool HasPreviuosPage { get => CurrentPage > 1; }
	}
}
