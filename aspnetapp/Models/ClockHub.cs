using aspnetapp.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace aspnetapp.Models
{
    public class ClockHub : Hub<IClock>
    {
        public async Task SendTimeToClients(DateTime dateTime)
        {
            await Clients.All.ShowTime(dateTime);
        }
    }
}
