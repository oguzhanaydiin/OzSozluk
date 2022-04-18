namespace OzSozluk.Api.Domain.Models;

public abstract class BaseEntity
{
    public Guid Guid { get; set; }
    public DateTime CreateDate { get; set; }
}
