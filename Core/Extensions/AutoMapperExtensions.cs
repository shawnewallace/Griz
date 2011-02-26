using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Heuristics.Library.DesignByContract;

namespace Heuristics.LearningBuilder.Extensions {
    
	public static class AutoMapperExtensions {
		
		/// <summary>
		/// Syntactic sugar for using AutoMapper to map a sequence of TSrc to a List[TDest].
		/// </summary>
		public static List<TDest> MapToList<TSrc, TDest>(this IEnumerable<TSrc> p_source) {
			Require.That(p_source != null, "Cannot map from a null object instance.");

			return Mapper.Map<IEnumerable<TSrc>, List<TDest>>(p_source);
		}

		/// <summary>
		/// Syntactic sugar for using AutoMapper to map a source object to a newly created destination object.
		/// </summary>
		public static TDest MapTo<TDest>(this object p_source) {
			Require.That(p_source != null, "Cannot map from a null object instance.");
			
			return (TDest)Mapper.Map(p_source, p_source.GetType(), typeof(TDest));
		}

		/// <summary>
		/// Syntactic sugar for using AutoMapper to map the specified source object into the current
		/// object instance. A mapping between the two types must already be configured; a runtime
		/// error will occur otherwise.
		/// </summary>
		public static void MapFrom(this object p_destination, object p_source) {
			Require.That(p_destination != null, "Cannot map to a null object instance.");
			
			Mapper.Map(p_source, p_destination, p_source.GetType(), p_destination.GetType());
		}
	}
}
