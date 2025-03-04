using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Web.Models;

public class CreateEventForm
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime OccursAt { get; set; }
    public LocationId LocationId { get; set; }
    public LocationDto[] Locations { get; set; } = [];
};
