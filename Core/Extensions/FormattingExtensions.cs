using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heuristics.LearningBuilder.Extensions {
	public static class FormattingExtensions {
		public static string ToCurrencyFormat(this decimal p_value) {
			// todo: We should format the value according to the current culture, but on my 
			// test system the proper format string isn't being applied. Hardcoding to US culture 
			// for now.
			var value = Math.Round(p_value, 2);
			if (value < 0) return String.Format("<span class='red'>{0:c}</span>", Math.Round(p_value, 2));
			else return String.Format("{0:c}", Math.Round(p_value, 2));
		}

		public static string ToCurrencyFormat(this decimal? p_value) {
			// todo: We should format the value according to the current culture, but on my 
			// test system the proper format string isn't being applied. Hardcoding to US culture 
			// for now.
			if (p_value.HasValue) {
				var value = Math.Round(p_value.Value, 2);
				if (value < 0) return String.Format("<span class='red'>{0:c}</span>", Math.Round(p_value.Value, 2));

				else return String.Format("{0:c}", Math.Round(p_value.Value, 2));
			} else
				return String.Empty;
		}

		public static string ToCurrencyFormat(this decimal? p_value, string p_ifNullOrZero) {
			if ((p_value ?? 0m) == 0m)
				return p_ifNullOrZero;

			return (p_value ?? 0m).ToCurrencyFormat();
		}

		public static string ToCurrencyFormat(this decimal p_value, string p_ifZero) {
			if (p_value == 0m)
				return p_ifZero;

			return p_value.ToCurrencyFormat();
		}

		public static string ToCurrencyFormat(this double p_value) {
			var value = Math.Round(p_value, 2);
			if (value < 0) return String.Format("<span class='red'>{0:c}</span>", Math.Round(p_value, 2));
			else return String.Format("{0:c}", Math.Round(p_value, 2));
		}

		public static string ToCurrencyFormat(this double? p_value) {
			if (p_value.HasValue) {
				var value = Math.Round(p_value.Value, 2);
				if (value < 0) return String.Format("<span class='red'>{0:c}</span>", Math.Round(p_value.Value, 2));
				else return String.Format("{0:c}", Math.Round(p_value.Value, 2));
			} else
				return String.Empty;
		}

		public static string ToCurrencyFormat(this double p_value, string p_ifZero) {
			if (p_value == 0d)
				return p_ifZero;

			return p_value.ToCurrencyFormat();
		}

		public static string ToCurrencyFormat(this double? p_value, string p_ifNullOrZero) {
			if ((p_value ?? 0d) == 0d)
				return p_ifNullOrZero;

			return p_value.Value.ToCurrencyFormat();
		}

	}
}
