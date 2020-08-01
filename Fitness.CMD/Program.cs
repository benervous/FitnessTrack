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

            var UserController = new UserController(name);
        }
    }
}
