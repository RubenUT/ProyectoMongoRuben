namespace ProyectoMongoRuben.Models
{
    public interface ITerrariaStoreDatabaseSettings
    {
        string TerrariaJugadorCollectionName { get; set; }
        string CollectionString { get; set; }
        string DatabaseName { get; set; }
        string TerrariaJefesCollectionName { get; }
        string TerrariaRarezaCollectionName { get; set; }
        string TerrariaArmasCollectionName { get; set; }
        string TerrariaClasesCollectionName { get; set; }
    }
}
