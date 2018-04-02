using System;
using System.Collections.Generic;

namespace CheckoutTomasRito.DataAccess.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		TEntity Get();
		void Add(TEntity entity);
		void Delete(TEntity entity);
		void Save(TEntity entity);
	}
}
