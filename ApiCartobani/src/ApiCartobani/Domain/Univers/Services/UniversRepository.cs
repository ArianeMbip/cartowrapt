namespace ApiCartobani.Domain.Univers.Services;

using ApiCartobani.Domain.Univers;
using ApiCartobani.Databases;
using ApiCartobani.Services;

public interface IUniversRepository : IGenericRepository<Univers>
{
}

public sealed class UniversRepository : GenericRepository<Univers>, IUniversRepository
{
    private readonly CartobaniDbContext _dbContext;

    public UniversRepository(CartobaniDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
