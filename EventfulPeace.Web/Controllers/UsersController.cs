using EventfulPeace.Application.Users.Login;
using EventfulPeace.Application.Users.Logout;
using EventfulPeace.Application.Users.RegisterIndividual;
using EventfulPeace.Application.Users.RegisterOrganization;
using EventfulPeace.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventfulPeace.Web.Controllers;

[Route("Users")]
public class UsersController(ISender sender) : Controller
{
    private RedirectToActionResult RedirectToHome()
        => RedirectToAction("Index", "Home");

    [HttpGet("Register")]
    public IActionResult Register()
        => View(new RegisterUserForm());

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserForm form, CancellationToken ct = default)
    {
        try
        {
            RegisterIndividualRequest request = new(
                Username: form.Username,
                Password: form.Password,
                Email: form.Email
            );
            await sender.Send(request, ct).ConfigureAwait(false);
            return RedirectToHome();
        }
        catch
        {
            return View();
        }
    }

    [HttpPost("Register/{phone}")]
    public async Task<IActionResult> Register(string phone, RegisterUserForm form, CancellationToken ct = default)
    {
        try
        {
            RegisterOrganizationRequest request = new(
                Username: form.Username,
                Password: form.Password,
                Email: form.Email,
                Phone: phone
            );
            await sender.Send(request, ct).ConfigureAwait(false);
            return RedirectToHome();
        }
        catch
        {
            return View();
        }
    }

    [HttpGet("Login")]
    public IActionResult Login()
        => View(new LoginUserForm());

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserForm form, CancellationToken ct = default)
    {
        try
        {
            LoginUserRequest request = new(
                Username: form.Username,
                Password: form.Password,
                RememberMe: form.RememberMe
            );
            await sender.Send(request, ct).ConfigureAwait(false);
            return RedirectToHome();

        }
        catch (Exception)
        {
            return View();
        }
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout(CancellationToken ct = default)
    {
        LogoutUserRequest request = new();
        await sender.Send(request, ct).ConfigureAwait(false);
        return RedirectToHome();
    }
}
