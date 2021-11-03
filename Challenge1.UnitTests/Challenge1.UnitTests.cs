using Challenge1.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        MenuItem myMenuItem1;
        MenuItem myMenuItem2;
        Menu myMenu;

        [TestInitialize]
        public void Arrange()
        {
            List<string> ingredients1 = new List<string>();

            ingredients1.Add("Ground beef patty");
            ingredients1.Add("Sesame seed bun");

            List<string> ingredients2 = new List<string>();
            ingredients2.Add("Ground beef patty");
            ingredients2.Add("Sesame seed bun");
            ingredients2.Add("American cheese slice");

            myMenuItem1 = new MenuItem(1, "Hamburger", "Ground beef patty on a bun", ingredients1, 4.99m);
            myMenuItem2 = new MenuItem(2, "Cheeseburger", "Ground beef patty on a bun, topped with American cheese", ingredients2, 5.99m);
        }

        [TestMethod]
        public void Test_AddMenuItem()
        {
            int beforeCount;
            int afterCount;

            // test add method
            myMenu = new Menu();
            beforeCount = myMenu._menu.Count;

            myMenu.Add(myMenuItem1);
            afterCount = myMenu._menu.Count;
            Assert.AreEqual(afterCount, beforeCount + 1);
        }

        [TestMethod]
        public void Test_RemoveMenuItem()
        {
            int beforeCount;
            int afterCount; 
            
            Menu myMenu = new Menu();
            
            myMenu.Add(myMenuItem1);
            myMenu.Add(myMenuItem2);

            beforeCount = myMenu._menu.Count;
            myMenu.Remove(myMenuItem2);
            afterCount = myMenu._menu.Count;
            Assert.AreEqual(afterCount, beforeCount - 1);
        }

        [TestMethod]
        public void Test_GetMenuItem()
        {
            Menu myMenu = new Menu();
            MenuItem result;

            myMenu.Add(myMenuItem1);
            result = myMenu.Get(myMenuItem1.MealNumber);
            Assert.IsNotNull(result);
        }
    }
}
