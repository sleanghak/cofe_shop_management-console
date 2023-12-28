using Coffe_ManagementConsole.CafeManagement.Cafeshop;
using Coffe_ManagementConsole.CafeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.ShowMenu
{
    class ShowOptionMenuCafeShop
    {
       
        public void ShowMenuCafeShop()
        {


            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Welcome to my Cafe shop !!! ");
            Console.WriteLine("1. Show All Data");
            Console.WriteLine("2. Insert Data To Cafe Shop ");
            Console.WriteLine("3. Update Data from Cafe Shop");
            Console.WriteLine("4. Delete Data from Cafe Shop");
            Console.WriteLine("5. Back Option Control");
           
            Console.WriteLine("------------------//----------------------------------------");

            bool exitRequested = false;

            do
            {
                char choice = GetMenuCafeShopChoice();
                switch (choice)
                {
                    case '1':
                        ShowDataCafeShop showDataCafeShop = new ShowDataCafeShop();
                        showDataCafeShop.RetrieveAllData();
                        break;
                    case '2':
                        AddCafeShop addCafeShop = new AddCafeShop();
                        addCafeShop.InputFromConsole();
                        break;
                    case '3':
                        UpdateCafeShop updateCafeShop = new UpdateCafeShop();
                        updateCafeShop.UpdateDataFromMySQLAsync();
                        break;
                    case '4':
                        DeleteCafeShop deleteCafeShop = new DeleteCafeShop();
                        deleteCafeShop.DeleteDataFromMySQLAsync();

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
        public void RoleManager()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Welcome to my Cafe shop !!! ");
            Console.WriteLine("1. Show Data By ID");
            Console.WriteLine("2. Show All Data ");
            Console.WriteLine("3. Insert Data To Cafe Shop");
            Console.WriteLine("4. Update Data from Cafe Shop");
            Console.WriteLine("5. Delete Data from Cafe Shop");
            Console.WriteLine("6. Back Option Control ");
            Console.WriteLine("------------------//----------------------------------------");

            bool exitRequested = false;

            do
            {
                char choice = GetMenuCafeShopChoice();
                switch (choice)
                {
                    case '1':
                        // ShowDataByID();
                        break;
                    case '2':
                        ShowDataCafeShop showDataCafeShop = new ShowDataCafeShop();
                        showDataCafeShop.RetrieveAllData();
                        break;
                    case '3':
                        AddCafeShop addCafeShop = new AddCafeShop();
                        addCafeShop.InputFromConsole();
                        break;
                    case '4':
                        UpdateCafeShop updateCafeShop = new UpdateCafeShop();
                        updateCafeShop.UpdateDataFromMySQLAsync();
                        break;
                    case '5':
                        DeleteCafeShop deleteCafeShop = new DeleteCafeShop();
                        deleteCafeShop.DeleteDataFromMySQLAsync();

                        break;
                    case '6':
                        ShowAllOptionSystem showAllOptionSystem = new ShowAllOptionSystem();
                        showAllOptionSystem.ShowAllOptionSystemManagement();

                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (!exitRequested);

        }
    }
}
