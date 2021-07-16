using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_Number_Calculator
{
    public static class BigNumberCalculator
    {
        public static BigNumber Add(BigNumber x, BigNumber y)
        {
            //Check for more suitable method
            if (x.IsNegative != y.IsNegative)
            {
                if (x.IsNegative)
                {
                    return Subtract(y, -x);
                }
                else
                {
                    return Subtract(x, -y);
                }
            }

            StringBuilder result = new();
            //Add additional 0's to smaller number for calculations that'll follow
            List<byte> xCopy = x.Digits.ToList();
            List<byte> yCopy = y.Digits.ToList();
            while (xCopy.Count > yCopy.Count)
            {
                yCopy.Insert(0, 0);
            }
            while (yCopy.Count > xCopy.Count)
            {
                xCopy.Insert(0, 0);
            }
            //Addition algorithm
            int remainder = 0;
            for (int i = xCopy.Count - 1; i >= 0; i--)
            {
                int temp = xCopy[i] + yCopy[i] + remainder;
                remainder = temp / 10;
                temp %= 10;
                result.Insert(0, temp);
            }
            if (remainder != 0)
            {
                result.Insert(0, remainder);
            }
            //Get final result
            var res = new BigNumber(result.ToString());
            if (x.IsNegative)
            {
                return -res;
            }
            else
            {
                return res;
            }
        }
        public static BigNumber Subtract(BigNumber x, BigNumber y)
        {
            //Check for more suitable method
            if (y.IsNegative)
            {
                return Add(x, -y);
            }
            if (x.IsNegative && !y.IsNegative)
            {
                return -Add(-x, y);
            }
            //Find out which of the numbers is bigger by mod
            int largerOne = x.ModCompareTo(y);
            //If they're equal, just return 0
            if (largerOne == 0)
            {
                return new BigNumber(0);
            }

            BigNumber larger = largerOne == 1 ? x : y;
            BigNumber smaller = largerOne == 1 ? y : x;

            StringBuilder result = new();
            //Copy digits so to not change original BigNumbers
            List<byte> largerCopy = larger.Digits.ToList();
            List<byte> smallerCopy = smaller.Digits.ToList();
            //Add additional 0's to smaller number for calculations that'll follow
            while (largerCopy.Count > smallerCopy.Count)
            {
                smallerCopy.Insert(0, 0);
            }
            //Substraction algorithm
            int carryOver = 0;
            for (int i = largerCopy.Count - 1; i >= 0; i--)
            {
                int temp = largerCopy[i] - smallerCopy[i] - carryOver;
                if (temp < 0)
                {
                    result.Insert(0, 10 + temp);
                    carryOver = 1;
                }
                else
                {
                    result.Insert(0, temp);
                    carryOver = 0;
                }
            }
            //Get final result
            BigNumber res = new(result.ToString());
            if (largerOne == -1)
            {
                return -res;
            }
            else
            {
                return res;
            }
        }
        public static BigNumber Multiply(BigNumber x, BigNumber y)
        {
            //if (x == 0) WRITE COMPARISON
            if (x.IsEqualToZero || y.IsEqualToZero)
            {
                return new BigNumber(0);
            }

            //Find out which of the numbers is bigger by mod
            int largerOne = x.ModCompareTo(y);
            BigNumber larger = largerOne == 1 ? x : y;
            BigNumber smaller = largerOne == 1 ? y : x;

            //Copy digits so to not change original BigNumbers
            List<byte> largerCopy = larger.Digits.ToList();
            List<byte> smallerCopy = smaller.Digits.ToList();

            //Calculations
            int zeroesToAdd = 0;
            BigNumber result = new();
            for (int i = smallerCopy.Count - 1; i >= 0; i--, zeroesToAdd++)
            {
                StringBuilder numberByDigitResult = SingleDigitMultiply(largerCopy, smallerCopy[i]);
                for (int j = 1; j <= zeroesToAdd; j++)
                {
                    numberByDigitResult.Append(0);
                }
                BigNumber temp = new(numberByDigitResult.ToString());
                result += temp;
            }

            if (x.IsNegative != y.IsNegative)
            {
                return -result;
            }
            else
            {
                return result;
            }
        }
        public static BigNumber DivideWhole(BigNumber x, BigNumber y)
        {
            if (y.IsEqualToZero)
            {
                throw new InvalidOperationException("Tried to divide by zero.");
            }
            if (x.IsEqualToZero || x.ModCompareTo(y) < 0)
            {
                return 0;
            }
            if (x.ModCompareTo(y) == 0)
            {
                if (x.IsNegative != y.IsNegative)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }

            StringBuilder result = new();
            BigNumber curValue = 0;

            for (int i = 0; i < x.Digits.Count; i++)
            {
                curValue += BigNumber.Exp(x.Digits[i], x.Digits.Count - 1 - i);

                var candidate = 0;
                var lower = 0;
                var upper = 10;
                while (lower <= upper)
                {
                    var currentCheck = (lower + upper) / 2;
                    var cur = y * BigNumber.Exp((byte)currentCheck, x.Digits.Count - 1 - i);
                    if (cur <= curValue)
                    {
                        candidate = currentCheck;
                        lower = currentCheck + 1;
                    }
                    else
                    {
                        upper = currentCheck - 1;
                    }
                }

                result.Append(candidate % 10);
                var divided = y * BigNumber.Exp((byte)candidate, x.Digits.Count - 1 - i);
                curValue -= divided;
            }

            var retValue = new BigNumber(result.ToString())
            {
                IsNegative = x.IsNegative != y.IsNegative
            };
            return retValue;
        }
        public static BigNumber DivideMod(BigNumber x, BigNumber y)
        {
            if (y.IsEqualToZero)
            {
                throw new InvalidOperationException("Tried to divide by zero.");
            }
            if (x.ModCompareTo(y) < 0)
            {
                BigNumber result = new(x.ToString());
                result.IsNegative = false;
                return result;
            }
            if (x.ModCompareTo(y) == 0)
            {
                return 0;
            }
            BigNumber retValue = 0;
            for (int i = 0; i < x.Digits.Count; i++)
            {
                retValue += BigNumber.Exp(x.Digits[i], x.Digits.Count - i - 1);

                var candidate = 0;
                var lower = 0;
                var upper = 10;

                while (lower <= upper)
                {
                    var currentCheck = (lower + upper) / 2;
                    var cur = y * BigNumber.Exp((byte)currentCheck, x.Digits.Count - i - 1);
                    if (cur <= retValue)
                    {
                        candidate = currentCheck;
                        lower = currentCheck + 1;
                    }
                    else
                    {
                        upper = currentCheck - 1;
                    }
                }
                retValue -= y * BigNumber.Exp((byte)candidate, x.Digits.Count - i - 1);
            }

            retValue.IsNegative = x.IsNegative != y.IsNegative;
            return retValue;
        }
        private static StringBuilder SingleDigitMultiply(List<byte> number, byte digit)
        {
            StringBuilder result = new();
            int temp;
            int remainder = 0;
            for (int i = number.Count - 1; i >= 0; i--)
            {
                temp = number[i] * digit + remainder;
                remainder = temp / 10;
                temp %= 10;
                result.Insert(0, temp);
            }
            result.Insert(0, remainder);
            return result;
        }
    }
}
