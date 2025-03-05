using System.ComponentModel;

namespace EventfulPeace.Web.Models;

public class RegisterUserForm
{
    public Individual IndividualModel { get; set; } = new();
    public class Individual
    {
        [DisplayName("Username")]
        public string Username { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Password")]
        public string Password { get; set; } = string.Empty;
    }

    public Organization OrganizationModel { get; set; } = new();
    public class Organization
    {
        [DisplayName("Username")]
        public string Username { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Password")]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Password")]
        public string Phone { get; set; } = string.Empty;
    }
}
