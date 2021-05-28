using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using FactoryManager.Models;

namespace FactoryManager.Controllers
{
  public class EngineersController : Controller
  {
 private readonly FactoryManagerContext _db;

    public EngineersController(FactoryManagerContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Engineer> engineers = _db.Engineers.ToList();
      return View(engineers);
    }
     public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "ModelName");
      return View();
    }
    [HttpPost]
     public ActionResult Create(Engineer engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      if (MachineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}