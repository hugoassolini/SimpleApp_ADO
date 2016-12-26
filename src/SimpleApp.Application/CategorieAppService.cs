using SimpleApp.Application.Interfaces;
using SimpleApp.Application.ViewModels;
using SimpleApp.Domain.Entities;
using SimpleApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SimpleApp.Application
{
	public class CategorieAppService : ICategorieAppService
	{
		private readonly ICategorieService _categorieService;

		public CategorieAppService(ICategorieService categorieService)
		{
			_categorieService = categorieService;
		}

		public void Add(CategorieViewModel categorieViewModel)
		{
			Categorie categorie = new Categorie()
			{
				CategoryName = categorieViewModel.Name,
				Description = categorieViewModel.Description
			};

			_categorieService.Add(categorie);
		}

		public void Delete(int id)
		{
			_categorieService.Delete(id);
		}

		public CategorieViewModel FindById(int id)
		{
			Categorie categorie = _categorieService.FindById(id);
			CategorieViewModel categorieViewModel = new CategorieViewModel() { Id = categorie.CategoryID, Name = categorie.CategoryName, Description = categorie.Description };

			return categorieViewModel;
		}

		public CategorieViewModel FindByName(string name)
		{
			Categorie categorie = _categorieService.FindByName(name);
			CategorieViewModel categorieViewModel = new CategorieViewModel() { Id = categorie.CategoryID, Name = categorie.CategoryName, Description = categorie.Description };

			return categorieViewModel;
		}

		public IEnumerable<CategorieViewModel> GetAll()
		{
			List<Categorie> listCategorie = _categorieService.GetAll();
			List<CategorieViewModel> listCategorieViewModel = new List<CategorieViewModel>();

			CategorieViewModel categorieViewModel;

			foreach (var categorie in listCategorie)
			{
				categorieViewModel = new CategorieViewModel() { Id = categorie.CategoryID, Name = categorie.CategoryName, Description = categorie.Description };
				listCategorieViewModel.Add(categorieViewModel);
			}

			return listCategorieViewModel;
		}

		public void Update(CategorieViewModel categorieViewModel)
		{
			Categorie categorie = new Categorie()
			{
				CategoryID = categorieViewModel.Id,
				CategoryName = categorieViewModel.Name,
				Description = categorieViewModel.Description
			};

			_categorieService.Update(categorie);
		}

		public void Dispose()
		{
			_categorieService.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
