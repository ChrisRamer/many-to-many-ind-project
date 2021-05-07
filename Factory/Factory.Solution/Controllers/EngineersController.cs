using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
	public class EngineersController : Controller
	{
		private readonly FactoryContext _db;

		public EngineersController(FactoryContext db)
		{
			_db = db;
		}

		private Engineer GetEngineerFromId(int id)
		{
			return _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
		}

		public ActionResult Index()
		{
			List<Engineer> model = _db.Engineers.ToList();
			return View(model);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Engineer engineer)
		{
			_db.Engineers.Add(engineer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}