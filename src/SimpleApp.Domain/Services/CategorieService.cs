using SimpleApp.Domain.Entities;
using SimpleApp.Domain.Interfaces.Repository;
using SimpleApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SimpleApp.Domain.Services
{
	public class CategorieService : ICategorieService
	{
		private readonly ICategorieRepository _categorieRepository;

		public CategorieService(ICategorieRepository categorieRepository)
		{
			_categorieRepository = categorieRepository;
		}

		public Categorie FindById(int id)
		{
			return _categorieRepository.FindById(id);
		}

		public Categorie FindByName(string name)
		{
			return _categorieRepository.FindByName(name);
		}

		public List<Categorie> GetAll()
		{
			return _categorieRepository.GetAll();
		}

		public void Add(Categorie categorie)
		{
			_categorieRepository.Add(categorie);
		}

		public void Delete(int id)
		{
			_categorieRepository.Delete(id);
		}

		public void Update(Categorie categorie)
		{
			_categorieRepository.Update(categorie);
		}

		public void Dispose()
		{
			_categorieRepository.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
