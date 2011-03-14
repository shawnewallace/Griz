using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Heuristics.Library.DesignByContract;
using Heuristics.Library.Extensions;

namespace Heuristics.LearningBuilder.Extensions {
    
	/// <summary>
	/// This is a sort of a holding bin for extensions that belong in the library, but do not. Since
	/// releasing a new version of the library is time consuming, we can put them here temporarily until
	/// there are enough to justify a new library release (or until we have to modify the library for some
	/// other reason). Code should NOT linger here for very long.
	/// </summary>
	public static class ToBeMovedToLibraryExtensions {

		/// <summary>
		/// Returns the value at the specified key. If the key does not exist in the dictionary, then
		/// default(TValue) is returned.
		/// </summary>
		public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey p_key) {
			return dictionary.GetOrDefault(p_key, default(TValue));
		}

		/// <summary>
		/// Returns the value at the specified key, or the specified default value if the key is not in the dictionary.
		/// </summary>
		public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey p_key, TValue p_default) {
			Require.That(dictionary != null, "Cannot execute this extension on a null dictionary");

			return dictionary.ContainsKey(p_key)
				? dictionary[p_key]
				: p_default;
		}

		/// <summary>
		/// Joins two strings with the specified delimiter between them, ignoring any 
		/// null or empty values. (That is, if either string is null or empty then
		/// the result is the other string with no delimiter).
		/// </summary>
		public static string JoinWith(this string p_baseString, string p_delimiter, string p_joinWith) {
			bool baseIsEmpty = p_baseString.IsNullOrEmpty();
			bool joinWithIsEmpty = p_joinWith.IsNullOrEmpty();

			if (!baseIsEmpty && !joinWithIsEmpty)
				return p_baseString + p_delimiter + p_joinWith;
			else if (!baseIsEmpty && joinWithIsEmpty)
				return p_baseString;
			else if (baseIsEmpty && !joinWithIsEmpty)
				return p_joinWith;
			else
				return String.Empty;
		}

		public static string ToYesNo(this Boolean p_value) {
			return p_value ? "Yes" : "No";
		}

		/// <summary>
		/// Returns one number's percentage of a total as a decimal number, where "62.5%" is represented
		/// as "62.5".
		/// </summary>
		public static double GetPercentageOf(this int p_fractionalAmount, int p_total) {
			return ((double)p_fractionalAmount / (double)p_total) * 100d;
		}

		public static bool IsNullOrLessThan(this DateTime? p_date, DateTime p_lessThan) {
			return (p_date == null) || (p_date.Value < p_lessThan);
		}

		public static bool IsNullOrGreaterThan(this DateTime? p_date, DateTime p_greaterThan) {
			return (p_date == null) || (p_date.Value > p_greaterThan);
		}
	}
}
