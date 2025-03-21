using EventfulPeace.Application.Events.GetAll;

namespace EventfulPeace.Web.Models;

public record EventsModel(
    GetAllEventsDto[] Events,
    int Total,
    int Page = 1,
    int Limit = 5
);
