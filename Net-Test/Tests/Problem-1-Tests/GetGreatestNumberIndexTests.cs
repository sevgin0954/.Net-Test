using Common;
using Problem_1;
using System;
using Xunit;

namespace Net_Test.Problem_1_Tests
{
	public class GetGreatestNumberIndexTests
	{
		[Fact]
		public void WithNullNumsCollection_ShouldThrowException()
		{
			Assert.Throws<ArgumentNullException>(() => Program.GetGreatestNumberIndex(null));
		}

		[Fact]
		public void WithNullNumsCollection_ShouldThrowExceptionWithCorrectMessage()
		{
			var exception = Assert.ThrowsAny<Exception>(() => Program.GetGreatestNumberIndex(null));

			var expectedMessage = string.Format(ConstantErrors.NullArgument, "nums");
			Assert.Contains(expectedMessage, exception.Message);
		}

		[Fact]
		public void WithOutOfRangeExcludeIndex_ShouldThrowException()
		{
			var nums = new int[] { 1, 2 };
			var excludeIndex = 3;

			Assert.Throws<ArgumentOutOfRangeException>(() => Program.GetGreatestNumberIndex(nums, excludeIndex));
		}

		[Fact]
		public void WithEmptyNumsCollection_ShouldReturnMinusOneIndex()
		{
			var nums = new int[0];

			var resultIndex = Program.GetGreatestNumberIndex(nums);

			var expectedIndex = -1;
			Assert.Equal(expectedIndex, resultIndex);
		}

		[Fact]
		public void WithNums_ShouldReturnGreatestNumIndex()
		{
			var nums = new int[] { 1, 5, 3 };

			var resultIndex = Program.GetGreatestNumberIndex(nums);

			var expectedIndex = 1;
			Assert.Equal(expectedIndex, resultIndex);
		}

		[Fact]
		public void WithNumsWithExcludedIndex_ShouldReturnGreatestNumIndexWithoutTheExcludedNum()
		{
			var nums = new int[] { 1, 5, 3 };
			var excludedIndex = 1;

			var resultIndex = Program.GetGreatestNumberIndex(nums, excludedIndex);

			var expectedIndex = 2;
			Assert.Equal(expectedIndex, resultIndex);
		}
	}
}
