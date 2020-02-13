using Common;
using System;

namespace Problem_2
{
	public class Program
	{
		static void Main()
		{
			var num = 200;
			var zeroesCount = CalculateTrailingZeroes(num);

			Console.WriteLine(zeroesCount);
		}

		public static int CalculateTrailingZeroes(int num)
		{
			if (num < 0)
			{
				var expectedMessage = string.Format(ConstantErrors.NegativeNumber, nameof(num));
				throw new ArgumentException(expectedMessage);
			}

			var zeroesCount = CalculateTrailingZeroesRecursive(num);

			return zeroesCount;
		}

		private static int CalculateTrailingZeroesRecursive(int num)
		{
			if (num < 5)
			{
				return 0;
			}

			int fivesCount = num / 5;
			var fivesCountFactorielZeroesCount = CalculateTrailingZeroesRecursive(fivesCount);
			int zeroesCount = fivesCount + fivesCountFactorielZeroesCount;

			return zeroesCount;
		}
	}
}
