using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ReturnFromAsyncFunction
    {
        private static readonly HttpClient client = new HttpClient(); // Reuse the HttpClient instance

        // Async Main method to handle asynchronous operations properly
        static async Task Main(string[] args)
        {
            await SomeMethod(1);
        }

        // Async method returning Task to ensure proper error handling
        public static async Task SomeMethod(int id)
        {
            var retMessage = await GetData(id);
            Console.WriteLine(retMessage);
        }

        // Async method to fetch data from an external API
        public static async Task<string> GetData(int id)
        {
            string message = string.Empty;
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");

                if (response.IsSuccessStatusCode)
                {
                    message = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    message = $"Error: {response.StatusCode}";
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            return message;
        }
    }
}
