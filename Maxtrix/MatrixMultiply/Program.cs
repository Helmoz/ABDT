using System;
using System.Diagnostics;

namespace MatrixMultiply
{
    class Program
    {
        static void Main()
        {
            // var firstMatrix = new Matrix( new[,]
            // { 
            //     {1, 2, 3}, 
            //     {4, 5, 6} 
            // });
            // var secondMatrix = new Matrix( new[,]
            // {
            //     {7, 8}, 
            //     {9, 1}, 
            //     {2, 3}
            // });
            
            var firstMatrix = new Matrix(100, 100);
            var secondMatrix = new Matrix(100, 100);

            var defaultTimer = MeasureMultiply(firstMatrix, secondMatrix, Matrix.DefaultMultiply);
            var parallelTimer = MeasureMultiply(firstMatrix, secondMatrix, Matrix.ParallelForMultiply);
            var linqTimer = MeasureMultiply(firstMatrix, secondMatrix, Matrix.LinqMultiply);
            
            Console.WriteLine($"{parallelTimer} \n{defaultTimer} \n{linqTimer}");
            
        }

        private static long MeasureMultiply(Matrix firstMatrix, Matrix secondMatrix, Func<Matrix, Matrix, Matrix> type)
        {
            Matrix.MultiplyMethod = type;
            var timer = new Stopwatch();
            timer.Start();
            var _ = firstMatrix * secondMatrix;
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
    }
}