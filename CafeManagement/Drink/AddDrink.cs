using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Drink
{
    class AddDrink
    {
        public void InputDrinkFromConsole()
        {
            drinkModel dataToInsertAPI = GetInputFromConsole();

            // Call a method to insert data into MySQL API
            InsertDatatoMySQL(dataToInsertAPI);
        }
        static drinkModel GetInputFromConsole()
        {
            Console.Write("Enter  ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }

            Console.Write("Enter Name: ");
            string names = Console.ReadLine();

            Console.Write("Enter Category: ");
            string categorys = Console.ReadLine();

            Console.Write("Enter Price: ");
            double prices = Convert.ToDouble(Console.ReadLine());


            // Create a MyData object with console input
            return new drinkModel
            {
                dr_id = id,
                name = names,
                category = categorys,
                price = prices
            };
        }
        static void InsertDatatoMySQL(drinkModel data)
        {
            if (data == null)
            {
                Console.WriteLine("Invalid data. Exiting.");
                return;
            }

            // Call API to insert data into MySQL
            // Use MySqlConnection, MySqlCommand, and other MySQL components
            // Example: Insert data into a table
            string apiUrl = "http://localhost:3000/api/drink";
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
