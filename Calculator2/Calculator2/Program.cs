using System;
using Neteril.ComputationExpression;
using Neteril.ComputationExpression.Instances;

namespace Calculator2
{
    public static class Program
    {
        private static void Main()
        {
            var result = ComputationExpression.Run<double, Option<double>>(new MaybeBuilder(), async () =>
            {
                var firstNumber = await Calculator.ParseNumber(Console.ReadLine());
                var op = await Calculator.ParseOperator(Console.ReadLine());
                var secondNumber = await Calculator.ParseNumber(Console.ReadLine());
                var calculate = await Calculator.Calculate(op, firstNumber, secondNumber);

                return calculate;
            });
            
            Calculator.PrintResult(result);
        }
    }
}