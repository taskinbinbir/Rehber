using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapor.Core
{
    public class RaporModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid UUID { get; set; }
        public DateTime TalepTarihi { get; set; }
        public string Durumu { get; set; }
    }
}
