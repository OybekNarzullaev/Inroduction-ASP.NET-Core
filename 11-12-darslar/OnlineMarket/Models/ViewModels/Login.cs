
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models;
public class LoginViewModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
