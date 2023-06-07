namespace ApiCartobani.Domain.Flux.Services;

using ApiCartobani.Domain.Flux;
using ApiCartobani.Databases;
using ApiCartobani.Services;

public interface IFluxRepository : IGenericRepository<Flux>
{
}

public sealed class FluxRepository : GenericRepository<Flux>, IFluxRepository
{
    private readonly CartobaniDbContext _dbContext;

    public FluxRepository(CartobaniDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
