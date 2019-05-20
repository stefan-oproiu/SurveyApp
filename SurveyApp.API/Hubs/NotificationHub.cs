using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessage(string message)
        {
            return Clients.All.SendAsync(message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("A client connected");
            return base.OnConnectedAsync();
        }
    }
}
