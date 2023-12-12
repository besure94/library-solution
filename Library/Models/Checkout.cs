using System;

namespace Library.Models

{
  public class Checkout
  {
    public int CheckoutId { get; set; }
    public int PatronId { get; set; }
    public Patron Patron { get; set; }
    public int BookId { get; set; }
    public DateTime CheckoutDate { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);
    public Book Book { get; set; }

  }
}