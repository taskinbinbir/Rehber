using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rapor.Core.Helper;

namespace Rapor.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<RaporModel> _raporlar;

        public DbClient(IOptions<RaporDbConfig> raporDbConfig)
        {
            var client = new MongoClient(raporDbConfig.Value.Connection_String);
            var database = client.GetDatabase(raporDbConfig.Value.Database_Name);
            _raporlar = database.GetCollection<RaporModel>(raporDbConfig.Value.Rapor_Collection_Name); 
        }

        public IMongoCollection<RaporModel> GetRaporCollection() => _raporlar;
        
    }
}
