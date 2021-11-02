using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1.Repository
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> ingredients1 = new List<string>();
            ingredients1.Add("Ground beef patty");
            ingredients1.Add("Sesame seed bun");

            List<string> ingredients2 = new List<string>();
            ingredients2.Add("Ground beef patty");
            ingredients2.Add("Sesame seed bun");
            ingredients2.Add("American cheese slice");
            
            MenuItem myMenuItem1 = new MenuItem(1, "Hamburger", "Ground beef patty on a bun", ingredients1, 4.99m);
            MenuItem myMenuItem2 = new MenuItem(2, "Cheeseburger", "Ground beef patty on a bun, topped with American cheese", ingredients2, 5.99m);

            int beforeCount;
            int afterCount;

            // test add method
            Menu myMenu = new Menu();
            beforeCount = myMenu._menu.Count();

            myMenu.Add(myMenuItem1);
            afterCount = myMenu._menu.Count();
            Assert.AreEqual(afterCount, beforeCount + 1);

            myMenu.Add(myMenuItem2);
            afterCount = myMenu._menu.Count();
            Assert.AreEqual(afterCount, beforeCount + 2);

            // test remove method
            beforeCount = myMenu._menu.Count();
            myMenu.Remove(myMenuItem1);
            afterCount = myMenu._menu.Count();

            Assert.AreEqual(afterCount, beforeCount - 1);

            // test get method
            bool result;
            result = myMenu.Get(1);
            Assert.IsFalse(result);

            result = myMenu.Get(2);
            Assert.IsTrue(result);
        }
    }
}
