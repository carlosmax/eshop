namespace Catalog.Core.Common
{
    public interface IAggregateRoot
    {
        string Id { get; }
    }

    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
    }
}
