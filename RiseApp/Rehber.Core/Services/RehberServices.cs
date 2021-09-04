using MongoDB.Driver;
using Rehber.Core.Models;
using System;
using System.Collections.Generic;

namespace Rehber.Core
{
    public class RehberServices : IRehberServices
    {
        private readonly IMongoCollection<KisiModel> _kisiler;

        public RehberServices(IDbClient dbClient)
        {
            _kisiler = dbClient.GetKisilerCollection();
        }

        public KisiModel AddIletisimBilgisi(KisiModel kisi)
        {
            KisiModel k = GetKisi(kisi.UUID);
            k.IletisimBilgisi = kisi.IletisimBilgisi;
            _kisiler.ReplaceOne(kisi => kisi.UUID == k.UUID, k);
            return k;
        }

        public void DeleteIletisimBilgisi(Guid UUID)
        {
            KisiModel k = GetKisi(UUID);
            k.IletisimBilgisi = null;
            _kisiler.ReplaceOne(kisi => kisi.UUID == k.UUID, k);
        }

        public KisiModel AddKisi(KisiModel kisi)
        {
            Guid g = Guid.NewGuid();
            kisi.UUID = g;
            _kisiler.InsertOne(kisi);
            return kisi;
        }

        public void DeleteKisi(Guid UUID)
        {
            _kisiler.DeleteOne(kisi => kisi.UUID == UUID);
        }

        public KisiModel GetKisi(Guid UUID) => _kisiler.Find(kisi => kisi.UUID == UUID).First();
       

        public List<KisiModel> KisiListesi() => _kisiler.Find(kisi => true).ToList();


        public List<IletisimBilgisiModel> KisilerinIletisimBilgileri()
        {
            List<KisiModel> kisiler = KisiListesi();
            List<IletisimBilgisiModel> iletisimBilgisileri = new List<IletisimBilgisiModel>();

            foreach(KisiModel k in kisiler)
            {
                if(k.IletisimBilgisi != null)
                {
                    iletisimBilgisileri.Add(k.IletisimBilgisi);
                }
            }

            return iletisimBilgisileri;
        }
                
    }
}
