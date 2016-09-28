using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infomatrix_UnitTest
{
    [TestClass]
    public class UnitTest
    {
        //Task 1 (a)
        [TestMethod]
        public void TestSettledBetsHistory()
        {
            SettledBetHistoryTest obj = new SettledBetHistoryTest();
            int result = obj.GetSettledBetHistory().Count;
            Assert.AreEqual(2, result);
        }

        //Task 2 (a)
        [TestMethod]
        public void TestUnSettledBetsHistory()
        {
            UnSettledBetsTest obj = new UnSettledBetsTest();
            int result = obj.GetUnusualUnSettledBets();
            Assert.AreEqual(4, result);

        }

        //Task 2(b)
        [TestMethod]
        public void TestUnusualUnsettledBets()
        {
            UnSettledBetsTest obj = new UnSettledBetsTest();
            int result = obj.GetUsualHighlyUnsualBets(10);
            Assert.AreEqual(3, result);

        }

        //Task 2(c)
        [TestMethod]
        public void TestHighlyUnusualUnsettledBets()
        {
            UnSettledBetsTest obj = new UnSettledBetsTest();
            int result = obj.GetUsualHighlyUnsualBets(30);
            Assert.AreEqual(1, result);

        }

        //Task 2(d)
        [TestMethod]
        public void TestHighRiskUnsettledBets()
        {
            UnSettledBetsTest obj = new UnSettledBetsTest();
            int result = obj.GetHighestRiskBets();
            Assert.AreEqual(4, result);

        }
    }
}
