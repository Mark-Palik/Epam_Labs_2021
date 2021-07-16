using System;

namespace Big_Number_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello this is a calculator for really big numbers it supports following operations: +,-,*,/");
            Console.WriteLine("Enter first number :");
            string fNum = Console.ReadLine();
            Console.WriteLine("Enter second number :");
            string sNum = Console.ReadLine();
            Console.WriteLine("Enter desired operation :");
            string op = Console.ReadLine();
            BigNumber a = new BigNumber(fNum);
            BigNumber b = new BigNumber(sNum);
            BigNumber c = new BigNumber();
            switch (op)
            {
                case "+":
                    c = a + b;
                    break;
                case "-":
                    c = a - b;
                    break;
                case "/":
                    c = a / b;
                    break;
                case "*":
                    c = a * b;
                    break;
            }
            Console.WriteLine(c);
        }
    }
}
