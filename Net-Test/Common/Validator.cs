using System;
using System.Collections.Generic;

namespace Common
{
	public static class Validator
	{
		public static void NullArgumentValidator(object obj, string argumentName)
		{
			if (obj == null)
			{
				var exceptionMessage = string.Format(ConstantErrors.NullArgument, argumentName);
				throw new ArgumentNullException(exceptionMessage);
			}
		}

		public static void IndexValidator<T>(IList<T> collection, int index, string argumentName)
		{
			if (index >= collection.Count)
			{
				throw new ArgumentOutOfRangeException(argumentName);
			}
		}
	}
}
