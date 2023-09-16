using Microsoft.EntityFrameworkCore.Storage;
using ProductManagement.Domain.Bases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.Repositories.Abstracts
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(string Id);
		Task<ICollection<T>> GetAllAsync();
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
		void RollbackTranaction();
	}
}
