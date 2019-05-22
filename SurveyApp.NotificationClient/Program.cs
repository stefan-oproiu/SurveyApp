using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SurveyApp.NotificationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/notificationhub")
                .Build();

            connection
                .On<string>("ReceiveNotification", Console.WriteLine);

            connection.StartAsync().Wait();
            Console.WriteLine("Connection started");
            Console.ReadKey();
        }
    }
}
