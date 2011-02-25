using System;
using System.Data.Objects;
using System.Data.Entity;
using Griz.Data.Interfaces;

namespace Griz.Data.Repositories
{
	public class EfUnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public EfUnitOfWork()
		{
			//Context = new DataModel();
		}

		public void Commit()
		{
			Context.SaveChanges();
		}
		
		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}

		public void Dispose()
		{
			Context.Dispose();
		}
		
	}
}
