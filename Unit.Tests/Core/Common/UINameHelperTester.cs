using System;
using System.Linq.Expressions;
using Griz.Core.Common;
using Griz.Core.Bases;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace Griz.Unit.Tests.Core.Common
{
	[TestFixture]
	public class UINameHelperTester
	{
		[Test]
		public void Should_build_name_from_basic_expression()
		{
			Expression<Func<Stub, object>> expression = f => f.Name;
			UiNameHelper.BuildNameFrom(expression).ShouldEqual("Name");
		}

		[Test]
		public void Should_build_name_from_indexed_expression()
		{
			Expression<Func<Stub, object>> expression = f => f.Subs[5].Number;
			UiNameHelper.BuildNameFrom(expression).ShouldEqual("Subs[5].Number");
		}

		[Test]
		public void Should_build_name_for_enumerated_input()
		{
			Expression<Func<Stub, object>> expression = f => f.EnumProp;
			UiNameHelper.BuildIdFrom(expression, TestEnum.Test).ShouldEqual("EnumProp_1");
		}

		[Test]
		public void Should_extract_index_values_from_expressions()
		{
			Expression<Func<Stub, object>> expression1 = f => f.Name;
			Expression<Func<Stub, object>> expression2 = f => f.Subs[5].Number;

			UiNameHelper.ExtractIndexValueFrom(expression1).ShouldBeNull();
			UiNameHelper.ExtractIndexValueFrom(expression2).ShouldEqual(5);
		}

		public class Stub
		{
			public string Name { get; set; }
			public SubStub[] Subs { get; set; }
			public TestEnum EnumProp { get; set; }
		}

		public class SubStub
		{
			public int Number { get; set; }
		}

		public class TestEnum : Enumeration
		{
			public static TestEnum Test = new TestEnum(1, "Test");

			public TestEnum(int value, string displayName) : base(value, displayName)
			{
			}
		}
	}
}