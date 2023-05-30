namespace CartoMongo.Models
{
    public class CartoDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ActifCollectionName { get; set; } = null!;

        public string TypeElementCollectionName { get; set; } = null!;

        public string FluxCollectionName { get; set; } = null!;

        public string DACollectionName { get; set; } = null!;

        public string RoleCollectionName { get; set; } = null!;

        public string EnvironnementCollectionName { get; set; } = null!;

        public string IconeCollectionName { get; set; } = null!;

    }
}
