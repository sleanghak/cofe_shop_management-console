using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Report
{
    class UpdateDataReport
    {
        public async Task UpdateReportDataFromMySQLAsync()
        {
            await UpdateReportInMySQL();
        }

        static async Task UpdateReportInMySQL()
        {
            //Get updated data from the console
            reportModel dataToUpdate = GetUpdateDataFromConsole();

            if (dataToUpdate != null)
            {
                // Call API to update data in MySQL
                await UpdateReportDataInMySQLApi(dataToUpdate);
            }
        }

        static reportModel GetUpdateDataFromConsole()
        {
            Console.Write("Enter ID to update: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }

            Console.Write("Enter new Date (YYYY-MM-DD): ");
            DateTime newDate;
            if (!DateTime.TryParse(Console.ReadLine(), out newDate))
            {
                Console.WriteLine("Invalid date format.");
                return null;
            }

            Console.Write("Enter new Quantity: ");
            int newQuantity;
            if (!int.TryParse(Console.ReadLine(), out newQuantity))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }
            

            Console.Write("Enter new Report_Type: ");
            string newReportType = Console.ReadLine();

            Console.Write("Enter new Total_Prie: ");
            double newTotalPrice;
            if (double.TryParse(Console.ReadLine(), out newTotalPrice))
            {
                // Use the newPrice variable for further processing
            }
            else
            {
                Console.WriteLine("Invalid input for Price. Please enter a valid numeric value.");
            }



            // Create a cafeshopModel object with the updated data
            return new reportModel
            {
                re_id = id,
                date = newDate,
                quantity = newQuantity,
                report_type = newReportType,
                total_price = newTotalPrice,
            };
        }

        static async Task UpdateReportDataInMySQLApi(reportModel data)
        {
            // API endpoint for updating data (replace with your actual API endpoint)
            string apiUrl = $"http://localhost:3000/api/report";

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
