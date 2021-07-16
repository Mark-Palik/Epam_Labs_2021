using Microsoft.VisualStudio.TestTools.UnitTesting;
using Big_Number_Calculator;
using System;

namespace Tests_For_BNC
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void DivTest1()
        {
            BigNumber x1 = "445963";
            BigNumber y1 = "25";

            BigNumber result = BigNumberCalculator.DivideWhole(x1, y1);
            BigNumber expected = 17838;
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void DivTest2()
        {
            BigNumber x1 = "14";
            BigNumber y1 = "676321";

            BigNumber result = BigNumberCalculator.DivideWhole(x1, y1);
            BigNumber expected = 0;
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void DivTest3()
        {
            BigNumber x1 = "6";
            BigNumber y1 = "3";

            BigNumber result = BigNumberCalculator.DivideWhole(x1, y1);
            BigNumber expected = 2;
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void ModTest1()
        {
            BigNumber x1 = "345860";
            BigNumber y1 = "25";

            BigNumber result = BigNumberCalculator.DivideMod(x1, y1);
            BigNumber expected = 345860 % 25;
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void ModTest2()
        {
            BigNumber x1 = "15";
            BigNumber y1 = "687323";

            BigNumber result = BigNumberCalculator.DivideMod(x1, y1);
            BigNumber expected = 15;
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void ModTest3()
        {
            BigNumber x1 = "3";
            BigNumber y1 = "2";

            BigNumber result = BigNumberCalculator.DivideMod(x1, y1);
            BigNumber expected = 1;
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BigNumbersDiv()
        {
            BigNumber x1 = "123456789123456789123456789";
            BigNumber y1 = "6666666666666666";

            BigNumber result = BigNumberCalculator.DivideWhole(x1, y1);
            BigNumber expected = "18518518368";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BigNumbersMod()
        {
            BigNumber x1 = "123123123123123123123";
            BigNumber y1 = "45454545454545";

            BigNumber result = BigNumberCalculator.DivideMod(x1, y1);
            BigNumber expected = "32214033445263";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DivByZero()
        {
            BigNumber x1 = "-86765435679786545678765";
            BigNumber y1 = "0";

            BigNumberCalculator.DivideWhole(x1, y1);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DivByZeroMod()
        {
            BigNumber x1 = "-67543567898765";
            BigNumber y1 = "0";

            BigNumberCalculator.DivideMod(x1, y1);
        }
    }
}
