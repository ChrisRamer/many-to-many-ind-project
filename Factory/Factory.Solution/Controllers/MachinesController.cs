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

		public ActionResult Details(int id)
		{
			Machine thisMachine = GetMachineFromId(id);
			return View(thisMachine);
		}

		public ActionResult Edit (int id)
		{
			Machine thisMachine = GetMachineFromId(id);
			ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
			return View(thisMachine);
		}

		[HttpPost]
		public ActionResult Edit(Machine machine, int engineerId)
		{
			bool duplicate = _db.EngineerMachines.Any(join => join.EngineerId == engineerId && join.MachineId == machine.MachineId);

			if (engineerId != 0 && !duplicate)
			{
				_db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
			}

			_db.Entry(machine).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = machine.MachineId });
		}

		public ActionResult AddEngineer(int id)
		{
			Machine thisMachine = GetMachineFromId(id);
			ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
			return View(thisMachine);
		}

		[HttpPost]
		public ActionResult AddEngineer(Machine machine, int engineerId)
		{
			bool duplicate = _db.EngineerMachines.Any(join => join.EngineerId == engineerId && join.MachineId == machine.MachineId);

			if (engineerId != 0 && !duplicate)
			{
				_db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
			}

			_db.SaveChanges();
			return RedirectToAction("Details", new { id = machine.MachineId });
		}

		[HttpPost]
		public ActionResult DeleteEngineer(int joinId)
		{
			EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
			_db.EngineerMachines.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = joinEntry.MachineId });
		}
	}
}