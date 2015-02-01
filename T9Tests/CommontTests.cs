using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling;

namespace T9Tests
{
    [TestClass]
    public class CommontTests
    {
        [TestMethod]
        public void DataCorrect_TestPass()
        {
            var data = new[] {"2", "hi", "hi there"};
            InputChecker.CheckData(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CounterAndTestNotMatch_Fail()
        {
            var data = new[] { "1", "hi", "hi there" };
            InputChecker.CheckData(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CounterNaN_Fail()
        {
            var data = new[] { "r", "hi", "hi there" };
            InputChecker.CheckData(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CounterLowBound_Fail()
        {
            var data = new[] { "0" };
            InputChecker.CheckData(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CounterTopBound_Fail()
        {
            var data = new[] { "1001" };
            InputChecker.CheckData(data);
        }
    }
}
