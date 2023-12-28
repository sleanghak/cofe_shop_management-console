
using Coffe_ManagementConsole.CafeManagement;
using Coffe_ManagementConsole.CafeManagement.Cafeshop;
namespace Coffe_ManagementConsole{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("           Welcome to the Cafe Management              ");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine(" 1. Login Manager / Employee ");
            Console.WriteLine(" 2. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }
            switch (choice)
            {
                case 1:
                    
                    Login();
                    break;
                case 2:
                    Console.WriteLine("Exiting.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting.");
                    break;
            }
         
        }
        static bool CheckCredentials(string enteredUsername, string enteredPassword, string correctUsername, string correctPassword)
        {
            return enteredUsername == correctUsername && enteredPassword == correctPassword;
        }
   
        static void Login()
        {
            Console.Write("Enter your username: ");
            string enteredUsername = Console.ReadLine().Trim();

            Console.Write("Enter your password: ");
            string enteredPassword = Console.ReadLine().Trim();

            // Get the user role (Manager or Employee)
            Console.Write("Enter your role (Manager/Employee): ");
            string enteredRole = Console.ReadLine();

            if (CheckCredentials(enteredUsername, enteredPassword, enteredRole))
            {
                Console.WriteLine("Login successful. Welcome, " + enteredUsername + "!");
                Console.Clear();

                // Redirect based on the user role
                if (enteredRole.Equals("Manager", StringComparison.OrdinalIgnoreCase))
                {
                    // Manager options
                    ShowAllOptionSystem showAllOptionSystem = new ShowAllOptionSystem();
                    showAllOptionSystem.ShowAllOptionSystemManagement();
                }
                else if (enteredRole.Equals("Employee", StringComparison.OrdinalIgnoreCase))
                {
                    // Employee options
                    ShowAllOptionSystem showAllOptionSystem = new ShowAllOptionSystem();
                    showAllOptionSystem.ShowAllOptionSystemManagementEMployee();
                }
                else
                {
                    Console.WriteLine("Invalid role.");
                }
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username, password, or role.");
            }

            Console.ReadLine(); // Keep the console window open
        }

        static bool CheckCredentials(string enteredUsername, string enteredPassword, string enteredRole)
        {
            // Your logic to check credentials goes here
            // For simplicity, let's assume a fixed set of credentials
            string correctUsername = "";
            string correctPassword = "";

            switch (enteredRole.ToLower())
            {
                case "manager":
                    correctUsername = "Manager";
                    correctPassword = "123";
                    break;
                case "employee":
                    correctUsername = "Employee";
                    correctPassword = "123";
                    break;
                default:
                    return false; // Invalid role
            }

            return enteredUsername == correctUsername && enteredPassword == correctPassword;
        }

    }

}
