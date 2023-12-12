namespace Library.Models
{
  public class Checkout
  {
    public int CheckoutId { get; set; }
    public int PatronId { get; set; }
    public Patron Patron { get; set; }
    public int BookId { get; set; }
    public int CheckoutDate { get; set; }
    public int DueDate { get; set; }
    public Book Book { get; set; }

  }
}