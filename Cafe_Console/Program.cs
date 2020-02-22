using Cafe_Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class Program
    {

        private readonly Main_Repository _repo = new Main_Repository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select an option by number. \n" +
                    "1. Add Item\n" +
                    "2. Get all items\n" +
                    "3. Remove Item by menu number\n" +
                    "4. Remove item by name\n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1": //add item
                        AddContentToMainFood();
                        break;
                    case "2":
                        GetAllContent();
                        break;
                    case "3"://remove item
                        DeleteContentByNumber();
                        break;
                    case "4":
                        DeleteContentByTitle();
                        break;
                    case "5"://exit
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //create
        private void AddContentToMainFood()
        {
            MainFood content = new MainFood();
            Console.WriteLine("Enter item name.");
            content.MainFoodName = Console.ReadLine();

            Console.WriteLine("Add Descritption of item.");
            content.MainFoodName = Console.ReadLine();

            Console.WriteLine("What is the menu number for item?");
            content.MenuNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingredients to make item.");
            content.MainIngredients = Console.ReadLine();

            Console.WriteLine("Last step, what is the price of the item?");
            content.MainPrice = Convert.ToDouble(Console.ReadLine());

            _repo.AddContentToMainFood(content);
            Console.WriteLine("Your item has been added. Press any key to return to the menu.");
            Console.ReadKey();
        }

        //read
        private void GetAllContent()
        {
            Console.Clear();

            List<MainFood> directory = _repo.GetAllContent();

            foreach (MainFood content in directory)
            {
                Console.WriteLine($"Item Name: {content.MainFoodName}\n" +
                    $"Description: {content.MainDescription}\n" +
                    $"Ingredients{content.MainIngredients}\n" +
                    $"Menu Number: {content.MenuNumber}\n" +
                    $"Price: ${content.MainPrice}");
            }
            Console.WriteLine("Press any button to Continue.");
            Console.ReadKey();
        }

        //delete
        private void DeleteContentByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter Item Name you want to delete by number.");
            int itemInput = Convert.ToInt32(Console.ReadLine());
            MainFood existingContent = _repo.GetFoodByNumber(itemInput);

            if (existingContent == null)
            {
                Console.WriteLine("There isn't any items under that menu number.\n" +
                    "Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your Item has been removed.\n" +
                    "Press any key to continue.");
                Console.ReadKey();
            }
        }

        private void DeleteContentByTitle()
        {
            Console.Clear();
            Console.WriteLine("Enter Item Name you want to delete by name.");
            string itemName = Console.ReadLine();
            MainFood existingContent = _repo.GetFoodByName(itemName);
            if (existingContent == null)
            {
                Console.WriteLine("There isn't any items under that menu number.\n" +
                    "Press any key to continue.");
                Console.ReadKey();
            }
            else
            { 
                Console.WriteLine("Your Item has been removed.\n" +
                    "Press any key to continue.");
                Console.ReadKey();
            }
        }

        private void SeedContent()
        {
            MainFood spaghetti = new MainFood("Spaghetti", "Cooked noodles with meaty tomato sauce.", "Spaghetti, water, salt, meaty tomato sauce", 12.35, 1);
            _repo.AddContentToMainFood(spaghetti);

            MainFood macDaddy = new MainFood("MacDaddy", "Tripple beef burger covered in bbq sauce with onion rings.", "3 burger patties, bun, bbq sauce, onion rings", 10.35, 2);
            _repo.AddContentToMainFood(macDaddy);

            MainFood ribs = new MainFood("Ribs", "Slow cooked ribs slathered in house made bbq sauce served with fries.", "St Louis ribs, house rub, bbq sauce, house fries", 16.92, 3);
            _repo.AddContentToMainFood(ribs);
        }
    }
}
