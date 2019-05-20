using Microsoft.AspNet.SignalR.Client;
using System;

namespace SurveyApp.NotificationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnection("https://localhost:5001/notificationhub");
            connection
                .CreateHubProxy("NotificationHub")
                .On<string>("ReceiveNotification", Console.WriteLine);
            connection.Start().Wait();
            Console.WriteLine("Connection started");
            Console.ReadKey();
        }
    }
}
