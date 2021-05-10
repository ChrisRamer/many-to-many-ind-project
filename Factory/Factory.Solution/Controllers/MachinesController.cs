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
	}
}