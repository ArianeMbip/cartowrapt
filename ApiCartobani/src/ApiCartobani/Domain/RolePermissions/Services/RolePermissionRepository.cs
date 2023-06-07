namespace ApiCartobani.Domain.RolePermissions.Services;

using ApiCartobani.Domain.RolePermissions;
using ApiCartobani.Databases;
using ApiCartobani.Services;

public interface IRolePermissionRepository : IGenericRepository<RolePermission>
{
}

public sealed class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
{
    private readonly CartobaniDbContext _dbContext;

    public RolePermissionRepository(CartobaniDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
