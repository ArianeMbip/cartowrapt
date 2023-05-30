using Microsoft.EntityFrameworkCore;

namespace CartoMongo.Models
{
    public class CartoDbContext : DbContext
    {
        public CartoDbContext(DbContextOptions<CartoDbContext> options)
        : base(options) { }

        public DbSet<Actif> Actif { get; set; } = null!;
        public DbSet<ValeurAttribut> ValeurAttr { get; set; } = null!;
        public DbSet<Attribut> Attribut { get; set; } = null!;
        public DbSet<TypeElement> TypeActif { get; set; } = null!;
    }
}
