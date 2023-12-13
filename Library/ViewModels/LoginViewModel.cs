using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Are you a librarian or patron?")]
    public bool Librarian { get; set; }
  }
}