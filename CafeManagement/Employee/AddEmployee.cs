using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Employee
{
    class AddEmployee
    {
        public void InputEmployeeFromConsole()
        {
            employeeModel dataToInsert = GetInputEmployeeFromConsole();

            // Call a method to insert data into MySQL API
            InsertEmployeetoMySQL(dataToInsert);
        }
        static employeeModel GetInputEmployeeFromConsole()
        {
            Console.Write("Enter ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Birth-Date (YYYY-MM-DD): ");
            string birthdate = Console.ReadLine();
            /*DateTime birthdate;
            if (!DateTime.TryParse(Console.ReadLine(), out birthdate))
            {
                Console.WriteLine("Invalid date format.");
                return null;
            }*/
            Console.Write("Enter Position: ");
            string position = Console.ReadLine();

            // Create a MyData object with console input
            return new employeeModel
            {
                emp_id = id,
                name = name,
                gender = gender,
                address = address,
                email = email,
                phone = phone,
                birth_date = birthdate,
                position = position,
            };
        }
        static void InsertEmployeetoMySQL(employeeModel data)
        {
            if (data == null)
            {
                Console.WriteLine("Invalid data. Exiting.");
                return;
            }

            // Call API to insert data into MySQL
            // Use MySqlConnection, MySqlCommand, and other MySQL components
            // Example: Insert data into a table
            string apiUrl = "http://localhost:3000/api/employee";
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
