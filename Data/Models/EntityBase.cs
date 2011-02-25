using System;
using Griz.Data.Interfaces;

namespace Griz.Data.Models
{
	public class EntityBase<TKey> : IEntity<TKey>
	{
		public bool IsDeleted
		{
			get { throw new NotImplementedException(); }
		}

		public void MarkForDeletion()
		{
			throw new NotImplementedException();
		}

		public void Undelete()
		{
			throw new NotImplementedException();
		}

		public TKey Id
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public bool IsTransient
		{
			get { throw new NotImplementedException(); }
		}
	}
	
}
