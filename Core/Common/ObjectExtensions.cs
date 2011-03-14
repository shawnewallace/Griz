using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Griz.Core.Common
{
	public static class ObjectExtensions
	{
		public static object GetPropertyValue(this object obj, string property)
		{
			return TypeDescriptor.GetProperties(obj)[property].GetValue(obj);
		}

		public static IDictionary<string, object> ToDictionary(this object obj)
		{
			IDictionary<string, object> result = new Dictionary<string, object>();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
			foreach (PropertyDescriptor property in properties)
			{
				result.Add(property.Name, property.GetValue(obj));
			}
			return result;
		}

		/// <summary>
		/// Returns TRUE if the object instance is null. This is just a syntactic sugar for "== null".
		/// </summary>
		public static bool IsNull(this object instance)
		{
			return (instance == null);
		}

		/// <summary>
		/// Returns TRUE if the object instance is null. If the instance is not null, and the
		/// obhect is an enumerable sequence, this returns TRUE if the sequence has no items.
		/// In all other cases, this returns TRUE if the string representation is an empty string,
		/// and FALSE otherwise.
		/// </summary>
		public static bool IsNullOrEmpty(this object instance)
		{
			if (instance == null)
				return true;

			if (instance is IEnumerable)
				return ((IEnumerable)instance).IsNullOrEmpty();

			// not a sequence, so check for an empty string representation
			return (instance.ToString() == String.Empty);
		}

		/// <summary>
		/// Returns TRUE if the object instance is not null. This is just a syntactic sugar for "!= null".
		/// </summary>
		public static bool IsNotNull(this object instance)
		{
			return (instance != null);
		}

		/// <summary>
		/// Returns TRUE if the object instance is not null and is either an enumerable sequence
		/// with one or more items OR the string representation is not an empty string.
		/// </summary>
		public static bool IsNotNullOrEmpty(this object instance)
		{
			return !instance.IsNullOrEmpty();
		}

		/// <summary>
		/// Returns the string representation of the given object instance, or String.Empty
		/// if the instance is null.
		/// </summary>
		public static string ToStringNullSafe(this object instance)
		{
			return instance.ToStringNullSafe(String.Empty);
		}

		/// <summary>
		/// Returns the string representation of the given object instance, or the specified value
		/// if the instance is null.
		/// </summary>
		public static string ToStringNullSafe(this object instance, string valueIfNull)
		{
			return (instance == null)
					? valueIfNull
					: instance.ToString();
		}
	}
}