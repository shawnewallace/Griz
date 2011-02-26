using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Heuristics.Library.Extensions;


namespace Heuristics.LearningBuilder.Extensions {

	public static class DeletedEntityExtensions {

		/// <summary>
		/// Removes all objects in a sequence that have a boolean property called "IsDeleted"
		/// with a value of true. This should NOT be executed against domain models as it could
		/// cause NHibernate to issue delete statements. Rather, this is designed to filter deleted
		/// entities out of view models in scenarios in which we do not want to show items marked
		/// for deletion.
		/// </summary>
		public static void RemoveDeleted<T>(this IList<T> p_sequence) {
			var deletedItems = p_sequence
				.Where(x => x.GetPropertyOrDefault<bool>("IsDeleted", false) == true)
				.ToList();

			foreach (var deletedItem in deletedItems) {
				p_sequence.Remove(deletedItem);
			}
		}
	}
}
