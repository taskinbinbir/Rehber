using MongoDB.Driver;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using Rapor.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rapor.Core
{
    public class RaporServices : IRaporServices
    {
        private readonly IMongoCollection<RaporModel> _raporlar;

        public RaporServices(IDbClient dbClient)
        {
            _raporlar = dbClient.GetRaporCollection();
        }

        public async Task<List<RaporIcerikModel>> CreateDetayRapor()
        {
            Guid g = Guid.NewGuid();
            RestClient client = new RestClient("https://localhost:44389/Rehber/IletisimBilgileri");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            List<IletisimBilgisiModel> iletisimBilgileri = JsonConvert.DeserializeObject<List<IletisimBilgisiModel>>(response.Content);
            List<RaporIcerikModel> raporIcerikModelList = new List<RaporIcerikModel>();
            Queue<List<RaporIcerikModel>> raporIcerikModelListQueue = new Queue<List<RaporIcerikModel>>();

            RaporModel rapor = new RaporModel()
            {
                UUID = g,
                TalepTarihi = DateTime.Now,
                Durumu = "Hazırlanıyor"
            };

            await _raporlar.InsertOneAsync(rapor);



            foreach (IletisimBilgisiModel i in iletisimBilgileri)
            {
                bool ekle = false;

                if (raporIcerikModelList.Count == 0)
                {
                    ekle = true;
                }
                else
                {
                    if (raporIcerikModelList.Exists(x => x.Konum == i.Konum))
                    {
                        RaporIcerikModel icerikModel = raporIcerikModelList.Find(x => x.Konum.Equals(i.Konum));
                        icerikModel.RehbereKayitliKisiSayisi++;

                        if (!string.IsNullOrEmpty(i.TelefonNumarasi))
                        {
                            icerikModel.RehbereKayitliTelefonNumarasıSayisi++;
                        }
                    }
                    else
                    {
                        ekle = true;
                    }
                }

                if (ekle)
                {
                    RaporIcerikModel yeniRaporIcerikModel = new RaporIcerikModel()
                    {
                        Konum = i.Konum,
                        RehbereKayitliKisiSayisi = 1
                    };

                    if (!string.IsNullOrEmpty(i.TelefonNumarasi))
                    {
                        yeniRaporIcerikModel.RehbereKayitliTelefonNumarasıSayisi = 1;
                    }
                    else
                    {
                        yeniRaporIcerikModel.RehbereKayitliTelefonNumarasıSayisi = 0;
                    }

                    raporIcerikModelList.Add(yeniRaporIcerikModel);
                }

                ekle = false;
            }

            raporIcerikModelListQueue.Enqueue(raporIcerikModelList);

            rapor.Durumu = "Tamamlandı";
            await _raporlar.ReplaceOneAsync(r => r.UUID == rapor.UUID, rapor);

            return raporIcerikModelListQueue.Dequeue();
        }

        public async Task<List<IstatistikselRaporModel>> CreateIstatistikselRapor()
        {
            List<RaporIcerikModel> raporIcerik = await CreateDetayRapor();
            List<IstatistikselRaporModel> istatistikselRaporModelList = new List<IstatistikselRaporModel>();
            double toplamKisiSayisi = 0;
            Queue<List<IstatistikselRaporModel>> istatistikselRaporModelQueue = new Queue<List<IstatistikselRaporModel>>();


            foreach (RaporIcerikModel r in raporIcerik)
            {
                toplamKisiSayisi += r.RehbereKayitliKisiSayisi;
            }

            foreach (RaporIcerikModel r in raporIcerik)
            {
                istatistikselRaporModelList.Add(new IstatistikselRaporModel()
                {
                    Konum = r.Konum,
                    Yuzde = (r.RehbereKayitliKisiSayisi / toplamKisiSayisi) * 100
                });
            }

            istatistikselRaporModelQueue.Enqueue(istatistikselRaporModelList);

            return istatistikselRaporModelQueue.Dequeue();
        }

        public async Task<List<RaporModel>> GetRapors()
        {
            Queue<IAsyncCursor<RaporModel>> queue = new Queue<IAsyncCursor<RaporModel>>();

            var a = await _raporlar.FindAsync(rapor => true);
            queue.Enqueue(a);

            return queue.Dequeue().ToList();
        }

    }
}
