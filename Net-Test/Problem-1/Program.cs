using Common;
using System;
using System.Linq;

namespace Problem_1
{
	public class Program
	{
		static void Main()
		{
			var nums = new int[] { 7, 7, 12, 98, 106 };

			var lowestNumIndex = GetLowestNumberIndex(nums);
			var greatestNumIndex = GetGreatestNumberIndex(nums);

			var secondLowestNumIndex = GetLowestNumberIndex(nums, lowestNumIndex);
			var secondHightestNumIndex = GetGreatestNumberIndex(nums, greatestNumIndex);

			var filteredNums = nums
				.Where((num, index) => index != secondLowestNumIndex && index != secondHightestNumIndex);

			Console.WriteLine(string.Join(", ", filteredNums));
		}

		public static int GetLowestNumberIndex(int[] nums, int excludeNumIndex = -1)
		{
			Validator.NullArgumentValidator(nums, nameof(nums));
			Validator.IndexValidator(nums, excludeNumIndex, nameof(excludeNumIndex));

			Func<int, int, bool> predicate = (currentNum, greatestNum) => currentNum < greatestNum;
			var lowestNumIndex = GetGreatestNumberIndex(nums, predicate, excludeNumIndex);

			return lowestNumIndex;
		}

		public static int GetGreatestNumberIndex(int[] nums, int excludeNumIndex = -1)
		{
			Validator.NullArgumentValidator(nums, nameof(nums));
			Validator.IndexValidator(nums, excludeNumIndex, nameof(excludeNumIndex));

			Func<int, int, bool> predicate = (currentNum, greatestNum) => currentNum > greatestNum;
			var greatestNumIndex = GetGreatestNumberIndex(nums, predicate, excludeNumIndex);

			return greatestNumIndex;
		}

		private static int GetGreatestNumberIndex(int[] nums, Func<int, int, bool> predicate, int excludeNumIndex = -1)
		{
			var greatestNumIndex = -1;
			var greatestNum = 0;

			for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
			{
				var currentNum = nums[currentIndex];

				if (ShouldExcludeNumber(nums, currentNum, excludeNumIndex))
				{
					continue;
				}

				if (greatestNumIndex == -1 || predicate.Invoke(currentNum, greatestNum))
				{
					greatestNum = currentNum;
					greatestNumIndex = currentIndex;
				}
			}

			return greatestNumIndex;
		}

		private static bool ShouldExcludeNumber(int[] nums, int targetNum, int numToExcludeIndex)
		{
			var shouldExclude = false;

			if (numToExcludeIndex != -1)
			{
				var numToExclude = nums[numToExcludeIndex];
				if (targetNum == numToExclude)
				{
					shouldExclude = true;
				}
			}

			return shouldExclude;
		}
	}
}
