using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetAdditionalUserDataTest()
        {
            //Arrange
            var name = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var height = 80;
            var weight = 90;
            var gender = "male";
            var controller = new UserController(name);
            //Act
            controller.SetAdditionalUserData(gender, birthdate, weight, height);
            //Assert
            var controller2 = new UserController(name);

            Assert.AreEqual(name, controller2.CurrentUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(name);

            //Assert
            Assert.AreEqual(name, controller.CurrentUser.Name);
        }
    }
}