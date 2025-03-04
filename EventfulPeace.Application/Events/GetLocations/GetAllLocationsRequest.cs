using EventfulPeace.Application.Events.Dtos;
using MediatR;

namespace EventfulPeace.Application.Events.GetLocations;

public record GetAllLocationsRequest 
    : IRequest<LocationDto[]>;
