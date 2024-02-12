namespace Weather_app.Services;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather_app.Models;

public class AccessWeather
{
    private const string WeatherApiBaseUrl = "http://api.weatherapi.com/v1";
    private readonly HttpClient _httpClient;

    public AccessWeather()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(WeatherApiBaseUrl) };
    }

    public async Task<WeatherModel> GetWeatherData(string location)
    {
        try
        {
            string apiKey = "956a75f60e2c49188ee175638241102";
            string endpoint = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                WeatherModel weatherData = JsonConvert.DeserializeObject<WeatherModel>(json);
                return weatherData;
            }
            else
            {
                // Manejar el caso de respuesta no exitosa según sea necesario
                Console.WriteLine($"Error al obtener los datos del clima. Código de estado: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción que ocurra durante la solicitud
            Console.WriteLine($"Error al obtener los datos del clima: {ex.Message}");
            return null;
        }
    }
}
