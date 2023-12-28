using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Employee
{
    class ShowDataEmployee
    {
        public void RetrieveAllDataEmployee()
        {
            RetrieveAllDataEmployeeFromMySQL();
        }
        static void RetrieveAllDataEmployeeFromMySQL()
        {

            // Example: Retrieve all data from a table
            string apiUrl = "http://localhost:3000/api/employee";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string apiData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON data into a list of MyData objects
                    List<employeeModel> dataList = JsonConvert.DeserializeObject<List<employeeModel>>(apiData);
                    Console.WriteLine("+" + new string('-', 135) + "+");
                    Console.WriteLine("| ID  | Name                 | Gender   | Address               |Email               | Phone           |Birth-Date  | Position          ");
                    Console.WriteLine("+" + new string('-', 135) + "+");


                    foreach (var data in dataList)
                    {
                        //Console.WriteLine("+" + new string('-', 78) + "+");
                        Console.WriteLine($"| {data.emp_id,-3} | {data.name,-20} | {data.gender,-8} | {data.address,-21} | {data.email,-18} | {data.phone,-15} | {data.birth_date,-10} | {data.position,-8} ");
                    }
                    Console.WriteLine("+" + new string('-', 135) + "+");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

    }
}
