using Coffe_ManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Drink
{
    class DeleteDataDrink
    {
        public async Task DeleteDataDrinkFromConsoleAsync()
        {
            drinkModel dataToDelete = GetDeleteDataFromConsole();

            if (dataToDelete != null)
            {
                // Call a method to delete data in MySQL API
                await DeleteDataInMySQLApi(dataToDelete);
            }
        }
        static drinkModel GetDeleteDataFromConsole()
        {
            Console.Write("Enter ID to delete: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }

            // Create a cafeshopModel object with the ID for deletion
            return new drinkModel
            {
                dr_id = id,
            };
        }

        static async Task DeleteDataInMySQLApi(drinkModel dataToDelete)
        {
            // API endpoint for deleting data 
            string apiUrl = "http://localhost:3000/api/drink2";
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    var jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(dataToDelete), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, jsonContent);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // Handle API Response
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Data deleted successfully!");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("Error: Resource not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");

                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"HTTP request error: {ex.Message}");
                }
            }
        }


    }
}
