using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Big_Number_Calculator
{
    public class BigNumber : IComparable<int>
    {
        public List<byte> Digits = new();
        public bool IsNegative { get; set; }
        public bool IsEqualToZero { get { return Digits.Count == 1 && Digits[0] == 0; } }
        public static BigNumber Exp(byte val, int exp)
        {
            if (exp == 0)
            {
                return new BigNumber(val);
            }
            BigNumber bigInt = 0;
            for (int i = 1; i < exp; i++)
            {
                bigInt.Digits.Insert(0,0);
            }
            bigInt.Digits.Insert(0, val);
            return bigInt;
        }
        public BigNumber(string number)
        {
            if (!CheckValidityOfNumber(number))
            {
                throw new ArgumentException("Tried to assign non-comp string to BigNumber instance.");
            }
            try
            {
                StringBuilder sb = new(number.Trim());
                IsNegative = sb[0] == '-';
                if (IsNegative)
                {
                    sb.Remove(0, 1);
                }

                while (sb[0] == '0' && sb.Length > 1)
                {
                    sb.Remove(0, 1);
                }

                Digits = new();
                int i = 0;
                while (i < sb.Length)
                {
                    Digits.Add((byte)char.GetNumericValue(sb[i]));
                    i++;
                }

                if (Digits.Count == 1 && Digits[0] == 0)
                {
                    IsNegative = false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Number is too short");
            }
            catch
            {
                throw new ArgumentException($"Something's wrong with {number}");
            }
        }
        public BigNumber(int number) : this(number.ToString()) { }
        public BigNumber() : this(0) { }
        public override string ToString()
        {
            StringBuilder result = new();
            if (IsNegative)
            {
                result.Append('-');
            }
            for (int i = 0; i < Digits.Count; i++)
            {
                result.Append(Digits[i]);
            }

            return result.ToString();
        }
        public static bool CheckValidityOfNumber(string number)
        {
            number = number.Trim();
            try
            {
                int i = 0;
                if (number[i] == '-')
                {
                    i = 1;
                }
                while (i < number.Length)
                {
                    if (!char.IsDigit(number[i]))
                    {
                        return false;
                    }
                    i++;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int ModCompareTo(BigNumber other)
        {
            if (Digits.Count > other.Digits.Count)
            {
                return 1;
            }
            if (Digits.Count < other.Digits.Count)
            {
                return -1;
            }

            for (int i = 0; i < Digits.Count; i++)
            {
                if (Digits[i] > other.Digits[i])
                {
                    return 1;
                }
                if (Digits[i] < other.Digits[i])
                {
                    return -1;
                }
            }
            return 0;

        }
        public int CompareTo(BigNumber other)
        {
            BigNumber result = this - other;
            if (result.IsEqualToZero)
            {
                return 0;
            }
            else if (result.IsNegative)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        public int CompareTo(int other)
        {
            BigNumber result = this - new BigNumber(other);
            if (result.IsEqualToZero)
            {
                return 0;
            }
            else if (result.IsNegative)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        public static BigNumber operator /(BigNumber x, BigNumber y)
        {
            return BigNumberCalculator.DivideWhole(x, y);
        }
        public static BigNumber operator *(BigNumber x, BigNumber y)
        {
            return BigNumberCalculator.Multiply(x, y);
        }
        public static BigNumber operator +(BigNumber x, BigNumber y)
        {
            return BigNumberCalculator.Add(x, y);
        }
        public static BigNumber operator -(BigNumber x, BigNumber y)
        {
            return BigNumberCalculator.Subtract(x, y);
        }
        public static BigNumber operator -(BigNumber x)
        {
            BigNumber result = new();
            result.Digits = x.Digits.ToList();
            result.IsNegative = !x.IsNegative;
            return result;
        }
        public static implicit operator BigNumber(string number)
        {
            return new BigNumber(number);
        }
        public static implicit operator BigNumber(int number)
        {
            return new BigNumber(number);
        }
        public static bool operator <(BigNumber a, BigNumber b) => a.CompareTo(b) < 0;

        public static bool operator >(BigNumber a, BigNumber b) => a.CompareTo(b) > 0;

        public static bool operator <=(BigNumber a, BigNumber b) => a.CompareTo(b) <= 0;

        public static bool operator >=(BigNumber a, BigNumber b) => a.CompareTo(b) >= 0;

        public static bool operator ==(BigNumber a, BigNumber b) => a.CompareTo(b) == 0;

        public static bool operator !=(BigNumber a, BigNumber b) => a.CompareTo(b) != 0;

        public override bool Equals(object obj) => obj is BigNumber number && this == number;

        public override int GetHashCode()
        {
            return Digits.GetHashCode();
        }
    }
}
