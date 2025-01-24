using System;
using System.Collections.Generic;

namespace FoodBankInventorySystem
{
    class Program
    {
        static List<FoodItem> foodInventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine("\nEnter the number of the task to which you wish to navigate. (Example: '1')");
                Console.WriteLine("\r\n 1. Add Food Items\r\n 2. Delete Food Items\r\n 3. Print List of Current Food Items\r\n 4. Exit the Program\r\n");

                string input = Console.ReadLine();
                int option;

                if (int.TryParse(input, out option))
                {
                    if (option == 1)
                    {
                        AddFoodItem();
                    }
                    else if (option == 2)
                    {
                        DeleteFoodItem();
                    }
                    else if (option == 3)
                    {
                        PrintFoodItems();
                    }
                    else if (option == 4)
                    {
                        exitProgram = true;
                        Console.WriteLine("Exiting the program. See ya!");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please use an integer 1-4.");
                    }
                }
            }
        }

        static void AddFoodItem()
        {
            System.Console.WriteLine("\nInput the following information on the food item below.\n\n");
            Console.Write("Name of the food item: (e.g., \"Canned Beans\")\n");
            string foodName = Console.ReadLine();

            string foodCategory = "";

                Console.WriteLine("\nWhich food category does this item belong to?: (e.g., \"2\")");
                Console.WriteLine(" 1. Canned Goods (e.g., vegetables, fruits, soups, and beans)\r\n 2. Dry Goods (e.g., rice, pasta, lentils, and grains)\r\n 3. Boxed Meals (e.g., macaroni and cheese, meal kits, and instant noodles)\r\n 4. Baking Essentials (e.g., flour, sugar, baking powder, and mixes)\r\n 5. Breakfast Items (e.g., cereal, oatmeal, and pancake mix)\n");

                string foodCategoryInput = Console.ReadLine();

                if (foodCategoryInput == "1")
                {
                foodCategory = "Canned Goods";
                }
                else if (foodCategoryInput == "2")
                {
                foodCategory = "Dry Goods";
                }
                else if (foodCategoryInput == "3")
                {
                foodCategory = "Boxed Meals";
                }
                else if (foodCategoryInput == "4")
                {
                foodCategory = "Baking Essentials";
                }
                else if (foodCategoryInput == "5")
                {
                foodCategory = "Breakfast Items";
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Enter an integer 1-5. Please try again. (e.g., \"2\")\n");
                }

            int foodQuantity = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("\nEnter the food's item quantity (e.g., \"8\")");
                string input2 = Console.ReadLine();
                foodQuantity = int.Parse(input2);

                if (int.TryParse(input2, out foodQuantity)) // Validate and assign directly to foodQuantity
                {
                    isValidInput = true; // Valid input; exit the loop
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid integer.");
                }
            }
            Console.WriteLine("\nEnter the expiration date in this format: MM/dd/yyyy.\n");
            string input3 = Console.ReadLine();

            if (DateTime.TryParse(input3, out DateTime expirationDate)) // Tries to parse the input
            {
                Console.WriteLine($"\n\nThank you! Here is the information you entered for your food item:\n" +
                    $"Name: {foodName} \n" +
                    $"Category: {foodCategory} \n" +
                    $"Quantity: {foodQuantity} \n" +
                    $"Expiration Date: {expirationDate:d}");

                // pass the gathered information to pass to the foodItem constructor
                FoodItem foodItem = new FoodItem(foodName, foodCategory, foodQuantity, expirationDate);

            }
            else
            {
                Console.WriteLine("\nInvalid date format. Please use MM/dd/yyyy.");
            }

            FoodItem newFoodItem = new FoodItem(foodName, foodCategory, foodQuantity, expirationDate);
            foodInventory.Add(newFoodItem);
            Console.WriteLine("Food item added successfully.");
        }

        static void DeleteFoodItem()
        {
            if (foodInventory.Count == 0)
            {
                Console.WriteLine("No food items to delete.");
                return;
            }

            Console.WriteLine("\nCurrent Food Items:");
            for (int i = 0; i < foodInventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {foodInventory[i].FoodName} ({foodInventory[i].FoodCategory}) - {foodInventory[i].FoodQuantity} units, Expiration: {foodInventory[i].ExpirationDate.ToShortDateString()}");
            }

            int index;
            while (true)
            {
                Console.Write("Enter the number of the food items to delete: ");
                if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= foodInventory.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the food item you wish to delete.");
                }
            }

            foodInventory.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully.");
        }

        static void PrintFoodItems()
        {
            if (foodInventory.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
                return;
            }

            Console.WriteLine("\nCurrent Food Items:");
            foreach (FoodItem item in foodInventory)
            {
                Console.WriteLine($"Name: {item.FoodName}, Category: {item.FoodCategory}, Quantity: {item.FoodQuantity}, Expiration Date: {item.ExpirationDate.ToShortDateString()}");
            }
        }
    }
}