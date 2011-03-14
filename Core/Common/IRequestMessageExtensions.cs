using System;
using SafeAuto.Framework.Domain.Common;
using SafeAuto.Framework.Services;

namespace SafeAuto.Framework.Extensions
{
	public static class IRequestMessageExtensions
	{
		public static ApplicationContext ToApplicationContext(this IRequestMessage source)
		{
			if (string.IsNullOrEmpty(source.ApplicationName))
			{
				throw new ArgumentException("Must provide a valid application name.");
			}

			return new ApplicationContext
			{
				ApplicationName = source.ApplicationName,
				UserInformation = new UserInfo { UserId = (short)source.UserId }
			};
		}
	}
}
