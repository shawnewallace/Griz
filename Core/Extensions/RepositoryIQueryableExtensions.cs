using System.Data.Objects;
using System.Linq;

namespace Griz.Core.Extensions
{
	public static class RepositoryIQueryableExtensions
	{
		public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
		{
			var objectQuery = source as ObjectQuery<T>;

			return objectQuery != null ? objectQuery.Include(path) : source;
		}
	}
}