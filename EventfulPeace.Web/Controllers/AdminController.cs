using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.GetAll;
using EventfulPeace.Application.Users.GetAll;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Users;
using EventfulPeace.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventfulPeace.Web.Controllers;

using static UserConstants;

[Authorize(Roles.Admin)]
public class AdminController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(
        int usersPage = 1,
        int usersLimit = 20,
        int eventsPage = 1,
        int eventsLimit = 20
    )
    {
        Pagination usersPagination = new(usersLimit, usersPage),
            eventsPagination = new(eventsLimit, eventsPage);

        GetAllUsersRequest usersRequest = new(usersPagination);
        GetAllEventsRequest eventsRequest = new(eventsPagination);

        Result<UserDto> users = await sender.Send(usersRequest).ConfigureAwait(false);
        Result<GetAllEventsDto> events = await sender.Send(eventsRequest).ConfigureAwait(false);

        return View((
            Users: new UsersModel(Users: [.. users.Items], Total: users.Count, usersPage, users.Count),
            Events: new EventsModel(Events: [.. events.Items], Total: events.Count, eventsPage, events.Count)
        ));
    }
}
