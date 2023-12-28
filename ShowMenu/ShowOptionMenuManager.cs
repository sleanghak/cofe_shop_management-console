using Coffe_ManagementConsole.CafeManagement.Employee;
using Coffe_ManagementConsole.CafeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffe_ManagementConsole.CafeManagement.Manager;

namespace Coffe_ManagementConsole.ShowMenu
{
    class ShowOptionMenuManager
    {
        public void ShowMenuManager()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Welcome to Manager !!! ");
            Console.WriteLine("1. Show All Manager");
            Console.WriteLine("2. Insert To Manager");
            Console.WriteLine("3. Update Manager ");
            Console.WriteLine("4. Delete Manager");
            Console.WriteLine("5. Back Option Control ");
            Console.WriteLine("------------------//----------------------------------------");

            bool exitRequested = false;

            do
            {
                char choice = GetMenuCafeShopChoice();
                switch (choice)
                {
                    case '1':
                        ShowDataManager showDataManager = new ShowDataManager();
                        showDataManager.RetrieveAllDataManager();
                        break;
                    case '2':
                        AddManager addManager = new AddManager();
                        addManager.InputManagerFromConsole();

                        break;
                    case '3':
                        UpdateDataManager updateDataManager = new UpdateDataManager();
                        updateDataManager.UpdateManagerDataFromMySQLAsync();
                        break;
                    case '4':
                        DeleteDataManager deleteDataManager = new DeleteDataManager();
                        deleteDataManager.DeleteDataManagerFromConsoleAsync();
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
