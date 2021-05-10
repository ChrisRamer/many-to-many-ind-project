using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
	public class MachinesController : Controller
	{
		private readonly FactoryContext _db;

		public MachinesController(FactoryContext db)
		{
			_db = db;
		}

		private Machine GetMachineFromId(int id)
		{
			return _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
		}

		public ActionResult Index()
		{
			List<Machine> model = _db.Machines.ToList();
			return View(model);
		}

		public ActionResult Create()
		{
			ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
			return View();
		}

		[HttpPost]
		public ActionResult Create(Machine machine, int engineerId)
		{
			_db.Machines.Add(machine);

			if (engineerId != 0)
			{
				_db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
			}

			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}