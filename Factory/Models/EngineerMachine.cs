using System;
using System.Collections.Generic;
namespace Factory.Models
{
  public class EngineerMachine
  {
    public int EngineerMachineId { get; set; }
    public int EngineerId { get; set; }
    public int FactoryId { get; set; }
    public virtual Engineer Engineer {get; set;}
    public virtual Factory Factory { get; set; }
  }
}