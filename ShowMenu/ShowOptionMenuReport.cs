using Coffe_ManagementConsole.CafeManagement.Manager;
using Coffe_ManagementConsole.CafeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffe_ManagementConsole.CafeManagement.Report;
using Coffe_ManagementConsole.CafeManagement.Employee;
using Coffe_ManagementConsole.CafeManagement.Order;

namespace Coffe_ManagementConsole.ShowMenu
{
    class ShowOptionMenuReport
    {
        public void ShowMenuReport()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Welcome to Report !!! ");
            Console.WriteLine("1. Show All Report");
            Console.WriteLine("2. Delete Report");
            Console.WriteLine("3. Back Option Control ");
            Console.WriteLine("------------------//----------------------------------------");

            bool exitRequested = false;

            do
            {
                char choice = GetMenuCafeShopChoice();
                switch (choice)
                {
                    case '1':
                        ShowDataReport showDataReport = new ShowDataReport();
                        showDataReport.RetrieveAllDataReport();
                        break;
                    case '2':
                        DeleteDataReport deleteDataReport = new DeleteDataReport();
                        deleteDataReport.DeleteDataReportFromConsoleAsync();
                        break;
                    case '3':
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
