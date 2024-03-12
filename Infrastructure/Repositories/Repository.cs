using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		internal ApplicationContext context;
		internal DbSet<TEntity> dbSet;

		public Repository(ApplicationContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}
		public virtual async Task<TEntity> GetByIDAsync(object id)
		{
			return await dbSet.FindAsync(id);
		}

		public virtual async Task InsertAsync(TEntity entity)
		{
			await dbSet.AddAsync(entity);
		}

		public virtual async Task DeleteAsync(object id)
		{
			TEntity entityToDelete = await dbSet.FindAsync(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public async Task SaveAsync()
		{
			await context.SaveChangesAsync();
		}

		// working with specifications
		public async Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification)
		{
			return await ApplySpecification(specification).ToListAsync();
		}

		public async Task<TEntity?> GetItemBySpecAsync(ISpecification<TEntity> specification)
		{
			return await ApplySpecification(specification).FirstOrDefaultAsync();
		}

		private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
		{
			var evaluator = new SpecificationEvaluator();
			return evaluator.GetQuery(dbSet, specification);
		}
	}
}
