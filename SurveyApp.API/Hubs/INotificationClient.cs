using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Hubs
{
    public interface INotificationClient
    {
        Task ReceiveNotification(string message);
    }
}
