using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome here! Please enter your name:");
            var name = Console.ReadLine();
            
            
            var UserController = new UserController(name);
            var EatingController = new EatingController(UserController.CurrentUser);
            if (UserController.IsCurrentUserNew)
            {
                Console.WriteLine("Please, enter your gender:");
                string gender = Console.ReadLine();
                Console.WriteLine("Please, enter your birth date mm.DD.yyyy:");
                DateTime birth = ParseBirth();
                double height = ParseDouble("height");
                double weight = ParseDouble("weight");

                UserController.SetAdditionalUserData(gender, birth, weight, height);
            }

            //Console.WriteLine(UserController.CurrentUser);
            Console.WriteLine("Write e if you want to add food: ");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
               var food = EnterEating();
               EatingController.Add(food.Food, food.Weight);
                foreach(var item in EatingController.Eating.Food)
                {
                    Console.WriteLine($"\t{item.Key.Food_Name} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("\nEnter the name of food: ");
            var name = Console.ReadLine();
            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fat = ParseDouble("fat");
            var carbohydrates = ParseDouble("carbohydrates");
            var weight = ParseDouble("weight");
            var product = new Food(name, calories, proteins, fat, carbohydrates);
            return (Food: product, Weight: weight);

        }

        private static DateTime ParseBirth()
        {
            DateTime birth;
            while (true)
            {            
                if (DateTime.TryParse(Console.ReadLine(), out birth)){ break; }
                else { Console.WriteLine("Please, write your datebirth correctly"); }
            }
            return birth;
        }
        private static double ParseDouble(string name)
        {

            while (true)
            {
                Console.WriteLine("Please, enter your {0}:", name);
                if (double.TryParse(Console.ReadLine(), out double value)) { return value; }
                else { Console.WriteLine("Please, write your {0} correctly:", name); }
            }
        }
    }
}
