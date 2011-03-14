namespace Griz.Core.Domain.Bases
{
    public interface IAuditable
    {
        ChangeAuditInfo ChangeAuditInfo { get; set; }
    }
}