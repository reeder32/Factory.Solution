using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using FactoryManager.Models;

namespace FactoryManager.Controllers
{
  public class MachinesController : Controller
  {
 private readonly FactoryManagerContext _db;

    public MachinesController(FactoryManagerContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Machine> machines = _db.Machines.ToList();
      return View(machines);
    }
     public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }
    [HttpPost]
     public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      if (EngineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machine.MachineId, EngineerId = EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     public ActionResult Details(int id)
    {
     
      return View();
    }
  }
}