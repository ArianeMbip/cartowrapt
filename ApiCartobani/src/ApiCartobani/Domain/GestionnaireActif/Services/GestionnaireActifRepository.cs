namespace ApiCartobani.Domain.GestionnaireActif.Services;

using ApiCartobani.Domain.GestionnaireActif;
using ApiCartobani.Databases;
using ApiCartobani.Services;

public interface IGestionnaireActifRepository : IGenericRepository<GestionnaireActif>
{
}

public sealed class GestionnaireActifRepository : GenericRepository<GestionnaireActif>, IGestionnaireActifRepository
{
    private readonly CartobaniDbContext _dbContext;

    public GestionnaireActifRepository(CartobaniDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
