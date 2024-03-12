using Ardalis.Specification;

namespace ApplicationCore.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> GetAll();
		TEntity GetByID(object id);
		void Insert(TEntity entity);
		void Delete(object id);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
		Task<TEntity?> GetItemBySpecAsync(ISpecification<TEntity> specification);
		Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
		void Save();
	}
}
