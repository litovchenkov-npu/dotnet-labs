using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseCalculator calc = new BaseCalculator();

            double firstNumber = getNumber("Enter the first number: ");
            calc.num.a = firstNumber;

            double secondNumber = getNumber("Enter the second number: ");
            calc.num.b = secondNumber;

            char operation = getOperation("Select an operation (+, -, *, /): ");
            double result = calc.SelectOperation(operation);

            Console.WriteLine($"Result: {result}");
        }

        static double getNumber(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;
                else
                    Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static char getOperation(string prompt)
        {
            char operation;
            while (true)
            {
                Console.Write(prompt);
                operation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (operation == '+' || operation == '-' || operation == '*' || operation == '/')
                    return operation;
                else
                    Console.WriteLine("Invalid operation. Please select +, -, *, or /.");
            }
        }

        public struct Numbers
        {
            public double a, b;
        }

        public interface ICalculator
        {
            double Add();
            double Sub();
            double Mul();
            double Div();
        }

        public class BaseCalculator : ICalculator
        {
            public Numbers num = new Numbers();

            public double SelectOperation(char operation)
            {
                switch (operation)
                {
                    case '+': return Add();
                    case '-': return Sub();
                    case '*': return Mul();
                    case '/': return Div();
                    default: throw new InvalidOperationException("Invalid operation");
                }
            }

            public double Add() => num.a + num.b;

            public double Sub() => num.a - num.b;

            public double Mul() => num.a * num.b;

            public double Div()
            {
                if (num.b == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    return double.NaN;
                }
                return num.a / num.b;
            }
        }
    }
}
