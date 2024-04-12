using System;

namespace RecipeApplication
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class RecipeStep
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        private Ingredient[] ingredients;
        private RecipeStep[] steps;

        public Recipe()
        {
            ingredients = new Ingredient[0];
            steps = new RecipeStep[0];
        }

        public void AddIngredient(string name, double quantity, string unit)
        {
            Array.Resize(ref ingredients, ingredients.Length + 1);
            ingredients[ingredients.Length - 1] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
        }

        public void AddStep(string description)
        {
            Array.Resize(ref steps, steps.Length + 1);
            steps[steps.Length - 1] = new RecipeStep { Description = description };
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nRecipe Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Reset all ingredient quantities to their original values
            // You would need to store original values if scaling can be done multiple times
        }

        public void ClearRecipe()
        {
            ingredients = new Ingredient[0];
            steps = new RecipeStep[0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Enter recipe details:");

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(name, quantity, unit);
            }

            Console.Write("\nEnter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nStep {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();

                recipe.AddStep(description);
            }

            Console.WriteLine("\nRecipe created successfully!");

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Display Recipe");
                Console.WriteLine("2. Scale Recipe");
                Console.WriteLine("3. Reset Quantities");
                Console.WriteLine("4. Clear Recipe");
                Console.WriteLine("5. Exit");

                Console.Write("Enter option number: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        Console.WriteLine("Recipe scaled successfully!");
                        break;
                    case 3:
                        recipe.ResetQuantities();
                        Console.WriteLine("Quantities reset to original values.");
                        break;
                    case 4:
                        recipe.ClearRecipe();
                        Console.WriteLine("Recipe cleared.");
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}

