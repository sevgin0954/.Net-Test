using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
	public class Program
	{
		static void Main()
		{
			var nums = new int[] { 40, -1, 110 };
			var targetSum = 149;
			var signsCombination = GetAllPossibleSigns(nums, targetSum);

			Console.WriteLine(string.Join(",", signsCombination));
		}

		public static IList<string> GetAllPossibleSigns(int[] nums, int targetSum)
		{
			Validator.NullArgumentValidator(nums, nameof(nums));
			if (nums.Length == 0)
			{
				return new List<string>();
			}

			var signsCombination = new List<string>();

			GetAllPossibleSignsRecursive(nums, new List<string>(), 1, targetSum - nums[0], 0, signsCombination);

			var resultCombinations = signsCombination
				.Select(str => nums[0] + str)
				.ToArray();

			return resultCombinations;
		}

		private static void GetAllPossibleSignsRecursive(
			int[] nums,
			IList<string> currentCharacters,
			int currentIndex,
			int targetSum,
			int currentSum,
			List<string> resultSigns
			)
		{
			if (currentIndex == nums.Length)
			{
				if (targetSum == currentSum)
				{
					var currentSignsAsString = string.Join(string.Empty, currentCharacters);
					resultSigns.Add(currentSignsAsString);
				}

				return;
			}

			var currentNum = nums[currentIndex];

			AddSignWithNumber(currentCharacters, currentNum, "-");
			var substractedSum = currentSum - currentNum;
			GetAllPossibleSignsRecursive(nums, currentCharacters, currentIndex + 1, targetSum, substractedSum, resultSigns);
			RemoveLastNElement(currentCharacters, 2);

			var signToAdd = "+";
			if (currentNum < 0)
			{
				signToAdd = "";	
			}
			AddSignWithNumber(currentCharacters, currentNum, signToAdd);
			var addedSum = currentSum + currentNum;
			GetAllPossibleSignsRecursive(nums, currentCharacters, currentIndex + 1, targetSum, addedSum, resultSigns);
			RemoveLastNElement(currentCharacters, 2);
		}

		private static void AddSignWithNumber(IList<string> currentCharacters, int number, string sign)
		{
			currentCharacters.Add(sign);
			currentCharacters.Add(number.ToString());
		}

		private static void RemoveLastNElement<T>(IList<T> currentSigns, int count)
		{
			while (count > 0)
			{
				var lastIndex = currentSigns.Count - 1;
				currentSigns.RemoveAt(lastIndex);

				count--;
			}
		}
	}
}
