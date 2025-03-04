using EventfulPeace.Application.Events.GetAllByLocation;
using EventfulPeace.Application.Events.GetSingle;
using EventfulPeace.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EventId = EventfulPeace.Domain.Common.TypedIds.EventId;

namespace EventfulPeace.Web.Controllers;

public class HomeController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int limit = 20, int page = 1)
        => View(model: await sender.Send(
            new GetAllEventsByLocationRequest(Pagination: new(limit, page))
        ));

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(Guid id, CancellationToken ct = default)
        => View(model: await sender.Send(
            new GetSingleEventRequest(Id: EventId.New(id)), ct
        ));

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
