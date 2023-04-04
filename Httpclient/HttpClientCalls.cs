using System.Net.Http;
using System.Threading.Tasks;


namespace Httpclient
{
    public class HttpClientCalls
    { 
        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:7290/api/CustomerDetails/GetAllCustomer");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Request failed with status code {response.StatusCode}");
            }
        }
    }
}