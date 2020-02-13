using Common;
using Problem_1;
using System;
using Xunit;

namespace Net_Test.Problem_1_Tests
{
	public class GetLowestNumberIndexTests
	{
		[Fact]
		public void WithNullNumsCollection_ShouldThrowException()
		{
			Assert.Throws<ArgumentNullException>(() => Program.GetLowestNumberIndex(null));
		}

		[Fact]
		public void WithNullNumsCollection_ShouldThrowExceptionWithCorrectMessage()
		{
			var exception = Assert.ThrowsAny<Exception>(() => Program.GetLowestNumberIndex(null));

			var expectedMessage = string.Format(ConstantErrors.NullArgument, "nums");
			Assert.Contains(expectedMessage, exception.Message);
		}

		[Fact]
		public void WithOutOfRangeExcludeIndex_ShouldThrowException()
		{
			var nums = new int[] { 1, 2 };
			var excludeIndex = 3;

			Assert.Throws<ArgumentOutOfRangeException>(() => Program.GetLowestNumberIndex(nums, excludeIndex));
		}

		[Fact]
		public void WithEmptyNumsCollection_ShouldReturnMinusOneIndex()
		{
			var nums = new int[0];

			var resultIndex = Program.GetLowestNumberIndex(nums);

			var expectedIndex = -1;
			Assert.Equal(expectedIndex, resultIndex);
		}

		[Fact]
		public void WithNums_ShouldReturnLowestNumIndex()
		{
			var nums = new int[] { 2, 1, 3 };

			var resultIndex = Program.GetLowestNumberIndex(nums);

			var expectedIndex = 1;
			Assert.Equal(expectedIndex, resultIndex);
		}

		[Fact]
		public void WithNumsWithExcludedIndex_ShouldReturnLowestNumIndexWithoutTheExcludedNum()
		{
			var nums = new int[] { 2, 1, 3 };
			var excludedIndex = 1;

			var resultIndex = Program.GetLowestNumberIndex(nums, excludedIndex);

			var expectedIndex = 0;
			Assert.Equal(expectedIndex, resultIndex);
		}
	}
}
