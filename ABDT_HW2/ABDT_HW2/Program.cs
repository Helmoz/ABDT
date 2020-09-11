using System;

namespace ABDT_HW2
{
	public class Calculator
	{
		private long Pow10(long pow) => (long)Math.Pow(10, pow);
		
		public (long, long) GetDigitCapacity(long number)
		{
			var sum = 0L;
			var capacity = 0L;
 
			while (true)
			{
				var add = 9 * Pow10(capacity) * (capacity + 1);
        
				if (sum + add > number)
				{
					return (sum, capacity + 1);
				}
        
				sum += add;
				capacity++;
			}
		}

		public long GetNumber(long capacity, long number)
		{
			return Pow10(capacity - 1) + number;
		}

		public int GetDigit(long source, long capacity, long digitNumber)
		{
			return (int)((source / Pow10(capacity - digitNumber - 1)) % 10);
		}

		public int CalculateNDigit(long sourceNumber)
		{
			var (sum, capacity) = GetDigitCapacity(sourceNumber--);
			sourceNumber -= sum;
			
			var number = GetNumber(capacity, sourceNumber / capacity);
			
			return GetDigit(number, capacity, sourceNumber % capacity);
    
		}
	}

	internal static class Program
	{
		private static void Main(string[] args)
		{
			var calculator = new Calculator();
			while (true)
			{
				Console.WriteLine("Введите N");
				long.TryParse(Console.ReadLine(), out var n);
				if (n == 0)
				{
					break;
				}
				Console.WriteLine(calculator.CalculateNDigit(n));
			}
		}
	}
}
