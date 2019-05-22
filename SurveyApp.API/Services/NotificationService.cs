using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor contextAccessor;

        public NotificationService(IHubContext<NotificationHub> hubContext, IHttpContextAccessor contextAccessor)
        {
            this.hubContext = hubContext;
            this.contextAccessor = contextAccessor;
        }

        public Task Send(string message)
        {
            return hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
        public string UserName { get => contextAccessor.HttpContext.User.Claims.First(c => c.Type == "name").Value; }
    }
}
