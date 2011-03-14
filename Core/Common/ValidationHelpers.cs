using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Heuristics.Utility;


namespace Heuristics.LearningBuilder.Extensions {
	public static class ValidationHelpers {

		/// <summary>
		/// ensures that phone number has at least 10 digits
		/// </summary>
		public static bool ValidatePhone(string p_phoneNumber, MessageCollection p_errors, string p_message, bool p_isRequired = false) {
			if (string.IsNullOrEmpty(p_phoneNumber)) {
				if (p_isRequired) {
					p_errors.Add(p_message);
					return false;
				}
				return true;
			}
			if (Helpers.ValidateLength(p_phoneNumber, p_errors, p_message, 10, 50, p_isRequired)) {
				var phoneNumber = Regex.Replace(p_phoneNumber, "[^0-9]", "");
				return Helpers.ValidateLength(phoneNumber, p_errors, p_message, 10, 50, p_isRequired);
			}
			return false;
		}

	}
}
