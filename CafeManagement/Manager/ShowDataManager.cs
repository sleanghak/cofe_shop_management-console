using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Manager
{
    class ShowDataManager
    {
        public void RetrieveAllDataManager()
        {
            RetrieveAllDataManagerFromMySQL();
        }
        static void RetrieveAllDataManagerFromMySQL()
        {

            // Example: Retrieve all data from a table
            string apiUrl = "http://localhost:3000/api/manager";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string apiData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON data into a list of MyData objects
                    List<managerModel> dataList = JsonConvert.DeserializeObject<List<managerModel>>(apiData);
                    Console.WriteLine("+" + new string('-', 115) + "+");
                    Console.WriteLine("| ID  | Name                 | Gender   | Address          |Email            | Phone           |Birth-Date    ");
                    Console.WriteLine("+" + new string('-', 115) + "+");


                    foreach (var data in dataList)
                    {
                        //Console.WriteLine("+" + new string('-', 78) + "+");
                        Console.WriteLine($"| {data.ma_id,-3} | {data.name,-20} | {data.gender,-8} | {data.address,-15} | {data.email,-3} | {data.phone,-15} | {data.birth_date,-10} ");
                    }
                    Console.WriteLine("+" + new string('-', 115) + "+");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

    }
}
