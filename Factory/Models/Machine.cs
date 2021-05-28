using System;
using System.Collections.Generic;
namespace FactoryManager.Models
{
  public class Machine
  {
     public Machine()
    {
      EngineerMachines = new HashSet<EngineerMachine>();
    }
    public int MachineId { get; set; }
    public string ModelName { get; set; }
    public string Details { get; set; }  
    public virtual ICollection <EngineerMachine> EngineerMachines {get; set; }
  }
}