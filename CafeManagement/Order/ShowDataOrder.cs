using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Order
{
    class ShowDataOrder
    {
        public void RetrieveAllDataOrder()
        {
            RetrieveAllDataOrderFromMySQL();
        }
        static void RetrieveAllDataOrderFromMySQL()
        {

            // Example: Retrieve all data from a table
            string apiUrl = "http://localhost:3000/api/table_order";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string apiData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON data into a list of MyData objects
                    List<orderModel> dataList = JsonConvert.DeserializeObject<List<orderModel>>(apiData);
                    Console.WriteLine("+" + new string('-', 90) + "+");
                    Console.WriteLine("| ID  | Name                 | Quantity   | Price    |Date                   |Total_Price    ");
                    Console.WriteLine("+" + new string('-', 90) + "+");


                    foreach (var data in dataList)
                    {
                        //Console.WriteLine("+" + new string('-', 78) + "+");
                        Console.WriteLine($"| {data.re_id,-3} | {data.name,-20} | {data.quantity,-10} | {data.price,-8} | {data.date,-3} | {data.total_price,-8} ");
                    }
                    Console.WriteLine("+" + new string('-', 90) + "+");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

    }
}
