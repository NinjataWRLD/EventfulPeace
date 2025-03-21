﻿using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Writes;
using MediatR;

namespace EventfulPeace.Application.Events.Create;

public class CreateEventUseCase(IEventWrites writes, IUnitOfWork uow)
    : IRequestHandler<CreateEventRequest, EventId>
{
    public async Task<EventId> Handle(CreateEventRequest req, CancellationToken ct)
    {
        Event entity = Event.Create(
            name: req.Name,
            description: req.Description,
            imageKey: req.Image.Key,
            imageContentType: req.Image.ContentType,
            occursAt: req.OccursAt,
            locationId: req.LocationId,
            creatorId: req.CreatorId
        );

        await writes.AddAsync(entity, ct).ConfigureAwait(false);
        await uow.SaveChangesAsync(ct).ConfigureAwait(false);

        await writes.JoinAsync(entity.Id, req.CreatorId, ct);
        await uow.SaveChangesAsync(ct).ConfigureAwait(false);

        return entity.Id;
    }
}