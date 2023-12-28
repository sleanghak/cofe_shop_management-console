using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Report
{
     class ShowDataReport
    {
        public void RetrieveAllDataReport()
        {
            RetrieveAllDataReportFromMySQL();
        }
        static void RetrieveAllDataReportFromMySQL()
        {

            // Example: Retrieve all data from a table
            string apiUrl = "http://localhost:3000/api/report";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string apiData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON data into a list of MyData objects
                    List<reportModel> dataList = JsonConvert.DeserializeObject<List<reportModel>>(apiData);
                    Console.WriteLine("+" + new string('-', 78) + "+");
                    Console.WriteLine("| ID  | Date                  | Quantity        | Report_Type     |Total_Price    ");
                    Console.WriteLine("+" + new string('-', 78) + "+");


                    foreach (var data in dataList)
                    {
                        //Console.WriteLine("+" + new string('-', 78) + "+");
                        Console.WriteLine($"| {data.re_id,-3} | {data.date,-20} | {data.quantity,-15} | {data.report_type,-15} | {data.total_price,-3}");
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
