using System;
using System.Collections.Generic;

namespace SimpleApp.Domain.Interfaces.Repository
{
	public interface IRepository<TEntity> : IDisposable where TEntity : class
	{
		TEntity FindById(int id);

		List<TEntity> GetAll();

		void Add(TEntity obj);

		void Update(TEntity obj);

		void Delete(int id);
	}
}
