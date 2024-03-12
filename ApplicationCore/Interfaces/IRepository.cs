using Ardalis.Specification;

namespace ApplicationCore.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetByIDAsync(object id);
		Task InsertAsync(TEntity entity);
		Task DeleteAsync(object id);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
		Task<TEntity?> GetItemBySpecAsync(ISpecification<TEntity> specification);
		Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
		Task SaveAsync();
	}
}
