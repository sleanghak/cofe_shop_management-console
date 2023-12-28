using Coffe_ManagementConsole.CafeManagement.Manager;
using Coffe_ManagementConsole.CafeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffe_ManagementConsole.CafeManagement.Order;

namespace Coffe_ManagementConsole.ShowMenu
{
    class ShowOptionMenuOrder
    {
        public void ShowMenuOrder()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Welcome to Order !!! ");
            Console.WriteLine("1. Show All Order");
            Console.WriteLine("2. Order Data");
            Console.WriteLine("3. Back Option Control ");
            Console.WriteLine("------------------//----------------------------------------");

            bool exitRequested = false;

            do
            {
                char choice = GetMenuCafeShopChoice();
                switch (choice)
                {
                    case '1':
                        ShowDataOrder showDataOrder = new ShowDataOrder();
                        showDataOrder.RetrieveAllDataOrder();
                        break;
                    case '2':
                        OrderData orderData = new OrderData();
                        orderData.OrderFromDrink();
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
