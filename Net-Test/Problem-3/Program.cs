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
			IList<string> currentSigns,
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
					var currentSignsAsString = string.Join(string.Empty, currentSigns);
					resultSigns.Add(currentSignsAsString);
				}

				return;
			}

			var currentNum = nums[currentIndex];

			currentSigns.Add("-");
			currentSigns.Add(currentNum.ToString());
			var substractedSum = currentSum - currentNum;
			GetAllPossibleSignsRecursive(nums, currentSigns, currentIndex + 1, targetSum, substractedSum, resultSigns);
			RemoveLastNElement(currentSigns, 2);

			var signToAdd = "+";
			if (currentNum < 0)
			{
				signToAdd = "";	
			}
			currentSigns.Add(signToAdd);
			currentSigns.Add(currentNum.ToString());
			var addedSum = currentSum + currentNum;
			GetAllPossibleSignsRecursive(nums, currentSigns, currentIndex + 1, targetSum, addedSum, resultSigns);
			RemoveLastNElement(currentSigns, 2);
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
