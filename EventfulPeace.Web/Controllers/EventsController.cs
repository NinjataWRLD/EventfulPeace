using EventfulPeace.Application.Events.Create;
using EventfulPeace.Application.Events.Delete;
using EventfulPeace.Application.Events.Edit;
using EventfulPeace.Application.Events.GetAll;
using EventfulPeace.Application.Events.GetLocations;
using EventfulPeace.Application.Events.GetSingle;
using EventfulPeace.Application.Events.Join;
using EventfulPeace.Application.Events.Leave;
using EventfulPeace.Application.Events.UploadImage;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Web.Extensions;
using EventfulPeace.Web.Hubs;
using EventfulPeace.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using EventId = EventfulPeace.Domain.Common.TypedIds.EventId;

namespace EventfulPeace.Web.Controllers;

[Authorize]
public class EventsController(
    ISender sender,
    IHubContext<EventsHub> hub,
    IHttpClientFactory httpClientFactory
) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(
        int createdPage = 1,
        int createdLimit = 3,
        int joinedPage = 1,
        int joinedLimit = 3,
        CancellationToken ct = default
    )
    {
        var created = await sender.Send(new GetAllEventsRequest(
                Pagination: new(createdLimit, createdPage),
                CreatorId: User.GetUserId()
            ), ct).ConfigureAwait(false);

        var joined = await sender.Send(new GetAllEventsRequest(
                Pagination: new(joinedLimit, joinedPage),
                ParticipantId: User.GetUserId()
            ), ct).ConfigureAwait(false);

        return View(model: (
            Created: new EventsModel(
                Events: [.. created.Items],
                Total: created.Count,
                Page: createdPage,
                Limit: createdLimit
            ),
            Joined: new EventsModel(
                Events: [.. joined.Items],
                Total: joined.Count,
                Page: joinedPage,
                Limit: joinedLimit
            )
        ));
    }

    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken ct = default)
    {
        var locations = await sender.Send(new GetAllLocationsRequest(), ct);
        return View(new CreateEventForm()
        {
            Locations = [.. locations.Select(l => new LocationModel(l.Id.Value, l.Name))]
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventForm form, CancellationToken ct = default)
    {
        try
        {
            UploadEventImageRequest imageRequest = new(
                EventName: form.Name,
                ContentType: form.Image.ContentType,
                FileName: form.Image.FileName
            );
            var (Key, Url) = await sender.Send(imageRequest, ct).ConfigureAwait(false);

            var success = await httpClientFactory
                .CreateClient("StorageClient")
                .UploadFileAsync(form.Image, Url, ct)
                .ConfigureAwait(false);
            if (!success) return BadRequest("Failed to upload image.");

            CreateEventRequest eventRequest = new(
                Name: form.Name,
                Description: form.Description,
                Image: (Key, form.Image.ContentType),
                OccursAt: new DateTime(
                    DateOnly.FromDateTime(form.OccursAt),
                    TimeOnly.FromDateTime(form.OccursAt),
                    DateTimeKind.Utc
                ),
                CreatorId: User.GetUserId(),
                LocationId: LocationId.New(form.LocationId)
            );
            EventId id = await sender.Send(eventRequest, ct).ConfigureAwait(false);

            await hub.Clients.All.SendAsync("EventsChanged", ct);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);

            var locations = await sender.Send(new GetAllLocationsRequest(), ct);
            form.Locations = [.. locations.Select(l => new LocationModel(l.Id.Value, l.Name))];
            return View(form);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, CancellationToken ct = default)
    {
        var e = await sender.Send(new GetSingleEventRequest(EventId.New(id)), ct);
        var locations = await sender.Send(new GetAllLocationsRequest(), ct);

        return View(new EditEventForm()
        {
            Id = id,
            Name = e.Name,
            Description = e.Description,
            OccursAt = e.OccursAt,
            LocationId = e.Location.Id.Value,
            Locations = [.. locations.Select(l => new LocationModel(l.Id.Value, l.Name))]
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditEventForm form, CancellationToken ct = default)
    {
        try
        {
            EditEventRequest request = new(
                Id: EventId.New(form.Id),
                Name: form.Name,
                Description: form.Description,
                OccursAt: new DateTime(
                    DateOnly.FromDateTime(form.OccursAt),
                    TimeOnly.FromDateTime(form.OccursAt),
                    DateTimeKind.Utc
                ),
                CreatorId: User.GetUserId(),
                LocationId: LocationId.New(form.LocationId)
            );
            await sender.Send(request, ct).ConfigureAwait(false);
            await hub.Clients.All.SendAsync("", ct);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);

            var locations = await sender.Send(new GetAllLocationsRequest(), ct);
            form.Locations = [.. locations.Select(l => new LocationModel(l.Id.Value, l.Name))];
            return View(form);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Join(Guid id, CancellationToken ct = default)
    {
        JoinEventRequest request = new(
            Id: EventId.New(id),
            ParticipantId: User.GetUserId()
        );
        await sender.Send(request, ct).ConfigureAwait(false);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(Guid id, CancellationToken ct = default)
    {
        LeaveEventRequest request = new(
            Id: EventId.New(id),
            ParticipantId: User.GetUserId()
        );
        await sender.Send(request, ct).ConfigureAwait(false);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct = default)
    {
        DeleteEventRequest request = new(
            Id: EventId.New(id),
            CreatorId: User.GetUserId()
        );
        await sender.Send(request, ct).ConfigureAwait(false);
        await hub.Clients.All.SendAsync("EventsChanged", ct);

        return RedirectToAction(nameof(Index));
    }
}
