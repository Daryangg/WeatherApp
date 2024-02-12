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
        private readonly AccessWeatherService _weatherService = new AccessWeatherService();


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
