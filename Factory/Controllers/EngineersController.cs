using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
     public ActionResult Details(int id)
    {
      var engineer = _db.Engineers
      .Include(engineer => engineer.EngineerMachines)
      .ThenInclude(em => em.Machine)
      .FirstOrDefault(e => e.EngineerId == id);
      return View(engineer);
    }

    public ActionResult Delete(int id)
    {
      Engineer e = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(e);

    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var e = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(e);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var e = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "ModelName");
      return View(e);
    }

    [HttpPost]
    public ActionResult Edit(Engineer e, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = e.EngineerId, MachineId = MachineId });
      }
      _db.Entry(e).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
       [HttpPost]
    public ActionResult DeleteMachine(int machineId)
    {
      Console.WriteLine(machineId);
      var em = _db.EngineerMachines.FirstOrDefault(em => em.EngineerMachineId == machineId);
      _db.EngineerMachines.Remove(em);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}