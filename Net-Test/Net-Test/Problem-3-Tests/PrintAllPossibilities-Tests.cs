using Common;
using Problem_3;
using System;
using Xunit;

namespace Net_Test.Problem_3_Tests
{
	public class PrintAllPossibilities_Tests
	{
		[Fact]
		public void WithNullNumsCollection_ShouldThrowException()
		{
			Assert.Throws<ArgumentNullException>(() => Program.GetAllPossibleSigns(null, 0));
		}

		[Fact]
		public void WithNullNumsCollection_ShouldThrowExceptionWithCorrectMessage()
		{
			var exception = Assert.ThrowsAny<Exception>(() => Program.GetAllPossibleSigns(null, 0));

			var expectedMessage = string.Format(ConstantErrors.NullArgument, "nums");
			Assert.Contains(expectedMessage, exception.Message);
		}

		[Fact]
		public void WithEmptyNumsCollection_ShouldReturnEmptyCollection()
		{
			var nums = new int[0];

			var result = Program.GetAllPossibleSigns(nums, 0);

			Assert.Empty(result);
		}

		[Theory]
		[InlineData(new int[] { 1 })]
		[InlineData(new int[] { -1, 2, 8 })]
		public void WithNumsThatDontSumUpToTarget_ShouldReturnEmptyCollection(int[] nums)
		{
			var targetSum = 0;

			var result = Program.GetAllPossibleSigns(nums, targetSum);

			Assert.Empty(result);
		}

		[Fact]
		public void WithNumsThatSumUpToTarget_ShouldReturnCorrectResultCount()
		{
			var nums = new int[] { 1, 5 };
			var targetSum = 6;

			var result = Program.GetAllPossibleSigns(nums, targetSum);

			var expectedResult = $"{nums[0]}+{nums[1]}";
			Assert.Equal(expectedResult, result[0]);
		}

		[Fact]
		public void WithNumsThatSumUpToTarget_ShouldReturnCorrectResult()
		{
			var nums = new int[] { 1, 5 };
			var targetSum = 6;

			var result = Program.GetAllPossibleSigns(nums, targetSum);

			var expectedResultCount = 1;
			Assert.Equal(expectedResultCount, result.Count);
		}

		[Fact]
		public void WithNumsThatSubstrackToTrack_ShouldReturnCorrectResultCount()
		{
			var nums = new int[] { 1, 7 };
			var targetSum = -6;

			var result = Program.GetAllPossibleSigns(nums, targetSum);

			var expectedResultCount = 1;
			Assert.Equal(expectedResultCount, result.Count);
		}

		[Fact]
		public void WithNumsThatSubstrackToTrack_ShouldReturnCorrectResult()
		{
			var nums = new int[] { 1, 7 };
			var targetSum = -6;

			var result = Program.GetAllPossibleSigns(nums, targetSum);

			var expectedResult = $"{nums[0]}-{nums[1]}";
			Assert.Equal(expectedResult, result[0]);
		}

		[Fact]
		public void WithNumsCollectionWithManyPossibleCombinations_ShouldReturnCorrectResultsCount()
		{
			var nums = new int[] { 2, 3, 5, -3 };
			var targetSum = 7;

			var result = Program.GetAllPossibleSigns(nums, targetSum);

			var expectedResultCount = 2;
			Assert.Equal(expectedResultCount, result.Count);
		}

		[Fact]
		public void WithNumsCollectionWithManyPossibleCombinations_ShouldReturnCorrectResults()
		{
			var nums = new int[] { 2, 3, 5, -3 };
			var targetSum = 7;

			var result = Program.GetAllPossibleSigns(nums, targetSum);

			var expectedResults = new string[]
			{
				$"{nums[0]}-{nums[1]}+{nums[2]}-{nums[3]}",
				$"{nums[0]}+{nums[1]}+{nums[2]}{nums[3]}"
			};
			Assert.Contains(expectedResults[0], result);
			Assert.Contains(expectedResults[1], result);
		}
	}
}
