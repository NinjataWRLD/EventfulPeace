using EventfulPeace.Application.Events.GetAll;
using EventfulPeace.Domain.Common.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace EventfulPeace.Web.Hubs;

public class EventsHub(ISender sender) : Hub
{
    public async Task GetEvents(int page, int limit)
    {
        GetAllEventsRequest request = new(new(limit, page));
        Result<GetAllEventsDto> events = await sender.Send(request);
        await Clients.All.SendAsync("ReceiveEvents", events);
    }
}
