using System;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixMultiply
{
    public class Matrix
    {
        public static Func<Matrix, Matrix, Matrix> MultiplyMethod = ParallelForMultiply;

        public Matrix(long firstDimension, long secondDimension)
        {
            InnerMatrix = new int[firstDimension, secondDimension];
            Initialize();
        }

        public Matrix(int[,] matrix)
        {
            InnerMatrix = matrix;
        }

        public int[,] InnerMatrix { get; }
        
        public long Rows => InnerMatrix.GetUpperBound(0) + 1;

        public long Columns => InnerMatrix.GetUpperBound(1) + 1;

        public int this[long firstIndex, long secondIndex]
        {
            get => InnerMatrix[firstIndex, secondIndex];
            set => InnerMatrix[firstIndex, secondIndex] = value;
        }
        
        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            return MultiplyMethod.Invoke(firstMatrix, secondMatrix);
        }
        
        public static Matrix DefaultMultiply(Matrix firstMatrix, Matrix secondMatrix)
        {
            var result = new Matrix(firstMatrix.Rows, secondMatrix.Columns);

            for (var i = 0; i < firstMatrix.Rows; i++)
            {
                for (var j = 0; j < secondMatrix.Columns; j++)
                {
                    result[i, j] = 0;

                    for (var k = 0; k < firstMatrix.Columns; k++)
                    {
                        result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }

            return result;
        }
        
        public static Matrix LinqMultiply(Matrix firstMatrix, Matrix secondMatrix)
        {
            return new Matrix(firstMatrix.ToJaggedArray().Select(
                (row, rowIndex) =>
                    secondMatrix.ToJaggedArray()[0].Select(
                        (_, columnIndex) =>
                            secondMatrix.ToJaggedArray().Select(__ => __[columnIndex])
                                .Zip(row, (rowCell, columnCell) => rowCell * columnCell).Sum()
                    ).ToArray()
            ).ToArray().ToMultidimensionalArray());
        }

        public static Matrix ParallelForMultiply(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.Columns != secondMatrix.Rows)
            {
                throw new ArgumentException();
            }

            var result = new Matrix(firstMatrix.Rows, secondMatrix.Columns);
            Parallel.For(0, firstMatrix.Rows, i =>
                Parallel.For(0, secondMatrix.Columns, j =>
                    result[i, j] = InnerMultiply(firstMatrix, secondMatrix, i, j)));
            return result;
        }

        private static int InnerMultiply(Matrix firstMatrix, Matrix secondMatrix, long positionI, long positionJ)
        {
            var result = 0;
            for (var k = 0; k < firstMatrix.Columns; k++)
                result += firstMatrix[positionI, k] * secondMatrix[k, positionJ];

            return result;
        }
        
        private void Initialize()
        {
            var rnd = new Random();
            for (var i = 0; i < Rows; i++)
            for (var j = 0; j < Columns; j++)
                InnerMatrix[i, j] = rnd.Next(10);
        }
    }
}