using System;
using System.Linq;

namespace MatrixMultiply
{
    public static class MatrixExtensions
    {
        public static void Print(this Matrix matrix)
        {
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
        
        public static int[][] ToJaggedArray(this Matrix matrix)
        {
            var twoDimensionalArray = matrix.InnerMatrix;
            var rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            var rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            var numberOfRows = rowsLastIndex - rowsFirstIndex + 1;

            var columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            var columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            var numberOfColumns = columnsLastIndex - columnsFirstIndex + 1;

            var jaggedArray = new int[numberOfRows][];
            for (var i = 0; i < numberOfRows; i++)
            {
                jaggedArray[i] = new int[numberOfColumns];

                for (var j = 0; j < numberOfColumns; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i + rowsFirstIndex, j + columnsFirstIndex];
                }
            }
            return jaggedArray;
        }
        
        public static int[,] ToMultidimensionalArray(this int[][] source)
        {
            var first = source.Length;
            var second = source.GroupBy(row => row.Length).Single().Key;

            var result = new int[first, second];
            for (var i = 0; i < first; ++i)
            {
                for (var j = 0; j < second; ++j)
                {
                    result[i, j] = source[i][j];
                }
            }

            return result;
            
        }
    }
}