using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PierresTreats.Models
{
  public class Patron
  {
    public Patron()
    {
      this.JoinTreatPatron = new HashSet<Checkout>();
    }
    public int PatronId { get; set; }

    [Display(Name = "Patron Name")]
    public string PatronName { get; set; }
    public virtual ICollection<Checkout> JoinTreatPatron { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}