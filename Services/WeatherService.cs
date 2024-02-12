using Flurl.Http;
using Weather_app.Models;

namespace Weather_app.Services

{
    public class WeatherService
    {
        public async Task<ResponseModel> GetWwatherData(string location)
        {
            string apiURL = AppConstans.WeatherApiUrl;
            string apiKey = AppConstans.WeatherApiKey;
            //  string url = $"{apiURL}{apiKey}&q={location}";
            string url = "http://api.weatherapi.com/v1/current.json?key=956a75f60e2c49188ee175638241102&q=Miami";

            try
            {
                var response = await url.GetAsync();

                if (response.StatusCode == 200)
                {
                    var responseData = await response.GetJsonAsync<WeatherModel>();
                    return ResponseModel.Succes(responseData);
                }
                return ResponseModel.Error(response.ResponseMessage.ToString());
            }
            catch (FlurlHttpException ex)
            {
                return ResponseModel.Error("Error de respuesta");
            }
        }
    }
}