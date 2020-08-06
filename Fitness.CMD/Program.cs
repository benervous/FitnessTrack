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
            if (UserController.IsCurrentUserNew)
            {
                Console.WriteLine("Please, enter your gender:");
                string gender = Console.ReadLine();
                Console.WriteLine("Please, enter your birth date dd.MM.yyyy:");
                DateTime birth = ParseBirth();
                double height = ParseDouble("height");
                double weight = ParseDouble("weight");

                UserController.SetAdditionalUserData(gender, birth, weight, height);
            }

            Console.WriteLine(UserController.CurrentUser);

            Console.ReadLine();
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
