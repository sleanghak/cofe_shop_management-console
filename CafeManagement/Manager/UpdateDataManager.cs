using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Manager
{
    class UpdateDataManager
    {
        public async Task UpdateManagerDataFromMySQLAsync()
        {
            await UpdateManagerInMySQL();
        }

        static async Task UpdateManagerInMySQL()
        {
            //Get updated data from the console
            managerModel dataToUpdate = GetUpdateDataFromConsole();

            if (dataToUpdate != null)
            {
                // Call API to update data in MySQL
                await UpdateManagerDataInMySQLApi(dataToUpdate);
            }
        }

        static managerModel GetUpdateDataFromConsole()
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

            Console.Write("Enter new Gender: ");
            string newGender = Console.ReadLine();

            Console.Write("Enter new Address: ");
            string newAddress = Console.ReadLine();

            Console.Write("Enter new Email: ");
            string newEmail = Console.ReadLine();

            Console.Write("Enter new Phone: ");
            string newPhone = Console.ReadLine();

            Console.Write("Enter new Birth-Date: ");
            string newBirthDate = Console.ReadLine();


            // Create a cafeshopModel object with the updated data
            return new managerModel
            {
                ma_id = id,
                name = newName,
                gender = newGender,
                address = newAddress,
                email = newEmail,
                phone = newPhone,
                birth_date = newBirthDate,
               


            };
        }

        static async Task UpdateManagerDataInMySQLApi(managerModel data)
        {
            // API endpoint for updating data (replace with your actual API endpoint)
            string apiUrl = $"http://localhost:3000/api/manager";

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
