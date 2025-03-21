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
    public async Task<IActionResult> Index(string? name = null, int limit = 20, int page = 1)
        => View(model: await sender.Send(
            new GetAllEventsByLocationRequest(
                Pagination: new(limit, page),
                Name: name
            )
        ));

    [HttpGet]
    public async Task<IActionResult> Details(Guid id, CancellationToken ct = default)
        => View(model: await sender.Send(
            new GetSingleEventRequest(Id: EventId.New(id)), ct
        ));

    [HttpGet]
    public async Task<IActionResult> DownloadEventImage(Guid id, CancellationToken ct = default)
    {
        var e = await sender.Send(
            new GetSingleEventRequest(Id: EventId.New(id)), ct
        );
        return File(
            virtualPath: e.Image.Path,
            contentType: e.Image.Extension == "png" ? "image/png" : "image/jpeg"
        );
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
