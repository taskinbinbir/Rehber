using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapor.Core
{
    public interface IDbClient
    {
        IMongoCollection<RaporModel> GetRaporCollection();
    }
}
