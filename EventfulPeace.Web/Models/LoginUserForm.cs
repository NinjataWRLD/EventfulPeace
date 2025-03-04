using System.ComponentModel;

namespace EventfulPeace.Web.Models;

public class LoginUserForm
{
    [DisplayName("Username")]
    public string Username { get; set; } = string.Empty;

    [DisplayName("Password")]
    public string Password { get; set; } = string.Empty;

    [DisplayName("Remember Me")]
    public bool RememberMe { get; set; }
}
