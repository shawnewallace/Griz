using System;

namespace Griz.Core.Extensions
{
	public static class StringExtensions
	{
		public static string Left(this string instance, int length)
		{
            if (length > instance.Length) return instance;

			return length <= 0
				? instance
				: instance.Substring(0, length);
		}

		public static string Right(this string instance, int length)
		{
			return length <= 0
				? instance
				: instance.Substring(instance.Length - length, length);
		}

		public static bool ToBoolean(this char instance)
		{
		    return instance == 'Y';
		}

	    public static int ToInt32(this string instance)
		{
			return Convert.ToInt32(instance);
		}

		public static bool IsNullOrEmpty(this string instance)
		{
			return string.IsNullOrEmpty(instance);
		}

		public static bool IsNotNullOrEmpty(this string instance)
		{
			return !instance.IsNullOrEmpty();
		}
	}
}
