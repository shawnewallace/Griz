using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Griz.Core.Common
{
	public static class ReflectionHelper
	{

		/// <summary>
		/// Strongly-typed mechanism for obtaining the name of a class property as a string.
		/// </summary>
		/// <example>
		/// </example>
		public static String GetPropertyName<TClass, TProp>(
				Expression<Func<TClass, TProp>> propertySelector)
		{

			var memberExpression = propertySelector.Body as MemberExpression;

			return (memberExpression != null)
					? memberExpression.Member.Name
					: String.Empty;
		}

		public static PropertyInfo FindProperty(LambdaExpression lambdaExpression)
		{
			Expression expressionToCheck = lambdaExpression;

			bool done = false;

			while (!done)
			{
				switch (expressionToCheck.NodeType)
				{
					case ExpressionType.Convert:
						expressionToCheck = ((UnaryExpression)expressionToCheck).Operand;
						break;
					case ExpressionType.Lambda:
						expressionToCheck = lambdaExpression.Body;
						break;
					case ExpressionType.MemberAccess:
						var propertyInfo = ((MemberExpression)expressionToCheck).Member as PropertyInfo;
						return propertyInfo;
					default:
						done = true;
						break;
				}
			}

			return null;
		}

		/// <summary>
		/// Allows string-based access to an object's properties.
		/// </summary>
		//public static object GetPropertyValue(this object instance, string propertyName)
		//{
		//  var propertyValue = instance
		//      .GetType()
		//      .GetProperty(propertyName)
		//      .GetValue(instance, null);

		//  return propertyValue;
		//}

		/// <summary>
		/// Allows string-based access to an object's properties.
		/// </summary>
		public static T GetPropertyValue<T>(this object instance, string propertyName)
		{
			var propertyValue = (T)instance.GetPropertyValue(propertyName);
			return propertyValue;
		}

		/// <summary>
		/// Allows string-based access to an object's properties.
		/// </summary>
		public static void SetProperty(this object instance, string propertyName, object propertyValue)
		{
			var t = instance.GetType();
			if (t.IsNullOrEmpty())
			{
				throw new ApplicationException("Cannot find type.");
			}

			var p = t.GetProperty(propertyName);
			if (p.IsNullOrEmpty())
			{
				throw new ApplicationException("Cannot get type for property: " + propertyName);
			}

			if (propertyValue.IsNotNullOrEmpty())
			{
				var val = Convert.ChangeType(propertyValue, p.PropertyType);
				p.SetValue(instance, val, null);
			}

		}

		/// <summary>
		/// Returns a collection of static fields (e.g. constants) starting with a specified prefix.
		/// </summary>
		public static IEnumerable<FieldInfo> GetConstantsStartingWith(this Type type, string nameStartsWith)
		{
			var fields = type
					.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)
					.Where(f => f.Name.StartsWith(nameStartsWith));

			foreach (var field in fields)
				yield return field;
		}

		public static string Dump(this object instance, int maxDepth)
		{
			var writer = new StringWriter();
			ObjectDumper.Write(instance, maxDepth, writer);
			return writer.ToString();
		}
	}

	//Copyright (C) Microsoft Corporation.  All rights reserved.
	// From Linq Samples
}
