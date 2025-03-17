using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Create;
using EventfulPeace.Application.Events.Delete;
using EventfulPeace.Application.Events.Edit;
using EventfulPeace.Application.Events.GetAll;
using EventfulPeace.Application.Events.GetLocations;
using EventfulPeace.Application.Events.GetSingle;
using EventfulPeace.Application.Events.Join;
using EventfulPeace.Application.Events.Leave;
using EventfulPeace.Application.Events.SetImagePath;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Web.Extensions;
using EventfulPeace.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EventId = EventfulPeace.Domain.Common.TypedIds.EventId;

namespace EventfulPeace.Web.Controllers;

[Authorize]
public class EventsController(ISender sender, IWebHostEnvironment env) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int limit = 20, string? name = null, CancellationToken ct = default)
        => View(model:
            await sender.Send(new GetAllEventsRequest(
                Pagination: new(limit, page),
                ParticipantId: User.GetUserId(),
                Name: name
            ), ct));

    [HttpGet]
    public async Task<IActionResult> Created(int page = 1, int limit = 20, string? name = null, CancellationToken ct = default)
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
                OccursAt: new DateTime(
                    DateOnly.FromDateTime(form.OccursAt),
                    TimeOnly.FromDateTime(form.OccursAt),
                    DateTimeKind.Utc
                ),
                CreatorId: User.GetUserId(),
                LocationId: LocationId.New(form.LocationId)
            );
            EventId id = await sender.Send(request, ct).ConfigureAwait(false);

            string path = await FileExtensions.UploadImageAsync(env, form.Image, $"{form.Name}-{id}");
            SetEventImagePathRequest setImageRequest = new(
                Id: id,
                Path: path
            );
            await sender.Send(setImageRequest, ct).ConfigureAwait(false);

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
        var e = await sender.Send(new GetSingleEventRequest(EventId.New(id)), ct);
        ImageDto image = e.Image;
        FileExtensions.DeleteFile(env, image.Path, image.Extension);

        DeleteEventRequest request = new(
            Id: EventId.New(id)
        );
        await sender.Send(request, ct).ConfigureAwait(false);

        return RedirectToAction(nameof(Index));
    }
}
