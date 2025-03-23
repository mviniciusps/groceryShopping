using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryShopping
{
    class CategoryItemList
    {
        private string[] categoryList = new string[]
        {
            "Fruit", "Vegetable", "Cereal", "Dairy", "Meat", "Pasta", "Beverage", "Sweet"
        };

        private Dictionary<string, List<string>> categoryGroup = new Dictionary<string, List<string>>();

        public void FoodChoose(string categoryChosen)
        {
            Console.WriteLine("What food do you want to add?");
            string foodName = Console.ReadLine();

            if (!categoryGroup.ContainsKey(categoryChosen))
            {
                categoryGroup[categoryChosen] = new List<string>();
            }

            if (categoryGroup[categoryChosen].Contains(foodName))
            {
                Console.WriteLine("This food is already in the list.");
            }
            else
            {
                categoryGroup[categoryChosen].Add(foodName);
                Console.WriteLine($"Food '{foodName}' added to category '{categoryChosen}'.");
            }
        }

        public void ShowList()
        {
            Console.WriteLine("\nGrocery List:");
            foreach (var category in categoryGroup)
            {
                Console.WriteLine($"Category: {category.Key}");
                foreach (var food in category.Value)
                {
                    Console.WriteLine($"- {food}");
                }
                Console.WriteLine("-------");
            }
        }

        public string CategoryChoose()
        {
            Console.WriteLine("Which category?\n");
            Console.WriteLine($"{string.Join(", ", categoryList)}.");

            while (true)
            {
                string categoryChosen = Console.ReadLine();

                if (categoryList.Contains(categoryChosen, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Category chosen: {categoryChosen}");
                    return categoryChosen;
                }
                else
                {
                    Console.WriteLine("Invalid category, please choose one of the following:");
                    Console.WriteLine($"{string.Join(", ", categoryList)}.");
                }
            }
        }

        public void InitialAsk()
        {
            Console.WriteLine("Do you wish to add some food to your grocery list? (S/N)");
            string answerYesOrNo = Console.ReadLine().ToUpper();

            while (answerYesOrNo == "S")
            {
                string chosenCategory = CategoryChoose();
                FoodChoose(chosenCategory);

                Console.WriteLine("Do you wish to add one more? (S/N)");
                answerYesOrNo = Console.ReadLine().ToUpper();
            }

            ShowList();
        }
    }
}