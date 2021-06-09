using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinFlavorTreat = new HashSet<FlavorTreat>();
      this.JoinTreatPatron = new HashSet<Checkout>();
    }
    public int TreatId { get; set; }
    // Fiction or non-Fiction
    [Display(Name = "Category")]
    public string Category { get; set; }
    // Types of Fiction or non-Fiction
    [Display(Name = "Category Type")]
    public string SubCategory { get; set; }

    [Display(Name = "Treat Title")]
    public string TreatTitle { get; set; }

    [Display(Name = "Tag Line")]
    public string Tagline { get; set; }

    [Display(Name = "Treat Description")]
    public string Synopsis { get; set; }

    [Display(Name = "Publication Date")]
    public DateTime DatePublished { get; set; } = DateTime.Today;

    [Display(Name = "Treat Availability")]
    public int TreatStock { get; set; } = 1;
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<FlavorTreat> JoinFlavorTreat { get; }
    public virtual ICollection<Checkout> JoinTreatPatron { get; }

  }
}