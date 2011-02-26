using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Griz.Core.Extensions
{
	public static class EnumerableExtensions
	{
		public static string ToString<T>(this IEnumerable<T> source, string separator)
		{
			// NOTE: Logic from http://www.codemeit.com/linq/c-array-delimited-tostring.html

			if (source == null)
				throw new ArgumentNullException("source", "Source value cannot be null.");

			if (StringExtensions.IsNullOrEmpty(separator))
				throw new ArgumentException("separator", "Separator value cannot be null or empty.");

			string[] array = source
				.Where(x => x != null)
				.Select(x => x.ToString())
				.ToArray();

			return string.Join(separator, array);
		}

		public static string ToString(this IEnumerable source, string separator)
		{
			// NOTE: Logic from http://www.codemeit.com/linq/c-array-delimited-tostring.html

			if (source == null)
				throw new ArgumentNullException("source", "Source value cannot be null.");

			if (StringExtensions.IsNullOrEmpty(separator))
				throw new ArgumentException("separator", "Separator value cannot be null or empty.");

			string[] array = source
				.Cast<object>()
				.Where(x => x != null)
				.Select(x => x.ToString())
				.ToArray();

			return string.Join(separator, array);
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
		{
			if (source == null) return true;

			return !source.Any();
		}

		public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
		{
			return !source.IsNullOrEmpty();
		}
	}
}
