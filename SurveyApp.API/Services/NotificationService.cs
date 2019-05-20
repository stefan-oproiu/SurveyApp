using Microsoft.AspNetCore.SignalR;
using SurveyApp.API.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task Send(string message)
        {
            return hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
