using Challenge4.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Challenge4.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        OutingsRepo _outings = new OutingsRepo();
        [TestInitialize]
        public void Arrange()
        {
            // nothing to be done here due to scope of unit tests
        }

        [TestMethod]
        public void Test_Add()
        {
            DateTime outing1Date = new DateTime(2021, 10, 15);
            Outing outing1 = new Outing(Event.Golf, 20, outing1Date, 50m);
            int listLength = _outings._outingList.Count;
            _outings.AddOuting(outing1);
            Assert.AreEqual(_outings._outingList.Count, listLength + 1);
        }
        [TestMethod]
        public void Test_GetCombinedCost()
        {
            DateTime outing1Date = new DateTime(2021, 10, 15);
            Outing outing1 = new Outing(Event.Golf, 20, outing1Date, 50m);

            DateTime outing2Date = new DateTime(2021, 10, 22);
            Outing outing2 = new Outing(Event.Concert, 30, outing2Date, 30m);

            _outings.AddOuting(outing1);
            _outings.AddOuting(outing2);

            decimal result = _outings.GetCombinedCost();
            Assert.AreEqual(30 * 30 + 20 * 50, result);
        }

        [TestMethod]
        public void Test_GetCostByType()
        {
            DateTime outing1Date = new DateTime(2021, 10, 15);
            Outing outing1 = new Outing(Event.Golf, 20, outing1Date, 50m);

            DateTime outing2Date = new DateTime(2021, 10, 22);
            Outing outing2 = new Outing(Event.Concert, 30, outing2Date, 30m);

            _outings.AddOuting(outing1);
            _outings.AddOuting(outing2);

            decimal result = _outings.GetCostByType(Event.Concert);
            Assert.AreEqual(30 * 30, result);
        }
    }

}
