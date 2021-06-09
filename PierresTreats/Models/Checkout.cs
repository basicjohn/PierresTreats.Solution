namespace PierresTreats.Models
{
  public class Checkout
  {
    public int CheckoutId { get; set; }
    public int PatronId { get; set; }
    public int TreatId { get; set; }
    public virtual Patron Patron { get; set; }
    public virtual Treat Treat { get; set; }
  }
}