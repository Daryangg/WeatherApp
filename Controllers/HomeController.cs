// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Weather_app.Models;
// using Weather_app.Services;

// namespace Weather_app.Controllers;

// public class HomeController : Controller
// {
//     private readonly ILogger<HomeController> _logger;

//     public HomeController(ILogger<HomeController> logger)
//     {
//         _logger = logger;
//     }

//     public IActionResult Index()
//     {
//         return View();
//     }

//     public IActionResult GetWeatherDetails(string location)
//     {
//         WeatherService weatherService = new WeatherService();
//         var response = weatherService.GetWwatherData(location);
//         return View("Index", response.Result.JsonData);
//     }

//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }


using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather_app.Services;

namespace Weather_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private readonly AccessWeather _weatherService = new AccessWeather();


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        public async Task<IActionResult> GetWeatherDetails(string location)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherData(location);
                if (weatherData != null)
                {
                    // En este punto, tienes acceso a las propiedades del modelo 
                    return View("Index", weatherData);
                }
                else
                {
                    return View("Index", null); // Manejar el caso de respuesta nula según sea necesario
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la solicitud
                return View("Index", null); // Manejar el caso de error según sea necesario
            }
        }
    }
}
