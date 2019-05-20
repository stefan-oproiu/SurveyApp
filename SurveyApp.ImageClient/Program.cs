using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SurveyApp.ImageClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new Task(() => Work()).Start();

            Console.ReadKey();
        }

        static async Task Work()
        {
            var baseUrl = "https://localhost:6001/api/images";
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, baseUrl));
            var strings = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<string>>(strings);
            list.ForEach(name =>
            {
                new Task(() => {
                    var client = new WebClient();
                    client.DownloadFile(new Uri($"{baseUrl}/{name}"), $"{name}.jpg");
                    Console.WriteLine($"Downloaded {name}");
                }).Start();
            });
        }
    }
}
