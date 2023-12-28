using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Cafeshop
{
    class UpdateCafeShop
    {
        public async Task UpdateDataFromMySQLAsync()
        {
            await UpdateInMySQL();
        }

        static async Task UpdateInMySQL()
        {
            //Get updated data from the console
            cafeshopModel dataToUpdate = GetUpdateDataFromConsole();

            if (dataToUpdate != null)
            {
                // Call API to update data in MySQL
                await UpdateDataInMySQLApi(dataToUpdate);
            }
        }

        static cafeshopModel GetUpdateDataFromConsole()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }

            Console.Write("Enter new City: ");
            string newCity = Console.ReadLine().Trim();

            Console.Write("Enter new Address: ");
            string newAddress = Console.ReadLine().Trim();

            Console.Write("Enter new Date (YYYY-MM-DD): ");
            DateTime newDate;
            if (!DateTime.TryParse(Console.ReadLine(), out newDate))
            {
                Console.WriteLine("Invalid date format.");
                return null;
            }

            // Create a cafeshopModel object with the updated data
            return new cafeshopModel
            {
                cs_id = id,
                cs_city = newCity,
                cs_address = newAddress,
                date = newDate
            };
        }

        static async Task UpdateDataInMySQLApi(cafeshopModel data)
        {
            // API endpoint for updating data (replace with your actual API endpoint)
            string apiUrl = $"http://localhost:3000/api/cafeshop";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    
                    string jsonData = JsonConvert.SerializeObject(data);

                    
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                   
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Data updated successfully!");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("Error: Resource not found. Please check if the data exists.");
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
