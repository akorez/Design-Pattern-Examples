using System;
using System.IO;

namespace SOLIDPrinciples
{

    class Result
    {
        interface IMathOperations
        {
            int Calculate(int a, int b, string operation);

        }


        class CalculateClass : IMathOperations
        {
            public int Calculate(int a, int b, string operation)
            {
                int result = 0;

                switch (operation)
                {
                    case "add":
                        result = a + b;
                        break;
                    case "subtract":
                        result = a - b;
                        break;
                    case "multiply":
                        result = a * b;
                        break;
                    case "divide":
                        result = a / b;
                        break;

                    default:
                        break;
                }

                return result;
            }
        }


        public static int Calculate(int a, int b, string operation)
        {

            CalculateClass _calc = new CalculateClass();

            int result = _calc.Calculate(a, b, operation);

            return result;
        }

    }


    class Solution
    {
        public static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine().Trim());

            int b = Convert.ToInt32(Console.ReadLine().Trim());

            string operation = Console.ReadLine();

            int result = Result.Calculate(a, b, operation);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }

}
