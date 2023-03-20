namespace ProyectoMongoRuben.Models
{
    public class TerrariaStoreDatabaseSettings : ITerrariaStoreDatabaseSettings
    {
        public string TerrariaJugadorCollectionName { get; set; } = String.Empty;
        public string TerrariaJefesCollectionName { get; set; } = String.Empty;
        public string TerrariaRarezaCollectionName { get; set; } = String.Empty;
        public string TerrariaArmasCollectionName { get; set; } = String.Empty;
        public string TerrariaClasesCollectionName { get; set; } = String.Empty;
        public string CollectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
