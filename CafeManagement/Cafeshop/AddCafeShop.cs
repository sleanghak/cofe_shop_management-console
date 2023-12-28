using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Cafeshop
{
    class AddCafeShop
    {

        public void InputFromConsole()
        {
            cafeshopModel dataToInsert = GetInputFromConsole();

            // Call a method to insert data into MySQL API
            InserttoMySQL(dataToInsert);
        }
        static cafeshopModel GetInputFromConsole()
        {
            Console.Write("Enter ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }

            Console.Write("Enter City: ");
            string city = Console.ReadLine().Trim();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine().Trim();

            Console.Write("Enter Date (YYYY-MM-DD): ");
            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Invalid date format.");
                return null;
            }

            // Create a MyData object with console input
            return new cafeshopModel
            {
                cs_id = id,
                cs_city = city,
                cs_address = address,
                date = date
            };
        }
        static void InserttoMySQL(cafeshopModel data)
        {
            if (data == null)
            {
                Console.WriteLine("Invalid data. Exiting.");
                return;
            }

            // Call API to insert data into MySQL
            // Use MySqlConnection, MySqlCommand, and other MySQL components
            // Example: Insert data into a table
            string apiUrl = "http://localhost:3000/api/cafeshop";
            using (HttpClient client = new HttpClient())
            {
                // Serialize MyData object to JSON
                string jsonData = JsonConvert.SerializeObject(data);

                // Prepare content for the POST request
                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                // Send POST request to the API
                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data inserted successfully!");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }


    }
}
