using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinEntities = new HashSet<FlavorTreat>();
    }
    public int TreatId { get; set; }
    // Fiction or non-Fiction
    [Display(Name = "Flavor Profile")]
    public string FlavorName { get; set; }
    // Types of Fiction or non-Fiction
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<FlavorTreat> JoinEntities { get; }

  }
}