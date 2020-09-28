using System;
using Neteril.ComputationExpression.Instances;

namespace Calculator2
{
    public static class Calculator
    {
        public enum Operator
        {
            Add,
            Remove,
            Multiply,
            Divide
        }

        public static Option<double> ParseNumber(string input)
        {
            return double.TryParse(input, out var result) switch
            {
                true => Some.Of(result),
                _ => None<double>.Value
            };
        }

        public static Option<Operator> ParseOperator(string input)
        {
            return input switch
            {
                "+" => Some.Of(Operator.Add),
                "-" => Some.Of(Operator.Remove),
                "*" => Some.Of(Operator.Multiply),
                "/" => Some.Of(Operator.Divide),
                _ => None<Operator>.Value
            };
        }

        public static Option<double> Calculate(Operator op, double firstNumber, double secondNumber)
        {
            return op switch
            {
                Operator.Add => Some.Of(firstNumber + secondNumber),
                Operator.Remove => Some.Of(firstNumber - secondNumber),
                Operator.Multiply => Some.Of(firstNumber * secondNumber),
                Operator.Divide => Some.Of(firstNumber / secondNumber),
                _ => None<double>.Value
            };
        }
        
        public static void PrintResult<T> (Option<T> maybe)
        {
            switch (maybe)
            {
                case None<T> n:
                    Console.WriteLine ("Введите корректные данные");
                    break;
                case Some<T> s:
                    Console.WriteLine ($"Результат: {(T)s}");
                    break;
            }
        }
    }
}