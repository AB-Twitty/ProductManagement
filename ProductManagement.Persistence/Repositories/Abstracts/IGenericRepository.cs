using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.Repositories.Abstracts
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(string Id);
		Task<T> AddAsync(T entity);
		Task AddRangeAsync(ICollection<T> entities);
		Task UpdateAsync(T entity);
		Task UpdateRangeAsync(ICollection<T> entities);
		Task DeleteAsync(T entity);
		Task DeleteRangeAsync(ICollection<T> entities);
		IQueryable<T> GetTableNoTracking();
		IQueryable<T> GetTableAsTracking();
		IDbContextTransaction BeginTransaction();
		void CommitTransaction();
		void RollBackTranaction();
	}
}
