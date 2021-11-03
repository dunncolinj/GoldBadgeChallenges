using Challenge2.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge2.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        ClaimQueue myQueue;

        [TestInitialize]
        public void Arrange()
        {
            // arrange
            myQueue = new ClaimQueue();
            DateTime claim1Date = new DateTime(2021, 11, 1);
            DateTime claim2Date = new DateTime(2021, 8, 31);
            DateTime claim3Date = new DateTime(2021, 10, 15);


            Claim myClaim1 = new Claim(1, ClaimType.Car, "Broken Window", 700m, claim1Date, DateTime.Now);
            Claim myClaim2 = new Claim(2, ClaimType.Home, "Wind damage to siding", 3000m, claim2Date, DateTime.Now);
            Claim myClaim3 = new Claim(3, ClaimType.Theft, "Stolen jewelry", 5000m, claim3Date, DateTime.Now);

            myQueue.Add(myClaim1);
            myQueue.Add(myClaim2);
            myQueue.Add(myClaim3);
        }

        [TestMethod]
        public void Test_Get_Returns_Object()
        {
            Claim result;
            result = myQueue.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Get_Dequeues()
        {
            Claim result;
            int beforeCount;
            int afterCount;

            beforeCount = myQueue._claims.Count;
            result = myQueue.Get();
            afterCount = myQueue._claims.Count;
            Assert.AreEqual(afterCount, beforeCount - 1);
        }

        [TestMethod]
        public void Test_Add()
        {
            DateTime claim4Date = new DateTime(2021, 10, 1);
            Claim myClaim4 = new Claim(4, ClaimType.Car, "Fender-bender", 900m, claim4Date, DateTime.Now);
            int beforeCount;
            int afterCount;

            beforeCount = myQueue._claims.Count;
            myQueue.Add(myClaim4);
            afterCount = myQueue._claims.Count;
            Assert.AreEqual(afterCount, beforeCount + 1);
        }


        [TestMethod]
        public void Test_Peek_Does_Not_Dequeue()
        {
            int beforeCount;
            int afterCount;
            Claim result;

            beforeCount = myQueue._claims.Count;
            result = myQueue.Peek();
            afterCount = myQueue._claims.Count;
            Assert.AreEqual(beforeCount, afterCount);
        }

        [TestMethod]
        public void Test_Peek_Returns_Object()
        {
            Claim result;
            result = myQueue.Peek();
            Assert.IsNotNull(result);
        }
    }
}
