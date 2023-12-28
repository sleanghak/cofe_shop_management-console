using Coffe_ManagementConsole.CafeManagement.Drink;
using Coffe_ManagementConsole.CafeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffe_ManagementConsole.CafeManagement.Employee;

namespace Coffe_ManagementConsole.ShowMenu
{
    class ShowOptionMenuEmployee
    {
        public void ShowMenuEmployee()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Welcome to Employee !!! ");
            Console.WriteLine("1. Show All Employee");
            Console.WriteLine("2. Insert To Employee");
            Console.WriteLine("3. Update Employee ");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Back Option Control ");
            Console.WriteLine("------------------//----------------------------------------");

            bool exitRequested = false;

            do
            {
                char choice = GetMenuCafeShopChoice();
                switch (choice)
                {
                    case '1':
                        ShowDataEmployee showDataEmployee = new ShowDataEmployee();
                        showDataEmployee.RetrieveAllDataEmployee();
                        break;
                    case '2':
                        AddEmployee addEmployee = new AddEmployee();
                        addEmployee.InputEmployeeFromConsole();
                        
                        break;
                    case '3':
                        UpdateDataEmployee updateDataEmployee = new UpdateDataEmployee();
                        updateDataEmployee.UpdateEmployeeDataFromMySQLAsync();

                        break;
                    case '4':
                        DeleteDataEmployee deleteEmployee = new DeleteDataEmployee();
                        deleteEmployee.DeleteDataEmployeeFromConsoleAsync();

                        break;
                    case '5':
                        ShowAllOptionSystem showAllOptionSystem = new ShowAllOptionSystem();
                        showAllOptionSystem.ShowAllOptionSystemManagement();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (!exitRequested);
        }
        static char GetMenuCafeShopChoice()
        {
            Console.Write("Enter your choice: ");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return choice;
        }
    }
}
