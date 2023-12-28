using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Drink
{
    class UpdateDataDrink
    {
        public async Task UpdateDrinkDataFromMySQLAsync()
        {
            await UpdateDrinkInMySQL();
        }

        static async Task UpdateDrinkInMySQL()
        {
            //Get updated data from the console
            drinkModel dataToUpdate = GetUpdateDataFromConsole();

            if (dataToUpdate != null)
            {
                // Call API to update data in MySQL
                await UpdateDrinkDataInMySQLApi(dataToUpdate);
            }
        }

        static drinkModel GetUpdateDataFromConsole()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }

            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter new Category: ");
            string newCategory = Console.ReadLine();

            Console.Write("Enter new Price: ");
            double newPrice;
            if (double.TryParse(Console.ReadLine(), out newPrice))
            {
                // Use the newPrice variable for further processing
            }
            else
            {
                Console.WriteLine("Invalid input for Price. Please enter a valid numeric value.");
            }

            // Create a cafeshopModel object with the updated data
            return new drinkModel
            {
                dr_id = id,
                name = newName,
                category = newCategory,
                price = newPrice
            };
        }

        static async Task UpdateDrinkDataInMySQLApi(drinkModel data)
        {
            // API endpoint for updating data (replace with your actual API endpoint)
            string apiUrl = $"http://localhost:3000/api/drink";

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
