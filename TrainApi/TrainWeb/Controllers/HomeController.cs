using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrainWeb.Models;

namespace TrainWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Foo()
        //{
        //    var message = new HttpRequestMessage();
        //    message.Method = HttpMethod.Get;
        //    message.RequestUri = new Uri ($"{BASE_URI}/api/hello");
        //    message.Headers.Add("Accept", "application/json");
        //    var client = _clientFactory.CreateClient();
        //    var response = await client.SendAsync(message);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        Students = await JsonSerializer.DeserializeAsync<IEnumerable<Student>>(responseStream);
        //    }
        //    else
        //    {
        //        GetStudentsError = true;
        //        Students = Array.Empty<Student>();
        //    }

        //    return View(Students);
        //}

        public async Task<IActionResult> Bar()
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri($"https://localhost:44365/api/Hello");
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code->" + statusCode);
            Console.WriteLine("Satus Code =>" + (int)statusCode);

            //Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the Connection
            httpClient.Dispose();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
