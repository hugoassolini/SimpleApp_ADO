using SimpleApp.Application.Interfaces;
using SimpleApp.Application.ViewModels;
using System.Net;
using System.Web.Mvc;

namespace SimpleApp.UI.Mvc.Controllers
{
	public class CategorieController : Controller
	{
		private readonly ICategorieAppService _categorieAppService;

		public CategorieController(ICategorieAppService categorieAppService)
		{
			_categorieAppService = categorieAppService;
		}

		// GET: Categorie
		public ActionResult Index()
		{
			return View(_categorieAppService.GetAll());
		}

		// GET: Categorie/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CategorieViewModel categorieViewModel = _categorieAppService.FindById(id.Value);
			if (categorieViewModel == null)
			{
				return HttpNotFound();
			}
			return View(categorieViewModel);
		}

		// GET: Categorie/Create
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Description")] CategorieViewModel categorieViewModel)
		{
			if (ModelState.IsValid)
			{
				_categorieAppService.Add(categorieViewModel);
				return RedirectToAction("Index");
			}

			return View(categorieViewModel);
		}

		// GET: Categorie/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CategorieViewModel categorieViewModel = _categorieAppService.FindById(id.Value);
			if (categorieViewModel == null)
			{
				return HttpNotFound();
			}
			return View(categorieViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Description")] CategorieViewModel categorieViewModel)
		{
			if (ModelState.IsValid)
			{
				_categorieAppService.Update(categorieViewModel);
				return RedirectToAction("Index");
			}
			return View(categorieViewModel);
		}

		// GET: Categorie/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CategorieViewModel categorieViewModel = _categorieAppService.FindById(id.Value);
			if (categorieViewModel == null)
			{
				return HttpNotFound();
			}
			return View(categorieViewModel);
		}

		// POST: Categorie/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_categorieAppService.Delete(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_categorieAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
