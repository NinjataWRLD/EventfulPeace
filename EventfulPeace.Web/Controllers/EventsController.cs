using EventfulPeace.Application.Events.Create;
using EventfulPeace.Application.Events.Delete;
using EventfulPeace.Application.Events.GetAll;
using EventfulPeace.Application.Events.GetLocations;
using EventfulPeace.Web.Extensions;
using EventfulPeace.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EventId = EventfulPeace.Domain.Common.TypedIds.EventId;

namespace EventfulPeace.Web.Controllers;

[Authorize]
public class EventsController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int page, int limit, string? name, CancellationToken ct = default)
        => View(model: (
            Events: await sender.Send(new GetAllEventsRequest(
                Pagination: new(limit, page),
                CreatorId: User.GetUserId(),
                Name: name
            ), ct),
            Form: new CreateEventForm
            {
                Locations = await sender.Send(new GetAllLocationsRequest(), ct)
            }
        ));

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventForm form, CancellationToken ct = default)
    {
        try
        {
            CreateEventRequest request = new(
                Name: form.Name,
                Description: form.Description,
                OccursAt: form.OccursAt,
                CreatorId: User.GetUserId(),
                LocationId: form.LocationId
            );
            await sender.Send(request, ct).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            form.Locations = await sender.Send(new GetAllLocationsRequest(), ct);
            return View(form);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct = default)
    {
        DeleteEventRequest request = new(
            Id: EventId.New(id)
        );
        await sender.Send(request, ct).ConfigureAwait(false);
        return RedirectToAction(nameof(Index));
    }
}
