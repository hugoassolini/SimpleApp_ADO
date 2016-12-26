using System.Web.Mvc;

namespace SimpleApp.UI.Mvc.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}