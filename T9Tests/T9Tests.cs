using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling;

namespace T9Tests
{
    [TestClass]
    public class T9Tests
    {
        [TestMethod]
        public void SimpleStringEncode_Success()
        {
            var answer = T9.EncodeString("hello world");

            Assert.AreEqual("4433555 555666096667775553", answer);
        } 
        [TestMethod]
        public void SimpleStringEncode2_Success()
        {
            var answer = T9.EncodeString("foo  bar");

            Assert.AreEqual("333666 6660 022 2777", answer);
        }
        
        [TestMethod]
        public void CorrectEncodeRepeatinfLEtters_Success()
        {
            var answer = T9.EncodeString("aa bb b");

            Assert.AreEqual("2 2022 22022", answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DigitEncode_Fail()
        {
            T9.EncodeString("1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CapitalLetterEncoding_Fail()
        {
            T9.EncodeString("R");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyStringEncoding_Fail()
        {
            T9.EncodeString("");
        }

    }
}
