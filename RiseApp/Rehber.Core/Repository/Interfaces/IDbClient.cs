using MongoDB.Driver;
using Rehber.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Core
{
    public interface IDbClient
    {
        IMongoCollection<KisiModel> GetKisilerCollection();
    }
}
