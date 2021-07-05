using MongoDB.Driver;

namespace Repositorio.Contexto
{
    public class ContextMongo
    {
        internal IMongoDatabase MongoDataBase { get; }
        internal const string DistribuidorCollectionName = "DISTRIBUIDOR";
        internal const string ItemCollectionName = "ITEM";
        internal const string ColetorCollectionName = "COLETOR";
        internal const string AlteracoesCollectionName = "ALTERACOES";
        internal const string AgendamentoCollectionName = "AGENDAMENTO";

        public ContextMongo(string connectionString, string dataBase)
        {
            var clientMongo = new MongoClient(connectionString);
            MongoDataBase = clientMongo.GetDatabase(dataBase);
        }
    }
}
