using SimpleApp.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SimpleApp.Application.Interfaces
{
	public interface ICategorieAppService : IDisposable
	{
		CategorieViewModel FindById(int id);

		CategorieViewModel FindByName(string name);

		IEnumerable<CategorieViewModel> GetAll();

		void Add(CategorieViewModel categorieViewModel);

		void Update(CategorieViewModel categorieViewModel);

		void Delete(int id);
	}
}
