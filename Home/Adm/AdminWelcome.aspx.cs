using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web.UI; // Added for Page reference
using System.Web.UI.WebControls; // Added for Label references

namespace Dormitory_Management_System.Home.Adm {
    public partial class Welcome : System.Web.UI.Page {
        protected Label lblWeather; // Added declaration for lblWeather
        protected Label lblTemperature; // Added declaration for lblTemperature

        protected async Task Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                await GetWeatherDataAsync();
            }
        }

        private async Task GetWeatherDataAsync() {
            string apiKey = "a223eb0f7d99982c34d6e109d3ee34be";  // Replace with your actual API key
            string city = "London"; // Replace with the desired city name
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={apiKey}";

            using (HttpClient client = new HttpClient()) {
                try {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    dynamic data = JObject.Parse(responseBody);
                    string weather = data.weather[0].description;
                    string temperature = data.main.temp;

                    lblWeather.Text = $"Weather: {weather}";
                    lblTemperature.Text = $"Temperature: {temperature} °C";

                    lblWeather.DataBind(); // Ensure the labels are updated
                    lblTemperature.DataBind(); // Ensure the labels are updated
                } catch (HttpRequestException ex) {
                    lblWeather.Text = "Weather: Unable to load";
                    lblTemperature.Text = "Temperature: Unable to load";
                    Console.WriteLine($"Request error: {ex.Message}");

                    lblWeather.DataBind(); // Ensure the labels are updated
                    lblTemperature.DataBind(); // Ensure the labels are updated
                } catch (Exception ex) {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
    }
}
