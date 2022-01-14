namespace PruebaTecnica.Core.Domain.Base
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
