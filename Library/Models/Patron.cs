using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
  public class Patron
  {
    public int PatronId { get; set; }

    [Required(ErrorMessage = "You must provide a name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "You must provide a phone number.")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
    public string PhoneNumber { get; set; }
    public List<Checkout> JoinClasses { get; }

  }
}