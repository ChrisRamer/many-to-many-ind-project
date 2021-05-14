using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		public ActionResult Details(int id)
		{
			Engineer thisEngineer = _db.Engineers
				.Include(engineer => engineer.Machines)
				.ThenInclude(join => join.Machine)
				.FirstOrDefault(engineer => engineer.EngineerId == id);
			return View(thisEngineer);
		}

		public ActionResult Edit(int id)
		{
			Engineer thisEngineer = GetEngineerFromId(id);
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult Edit(Engineer engineer)
		{
			_db.Entry(engineer).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = engineer.EngineerId });
		}

		public ActionResult  Delete(int id)
		{
			Engineer thisEngineer = GetEngineerFromId(id);
			return View(thisEngineer);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Engineer thisEngineer = GetEngineerFromId(id);
			_db.Engineers.Remove(thisEngineer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddMachine(int id)
		{
			Engineer thisEngineer = GetEngineerFromId(id);
			ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult AddMachine(Engineer engineer, int machineId)
		{
			bool duplicate = _db.EngineerMachines.Any(join => join.EngineerId == engineer.EngineerId && join.MachineId == machineId);

			if (machineId != 0 && !duplicate)
			{
				_db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineer.EngineerId, MachineId = machineId});
			}

			_db.SaveChanges();
			return RedirectToAction("Details", new { id = engineer.EngineerId });
		}

		[HttpPost]
		public ActionResult DeleteMachine(int joinId)
		{
			EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
			_db.EngineerMachines.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = joinEntry.EngineerId });
		}
	}
}