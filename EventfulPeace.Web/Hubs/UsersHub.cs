using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Users.GetAll;
using EventfulPeace.Domain.Common.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace EventfulPeace.Web.Hubs;

public class UsersHub(ISender sender) : Hub
{
    public async Task GetUsers(int page, int limit)
    {
        GetAllUsersRequest request = new(new(limit, page));
        Result<UserDto> users = await sender.Send(request);
        await Clients.All.SendAsync("ReceiveUsers", users);
    }
}
