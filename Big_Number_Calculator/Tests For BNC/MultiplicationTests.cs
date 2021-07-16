using Microsoft.VisualStudio.TestTools.UnitTesting;
using Big_Number_Calculator;

namespace Tests_For_BNC
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void Ordinary_Test()
        {
            BigNumber x1 = "636";
            BigNumber y1 = "44";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "27984";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothPosNums1()
        {
            BigNumber x1 = "40000000";
            BigNumber y1 = "2";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "80000000";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothPosNums2()
        {
            BigNumber y1 = "999928273";
            BigNumber x1 = "24223412312";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "24221674839305097176";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothNegNums1()
        {
            BigNumber x1 = "-555555555";
            BigNumber y1 = "-66";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "36666666630";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothNegNums2()
        {
            BigNumber x1 = "-80";
            BigNumber y1 = "-333333333";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "26666666640";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void BothNegNums3()
        {
            BigNumber x1 = "-80918293879871923";
            BigNumber y1 = "-99928372";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "8086033372433164833899356";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void MultiplyByOne()
        {
            BigNumber x1 = "80918293879871923";
            BigNumber y1 = "1";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "80918293879871923";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void MultiplyByNegativeOne()
        {
            BigNumber x1 = "656767834563456567";
            BigNumber y1 = "-1";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "-656767834563456567";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void PositiveNegative1()
        {
            BigNumber x1 = "111111111";
            BigNumber y1 = "-111111111";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "-12345678987654321";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void PositiveNegative2()
        {
            BigNumber x1 = "-82398172983812382837";
            BigNumber y1 = "1";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "-82398172983812382837";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void MultiplyByZero1()
        {
            BigNumber x1 = "6786346345345667";
            BigNumber y1 = "0";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "0";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void MultiplyByZero2()
        {
            BigNumber x1 = "-672345234567";
            BigNumber y1 = "0";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "0";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void MultiplyByZero3()
        {
            BigNumber x1 = "-673453452345567";
            BigNumber y1 = "-0";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "0";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void MultiplyByZero4()
        {
            BigNumber x1 = "23456568345";
            BigNumber y1 = "-0";

            BigNumber result = BigNumberCalculator.Multiply(x1, y1);
            BigNumber expected = "0";
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
    }
}
