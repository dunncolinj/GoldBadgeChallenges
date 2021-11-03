using Challenge3.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        BadgeDict myDict;
        Badge myBadge1;
        Badge myBadge2;
        Badge myBadge3;

        [TestInitialize]
        public void Arrange()
        {
            myDict = new BadgeDict();
            List<string> doorList1 = new List<string>();
            List<string> doorList2 = new List<string>();
            List<string> doorList3 = new List<string>();

            doorList1.Add("A1");
            doorList1.Add("A2");
            doorList1.Add("A3");

            doorList2.Add("B4");
            doorList2.Add("B5");

            doorList3.Add("C6");
            doorList3.Add("C7");
            doorList3.Add("C8");

            myBadge1 = new Badge(1, doorList1);
            myBadge2 = new Badge(2, doorList2);
            myBadge3 = new Badge(3, doorList3);

            myDict.Add(myBadge1);
            myDict.Add(myBadge2);
            myDict.Add(myBadge3);
        }

        [TestMethod]
        public void Test_Add()
        {
            List<string> doorList4 = new List<string>();
            bool result;

            doorList4.Add("D1");
            doorList4.Add("D2");

            Badge myBadge4 = new Badge(4, doorList4);
            result = myDict.Add(myBadge4);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void Test_UpdateDoors()
        {
            List<string> doorList5 = new List<string>();
            bool result;

            doorList5.Add("E1");
            doorList5.Add("E2");

            result = myDict.UpdateDoors(1, doorList5);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Get()
        {
            Badge badgeToGet;
            badgeToGet = myDict.Get(1);
            Assert.IsNotNull(badgeToGet);
        }

        [TestMethod]
        public void Test_DeleteAllDoors()
        {
            List<string> doorList6 = new List<string>();
            doorList6.Add("F1");
            doorList6.Add("F2");

            Badge myBadge6 = new Badge(6, doorList6);
            myDict.Add(myBadge6);
            myDict.DeleteAllDoors(myBadge6);
            Assert.IsNull(myBadge6.DoorNames);
        }

        [TestMethod]
        public void Test_CheckID()
        {
            bool result;
            result = myDict.CheckID(1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Read()
        {
            Dictionary<int, Badge> copyDict = new Dictionary<int, Badge>();
            copyDict = myDict.Read();
            Assert.IsNotNull(copyDict);
        }
    }
}
