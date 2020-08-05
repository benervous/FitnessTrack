using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange 
            var rnd = new Random();
            var nameproduct = Guid.NewGuid().ToString();
            var username = Guid.NewGuid().ToString();
            var UserController = new UserController(username);
            var Eating = new EatingController(UserController.CurrentUser);
            var food = new Food(nameproduct, rnd.Next(50,100), rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100));
            //Act
            Eating.Add(food, 100);
            //Assert
            Assert.AreEqual(food.Food_Name, Eating.Eating.Food.First().Key.Food_Name);
        }
    }
}