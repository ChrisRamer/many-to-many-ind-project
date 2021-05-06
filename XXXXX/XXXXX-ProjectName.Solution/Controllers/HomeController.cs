using Microsoft.AspNetCore.Mvc;

namespace XXXXX-ProjectName.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet("/")]
		public ActionResult Index()
		{
			return View();
		}
	}
}