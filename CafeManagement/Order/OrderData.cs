using Coffe_ManagementConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe_ManagementConsole.CafeManagement.Order
{
     class OrderData
    {
        public void OrderFromDrink()
        {
            Console.Write("Enter drink ID: ");
            int drinkId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter quantity to order: ");
            int orderedQuantity = Convert.ToInt32(Console.ReadLine());

            // Retrieve drink information by ID
            drinkModel drink = RetrieveDrinkById(drinkId);

            /*if (drink != null)
            {
                // Update drink quantity
                UpdateDrinkQuantity(drinkId, drink. - orderedQuantity);

                // Place order for the drink
                PlaceDrinkOrder(drink, orderedQuantity);
            }
            else
            {
                Console.WriteLine($"Drink with ID {drinkId} not found.");
            }*/
        }
        static drinkModel RetrieveDrinkById(int drinkId)
        {
            // Set API endpoint URL for retrieving drink by ID
            string apiUrl = $"http://yourapi.com/drinks/{drinkId}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string apiData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<drinkModel>(apiData);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        }
        static void UpdateDrinkQuantity(int drinkId, int newQuantity)
        {
            // Set API endpoint URL for updating drink quantity
            string apiUrl = $"http://yourapi.com/drinks/{drinkId}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Create a JSON object with the new quantity
                var jsonBody = new { Quantity = newQuantity };
                string jsonString = JsonConvert.SerializeObject(jsonBody);

                // Set the content type header
                StringContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                // Send the PUT request to update the drink quantity
                HttpResponseMessage response = client.PutAsync(apiUrl, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error updating drink quantity: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
        static void PlaceDrinkOrder(drinkModel drink, int orderedQuantity)
        {
            // Create an order object for the drink
            orderModel newOrder = new orderModel
            {
                name = "CustomerName", // Set customer name as needed
                quantity = orderedQuantity,
                price = drink.price,
                date = DateTime.Now,
                total_price = (int)(orderedQuantity * drink.price),
                re_id = drink.dr_id // Assuming drink has a RestaurantId property
            };

            // Set API endpoint URL for placing an order
            string apiUrl = "http://yourapi.com/orders";

            // Serialize order object to JSON
            string jsonBody = JsonConvert.SerializeObject(newOrder);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Set the content type header
                StringContent content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                // Send the POST request to place the drink order
                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Drink order placed successfully!");
                }
                else
                {
                    Console.WriteLine($"Error placing drink order: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

    }
}
