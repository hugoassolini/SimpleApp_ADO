using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SimpleApp.Domain.Interfaces.Services
{
	public interface ICategorieService : IDisposable
	{
		Categorie FindById(int id);

		Categorie FindByName(string name);

		List<Categorie> GetAll();

		void Add(Categorie obj);

		void Update(Categorie obj);

		void Delete(int id);
	}
}
