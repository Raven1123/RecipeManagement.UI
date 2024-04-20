using RecipeManagement.Business;
using RecipeManagement.Business.Models;
using RecipeManagement.Data;
using System;

namespace RecipeManagement.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IRecipeRepository recipeRepository = new InMemoryRecipeRepository();
            RecipeService recipeService = new RecipeService(recipeRepository);
          
            while (true)
            {
                Console.WriteLine("WELCOME TO RECIPE MANAGEMENT SYSTEM");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Display all recipes");
                Console.WriteLine("2. Add a new recipe");
                Console.WriteLine("3. Exit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        DisplayAllRecipes(recipeService);
                        break;
                    case "2":
                        AddNewRecipe(recipeService);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DisplayAllRecipes(RecipeService recipeService)
        {
            Console.WriteLine("Recipes:");
            Console.WriteLine("---------");
            foreach (var recipe in recipeService.GetAllRecipes())
            {
                Console.WriteLine($"Name: {recipe.Name}");
                Console.WriteLine($"Description: {recipe.Description}");
                Console.WriteLine($"Ingredients: {recipe.Ingredients}");
                Console.WriteLine();
            }
        }

        static void AddNewRecipe(RecipeService recipeService)
        {
            Console.WriteLine("Enter recipe details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Ingredients: ");
            string ingredients = Console.ReadLine();

            Recipe newRecipe = new Recipe { Name = name, Description = description, Ingredients = ingredients };
            recipeService.AddRecipe(newRecipe);
            Console.WriteLine("Recipe added successfully.");
        }
    }
}
