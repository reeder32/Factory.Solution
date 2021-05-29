using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
    List<Machine> AllMachines() => _db.Machines.ToList();
    public void AddNewEngineerMachine(int machineId, int EngineerId) =>  _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId, EngineerId = EngineerId });
    public ActionResult Index() => View(AllMachines());
    
    public void DeleteReferncesWith(int id) 
    {
      List<EngineerMachine> machineIds = _db.EngineerMachines
      .Where(em => em.MachineId == id)
      .ToList();
      foreach (EngineerMachine em in machineIds)
      {
        _db.EngineerMachines.Remove(em);
        _db.SaveChanges();
      }
    }
    
     public ActionResult Create()
    {
      
      return View();
    }
    [HttpPost]
     public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Edit", new {id = machine.MachineId});
    }
     public ActionResult Details(int id)
    {
      var machine = _db.Machines
      .Include(machine => machine.EngineerMachines)
      .ThenInclude(em => em.Engineer)
      .FirstOrDefault(machine => machine.MachineId == id);
      return View(machine);
    }
    public ActionResult Delete(int id)
    {
      Machine m = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(m);

    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var m = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(m);
      _db.SaveChanges();
      DeleteReferncesWith(id);
      return RedirectToAction("Index");
    }
     public ActionResult Edit(int id)
    {
      var m = _db.Machines.FirstOrDefault(m => m.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(m);
    }

    [HttpPost]
    public ActionResult Edit(Machine m, int EngineerId)
    {
      if (EngineerId != 0)
      {
        AddNewEngineerMachine(m.MachineId, EngineerId);
      }
      _db.Entry(m).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
       [HttpPost]
    public ActionResult DeleteEngineer(int engineerMachineId, int id)
    {
      Console.WriteLine(id);
      var em = _db.EngineerMachines.FirstOrDefault(em => em.EngineerMachineId == engineerMachineId);
      _db.EngineerMachines.Remove(em);
      _db.SaveChanges();
      return RedirectToAction("Edit", new {id = id});
    }
  }
}