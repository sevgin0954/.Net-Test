using Common;
using Problem_2;
using System;
using Xunit;

namespace Net_Test.Problem_2
{
	public class CalculateTrailingZeroesTests
	{
		[Fact]
		public void WithNegativeNumber_ShouldThrowException()
		{
			Assert.Throws<ArgumentException>(() => Program.CalculateTrailingZeroes(-1));
		}

		[Fact]
		public void WithNegativeNumber_ShouldThrowExceptionWithCorrectMessage()
		{
			var num = -1;

			var exception = Assert.ThrowsAny<Exception>(() => Program.CalculateTrailingZeroes(num));

			var expectedMessage = string.Format(ConstantErrors.NegativeNumber, "num");
			Assert.Contains(expectedMessage, exception.Message);
		}

		[Fact]
		public void WithZeroNumber_ShouldReturnZero()
		{
			var num = 0;

			var result = Program.CalculateTrailingZeroes(num);

			var expectedResult = 0;
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void WithNumberLessThanFive_ShouldReturnZero()
		{
			var num = 4;

			var result = Program.CalculateTrailingZeroes(num);

			var expectedResult = 0;
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void WithNumberThatDividedByFiveCanBeDividedAgainByFive_ShouldReturnCorrectResult()
		{
			var num = 125;

			var result = Program.CalculateTrailingZeroes(num);

			var expectedResult = 31;
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void WithNumberThatCanBeDividedByFiveOnce_ShouldReturnCorrectResult()
		{
			var num = 24;

			var result = Program.CalculateTrailingZeroes(num);

			var expectedResult = 4;
			Assert.Equal(expectedResult, result);
		}
	}
}
