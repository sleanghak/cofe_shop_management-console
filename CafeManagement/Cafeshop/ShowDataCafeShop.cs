using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Cafeshop
{
     class ShowDataCafeShop
    {
        public void RetrieveAllData()
        {
            RetrieveAllDataFromMySQL();
        }
        static void RetrieveAllDataFromMySQL()
        {

            // Example: Retrieve all data from a table
            string apiUrl = "http://localhost:3000/api/cafeshop";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string apiData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON data into a list of MyData objects
                    List<cafeshopModel> dataList = JsonConvert.DeserializeObject<List<cafeshopModel>>(apiData);
                    Console.WriteLine("+" + new string('-', 78) + "+");
                    Console.WriteLine("| ID  | City            | Address              | Date           ");
                    Console.WriteLine("+" + new string('-', 78) + "+");


                    foreach (var data in dataList)
                    {
                        //Console.WriteLine("+" + new string('-', 78) + "+");
                        Console.WriteLine($"| {data.cs_id,-3} | {data.cs_city,-15} | {data.cs_address,-20} | {data.date,-8} ");
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
