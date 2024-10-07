using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await SomeMethod(1);
        }

        public static async Task SomeMethod(int id)
        {
            var retMessage = await GetData(id);
            Console.WriteLine(retMessage);
        }

        public static async Task<string> GetData(int id)
        {
            string message = String.Empty;
            using (var client = new HttpClient())
            {
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
            }
            return message;
        }
    }
}