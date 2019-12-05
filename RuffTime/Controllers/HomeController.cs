using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RuffTime.Models;

namespace RuffTime.Controllers
{
    public class HomeController : Controller
    {
        private async Task<Dog> GetDog()
        {
            // Get an instance of HttpClient from the factpry that we registered
            // in Startup.cs
            //var client = _httpClientFactory.CreateClient("thedogapi");

            // Call the API & wait for response. 
            // If the API call fails, call it again according to the re-try policy
            // specified in Startup.cs
            //var result = await client.GetAsync("/api/location/1103816/");

            //if (result.IsSuccessStatusCode)
            //{
            //    // Read all of the response and deserialise it into an instace of
            //    // WeatherForecast class
            //    var content = await result.Content.ReadAsStringAsync();
            //    return JsonConvert.DeserializeObject<Dog>(content);
            //}
            return null;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "About Us";

            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your contact page.";

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
