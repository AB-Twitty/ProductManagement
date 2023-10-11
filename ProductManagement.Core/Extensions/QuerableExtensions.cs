using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Core.Extensions
{
	public static class QuerableExtensions
	{
		public static async Task<PaginatedResponse<T>> ToPaginatedList<T>(this IQueryable<T> querable, int currentPage = 1, int pageSize = 10)
			where T : class
		{
			if (querable == null) throw new Exception("Empty Querable");

			pageSize = pageSize <= 0 ? 10 : pageSize;
			currentPage = currentPage <= 0 || currentPage > querable.Count() / pageSize ? 1 : currentPage;


			return new PaginatedResponse<T>
			(
				data: await querable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(),
				currentPage: currentPage,
				pageSize: pageSize,
				totalItems: querable.Count()
			);
		}
	}
}
