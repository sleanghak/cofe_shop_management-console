using Coffe_ManagementConsole.CafeManagement.Cafeshop;
using Coffe_ManagementConsole.CafeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffe_ManagementConsole.CafeManagement.Drink;

namespace Coffe_ManagementConsole.ShowMenu
{
    class ShowOptionMenuDrink
    {
        public void ShowMenuDrink()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Welcome to Drink !!! ");
            Console.WriteLine("1. Show All Drink");
            Console.WriteLine("2. Insert To Drink");
            Console.WriteLine("3. Update Drink ");
            Console.WriteLine("4. Delete Drink");
            Console.WriteLine("5. Back Option Control ");
            Console.WriteLine("------------------//----------------------------------------");

            bool exitRequested = false;

            do
            {
                char choice = GetMenuCafeShopChoice();
                switch (choice)
                {
                    case '1':
                        ShowDataDrink showDataDrink = new ShowDataDrink();
                        showDataDrink.RetrieveAllDataDrink();
                        break;
                    case '2':
                        AddDrink addDrink = new AddDrink();
                        addDrink.InputDrinkFromConsole();
                        break;
                    case '3':
                        UpdateDataDrink updateDataDrink = new UpdateDataDrink();
                        updateDataDrink.UpdateDrinkDataFromMySQLAsync();
                        break;
                    case '4':
                        DeleteDataDrink deleteDataDrink = new DeleteDataDrink();
                        deleteDataDrink.DeleteDataDrinkFromConsoleAsync();
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
