using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Drink
{
     class ShowDataDrink
    {
        public void RetrieveAllDataDrink()
        {
            RetrieveAllDataDrinkFromMySQL();
        }
        static void RetrieveAllDataDrinkFromMySQL()
        {

            // Example: Retrieve all data from a table
            string apiUrl = "http://localhost:3000/api/drink";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string apiData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON data into a list of MyData objects
                    List<drinkModel> dataList = JsonConvert.DeserializeObject<List<drinkModel>>(apiData);
                    Console.WriteLine("+" + new string('-', 78) + "+");
                    Console.WriteLine("| ID   | Name                | Category        | Price           ");
                    Console.WriteLine("+" + new string('-', 78) + "+");


                    foreach (var data in dataList)
                    {
                        //Console.WriteLine("+" + new string('-', 78) + "+");
                        Console.WriteLine($"| {data.dr_id,-3} | {data.name,-20} | {data.category,-15} | {data.price,-8} ");
                    }
                    Console.WriteLine("+" + new string('-', 78) + "+");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

    }
}
