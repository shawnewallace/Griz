using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Griz.Data.Interfaces;
using Griz.Data.Models;

namespace Griz.Data.Repositories
{
	public class EfRepository<T, TKey> : IRepository<T, TKey>
	where T : class, IEntity<TKey>
	{
		public IUnitOfWork UnitOfWork { get; set; }

		private IDbSet<T> _objectset;
		private IDbSet<T> ObjectSet
		{
			get { return _objectset ?? (_objectset = UnitOfWork.Context.Set<T>()); }
		}

		public IQueryable<T> All()
		{
			return ObjectSet.AsQueryable();
		}

		public IQueryable<T> Where(Func<T, bool> expression)
		{
			return ObjectSet.Where(expression).AsQueryable();
		}

		public T GetById(TKey id)
		{
			return Where(e => e.Id.Equals(id)).First();
		}

		public void Save(T entity)
		{
			throw new NotImplementedException();
		}

		public TKey Add(T entity)
		{
			var x = ObjectSet.Add(entity);
			return x.Id;
		}

		public void Delete(T entity)
		{
			ObjectSet.Remove(entity);
		}

		public T DeleteById(TKey id)
		{
			throw new NotImplementedException();
		}
	}
}
