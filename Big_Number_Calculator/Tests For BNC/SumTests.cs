using Microsoft.VisualStudio.TestTools.UnitTesting;
using Big_Number_Calculator;

namespace Tests_For_BNC
{
    [TestClass]
    public class SumTests
    {
        [TestMethod]
        public void BothPosNums()
        {
            BigNumber x1 = "45000";
            BigNumber y1 = "15000";

            BigNumber result = BigNumberCalculator.Add(x1, y1);
            BigNumber expected = "60000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothNegNums()
        {
            BigNumber x1 = "-45000";
            BigNumber y1 = "-15000";

            BigNumber result = BigNumberCalculator.Add(x1, y1);
            BigNumber expected = "-60000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void OneNegOnePosNum1()
        {
            BigNumber x1 = "-45000";
            BigNumber y1 = "15000";

            BigNumber result = BigNumberCalculator.Add(x1, y1);
            BigNumber expected = "-30000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void OneNegOnePosNum2()
        {
            BigNumber x1 = "45000";
            BigNumber y1 = "-15000";

            BigNumber result = BigNumberCalculator.Add(x1, y1);
            BigNumber expected = "30000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void NegZeroTest1()
        {
            BigNumber x1 = "45000";
            BigNumber y1 = "-0";

            BigNumber result = BigNumberCalculator.Add(x1, y1);
            BigNumber expected = "45000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void NegZeroTest2()
        {
            BigNumber x1 = "-45000";
            BigNumber y1 = "-0";

            BigNumber result = BigNumberCalculator.Add(x1, y1);
            BigNumber expected = "-45000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void HugeNumTest()
        {
            BigNumber x1 = "123456789123456789123456789";
            BigNumber y1 = "655655757858958";

            BigNumber result = BigNumberCalculator.Add(x1, y1);
            BigNumber expected = "123456789124112444881315747";

            // E: 1234567891241124448811315747
            // A: 123456789124112444881315747
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
    }
}
