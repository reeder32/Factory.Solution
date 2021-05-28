using System;
using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Engineer
  {
    public Engineer()
    {
      EngineerMachines = new HashSet<EngineerMachine>();
    }
    public int EngineerId { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }    
    public virtual ICollection <EngineerMachine> EngineerMachines {get; set; }

  }
}