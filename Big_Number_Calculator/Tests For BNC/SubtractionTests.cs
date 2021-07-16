using Microsoft.VisualStudio.TestTools.UnitTesting;
using Big_Number_Calculator;

namespace Tests_For_BNC
{
    [TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void BothPosNums1()
        {
            BigNumber x1 = "45000";
            BigNumber y1 = "15000";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "30000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothPosNums2()
        {
            BigNumber x1 = "15000";
            BigNumber y1 = "45000";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "-30000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothNegNums1()
        {
            BigNumber x1 = "-45000";
            BigNumber y1 = "-15000";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "-30000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothNegNums2()
        {
            BigNumber x1 = "-15000";
            BigNumber y1 = "-45000";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "30000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void OneNegOnePosNum1()
        {
            BigNumber x1 = "-450000";
            BigNumber y1 = "320000";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "-770000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void OneNegOnePosNum2()
        {
            BigNumber x1 = "450000";
            BigNumber y1 = "-320000";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "770000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void NegZeroTest1()
        {
            BigNumber x1 = "2354546";
            BigNumber y1 = "-0";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "2354546";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void NegZeroTest2()
        {
            BigNumber x1 = "-65345";
            BigNumber y1 = "-0";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "-65345";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void HugeNumTest()
        {
            BigNumber x1 = "123456789123456789123456789";
            BigNumber y1 = "655655757858958";

            BigNumber result = BigNumberCalculator.Subtract(x1, y1);
            BigNumber expected = "123456789122801133365597831";
            Assert.AreEqual(expected.ToString(), result.ToString());
        } 
    }
}
