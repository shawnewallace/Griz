namespace Griz.Data.Interfaces
{
	public interface IEntity<TKey> : IDeletable
	{
		TKey Id { get; set; }
		bool IsTransient { get; }
	}
}
