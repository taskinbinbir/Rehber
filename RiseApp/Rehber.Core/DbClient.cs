using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rehber.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<KisiModel> _kisiler;
        public DbClient(IOptions<RehberDbConfig> rehberDbConfig)
        {
            var client = new MongoClient(rehberDbConfig.Value.Connection_String);
            var database = client.GetDatabase(rehberDbConfig.Value.Database_Name);
            _kisiler = database.GetCollection<KisiModel>(rehberDbConfig.Value.Rehber_Collection_Name);
        }

        public IMongoCollection<KisiModel> GetKisilerCollection() => _kisiler;
       
    }
}
