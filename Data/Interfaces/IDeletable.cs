namespace Griz.Data.Interfaces
{
	public interface IDeletable
	{
		bool IsDeleted { get; }
		void MarkForDeletion();
		void Undelete();
	}
}