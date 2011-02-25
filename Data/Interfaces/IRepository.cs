using System;
using System.Linq;

namespace Griz.Data.Interfaces
{
	public interface IRepository<T, TKey> where T : IEntity<TKey>
	{
		IUnitOfWork UnitOfWork { get; set; }

		IQueryable<T> All();
		IQueryable<T> Where(Func<T, bool> expression);

		T GetById(TKey id);

		void Save(T entity);
		TKey Add(T entity);

		void Delete(T entity);
		T DeleteById(TKey id);
	}
}




//IList<T> FindAll(IDictionary<string, object> propertyValuePairs);
//T FindOne(IDictionary<string, object> propertyValuePairs);