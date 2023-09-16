using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProductManagement.Domain.Bases;
using ProductManagement.Persistence.Context;
using ProductManagement.Persistence.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly ProductDbContext _context;

		public GenericRepository(ProductDbContext context)
		{
			_context = context;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task AddRangeAsync(ICollection<T> entities)
		{
			await _context.Set<T>().AddRangeAsync(entities);
			await _context.SaveChangesAsync();
		}

		public IDbContextTransaction BeginTransaction()
		{
			return _context.Database.BeginTransaction();
		}

		public void CommitTransaction()
		{
			_context.Database.CommitTransaction();
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteRangeAsync(ICollection<T> entities)
		{
			_context.RemoveRange(entities);
			await _context.SaveChangesAsync();
		}

		public async Task<ICollection<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(string Id)
		{
			return await _context.Set<T>().AsNoTracking().Where(x => x.Id.Equals(Guid.Parse(Id))).FirstOrDefaultAsync();
		}

		public IQueryable<T> GetTableAsTracking()
		{
			return _context.Set<T>().AsTracking();
		}

		public IQueryable<T> GetTableNoTracking()
		{
			return _context.Set<T>().AsNoTracking();
		}

		public void RollbackTranaction()
		{
			_context.Database.RollbackTransaction();
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateRangeAsync(ICollection<T> entities)
		{
			_context.Set<T>().UpdateRange(entities);
			await _context.SaveChangesAsync();
		}
	}
}
