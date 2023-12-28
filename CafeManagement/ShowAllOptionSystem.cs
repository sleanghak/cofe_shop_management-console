using Coffe_ManagementConsole.CafeManagement.Cafeshop;
using Coffe_ManagementConsole.ShowMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement
{
    class ShowAllOptionSystem
    {
        //role Manager
        public void ShowAllOptionSystemManagement()
        {

            Console.WriteLine("1. Coffee Shop");
            Console.WriteLine("2. Manager ");
            Console.WriteLine("3. Employee ");
            Console.WriteLine("4. Drink ");
            Console.WriteLine("5. Order ");
            Console.WriteLine("6. Report ");
            Console.WriteLine("7. Exit");
            //Console.WriteLine("8. Back To Login");

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
                    ShowOptionMenuCafeShop showMenuCafe = new ShowOptionMenuCafeShop();
                    showMenuCafe.ShowMenuCafeShop();
                    break;
                case 2:
                    ShowOptionMenuManager showOptionMenuManager = new ShowOptionMenuManager();
                    showOptionMenuManager.ShowMenuManager();

                    
                    break;
                case 3:
                    ShowOptionMenuEmployee showOptionMenuEmployee = new ShowOptionMenuEmployee();
                    showOptionMenuEmployee.ShowMenuEmployee();

                    break;
                case 4:
                    ShowOptionMenuDrink showOptionMenuDrink = new ShowOptionMenuDrink();
                    showOptionMenuDrink.ShowMenuDrink();
                    break;
                case 5:
                    ShowOptionMenuOrder showOptionMenuOrder = new ShowOptionMenuOrder();
                    showOptionMenuOrder.ShowMenuOrder();
                    break;
                case 6:
                    ShowOptionMenuReport showOptionMenuReport = new ShowOptionMenuReport();
                    showOptionMenuReport.ShowMenuReport();
                    break;
                case 7:
                    Console.WriteLine("Exiting.");
                    break;
               
                default:
                    Console.WriteLine("Invalid choice. Exiting.");
                    break;
            }
        }


        //role employee
        public void ShowAllOptionSystemManagementEMployee()
        {
            Console.WriteLine("----------------Role Employee-----------------");
            Console.WriteLine("1. Coffe Shop");
            Console.WriteLine("2. Drink ");
            Console.WriteLine("3. Order ");
            Console.WriteLine("4. Exit");
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
                    ShowOptionMenuCafeShop showMenuCafe = new ShowOptionMenuCafeShop();
                    showMenuCafe.ShowMenuCafeShop();
                    break;
                case 2:
                    ShowOptionMenuDrink showOptionMenuDrink = new ShowOptionMenuDrink();
                    showOptionMenuDrink.ShowMenuDrink();
                    break;
                case 3:
                    ShowOptionMenuOrder showOptionMenuOrder = new ShowOptionMenuOrder();
                    showOptionMenuOrder.ShowMenuOrder();
                    break;
                case 4:
                    Console.WriteLine("Exiting.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting.");
                    break;
            }
        }


    }
}
