using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RuffTime.Models;

namespace RuffTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        private async Task<List<Dog>> GetDog()
        {
            var client = _httpClientFactory.CreateClient("thedogapi");

            var result = await client.GetAsync("/v1/images/search?format=json&order=RANDOM");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Dog>>(content);
            }
            return null;
        }
        private async Task<WeatherForecast> GetWeatherForecast()
        {
            var client = _httpClientFactory.CreateClient("metaweather");

            // Calling API for Toronto weather
            var result = await client.GetAsync("/api/location/4118/");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherForecast>(content);
            }
            return null;
        }

        public async Task<IActionResult> Index()
        {
            var dogModel = await GetDog();
            var weatherModel = await GetWeatherForecast();

            return View(dogModel);
        }
        public async Task<IActionResult> Weather()
        {
            var weatherModel = await GetWeatherForecast();

            return View(weatherModel);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
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
