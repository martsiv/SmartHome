using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

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

		public virtual IEnumerable<TEntity> GetAll()
		{
			return dbSet.ToList();
		}
		public virtual TEntity GetByID(object id)
		{
			return dbSet.Find(id);
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
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

		public void Save()
		{
			context.SaveChanges();
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
