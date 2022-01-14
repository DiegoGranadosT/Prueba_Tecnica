using PruebaTecnica.Infraestructure.Persistence;
using PruebaTecnica.Core.Application.Contracts.Persistence.Base;
using PruebaTecnica.Core.Domain.Base;

namespace PruebaTecnica.Infraestructure.Persistence.Repositories
{ 
    public class Repository<T, TId> : RepositoryWithTypedId<T, TId>, IRepository<T, TId>
        where T : class, IEntityWithTypedId<TId>
    {
        public Repository(PruebaDbContext context) : base(context)
        {

        }
    }
}
