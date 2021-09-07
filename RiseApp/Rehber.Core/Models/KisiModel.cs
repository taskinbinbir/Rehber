using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Core.Models
{
    public class KisiModel
    {       
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public IletisimBilgisiModel IletisimBilgisi { get; set; }

        public KisiModel()
        {
            IletisimBilgisi = new IletisimBilgisiModel();
        }
    }
}
