using System;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome here! Please enter your name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter your gender");
            var gender = Console.ReadLine();
            Console.WriteLine("Enter your datebirth");
            var datebirth = DateTime.Parse(Console.ReadLine()); // TODO: do try parse
            Console.WriteLine("Enter your height");
            var height = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your weight");
            var weight = double.Parse(Console.ReadLine());
            var userController = new UserController(name, gender, datebirth, height, weight);
            userController.Save();
        }
    }
}
