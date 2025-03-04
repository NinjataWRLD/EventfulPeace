using System.ComponentModel;

namespace EventfulPeace.Web.Models;

public class RegisterUserForm
{
    [DisplayName("Username")]
    public string Username { get; set; } = string.Empty;

    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Password")]
    public string Password { get; set; } = string.Empty;
}
