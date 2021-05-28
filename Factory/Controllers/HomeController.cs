using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using FactoryManager.Models;


namespace FactoryManager.Controllers
{
  public class HomeController : Controller
  {

     private readonly FactoryManagerContext _db;

    public HomeController(FactoryManagerContext db)
    {
      _db = db;
    }

   
    public ActionResult Index()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Engineer> engineers = _db.Engineers.ToList();
      List<Machine> machines = _db.Machines.ToList();
      model.Add("engineers", engineers);
      model.Add("machines", machines);
      return View(model);
    }
  }
}