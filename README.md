Nasıl çalışıyor ?


WebApi projeleri çalıştırılır ve swagger'ı üzerinden api'lere istekler gönderilirek çalışır. 

Rehber microservisimiz:

rehbere kişi ekleme servisimiz:

​api url'miz: /Rehber​/KisiEkle

örnek json'ınmız:

{
  "ad": "Taşkın",
  "soyad": "Binbir",
  "firma": "Binbir Company"  
}


kişi silme:

​/Rehber​/KisiSil​/{UUID}

UUID alanına kişinin GUID'si yazılır ve execute edilerek kişi silinir.


kişinin billerini getirme:

​/Rehber​/KisiGetir​/{UUID}

UUID alanına kişinin GUID'si yazılır ve execute edilerek kişi bilgileri gelir.


kişiye iletişim bilgisi ekleme:

​/Rehber​/IletisimBilgisiEkle

örnek json:

{
  "uuid": "9d70c3ac-9c89-4623-8133-e346c8e07af3",
  "iletisimBilgisi": {
    "telefonNumarasi": "155",
    "eMailAdresi": "taskin@gmail.com",
    "konum": "Samsun"
  }
}

kişiye iletişim bilgisi silme:

UUID alanına kişinin GUID'si yazılır ve kişinin iletişim bilgileri silinir.


rehberdeki kişileri getirme:

​/Rehber​/KisiListesi

Get metodu çalışılarak rehberdeki kişiler getirilir.


Rapor microservisimiz:

Raporların durumları görmek için: 

​/Rapor​/GetRaporlar api'si çalıştırılır ve hazırlanıyor mu yoksa tamamlandı mı bilgisine bize verir.

Rapor detay için:

​/Rapor​/DetayRaporTalebi api'si çalıştırılır ve konum ve kişi sayıları ve kayıtlı telefon numarası sayıları bize döner.

İstatiksel rapor talebi için:

​/Rapor​/DetayRaporTalebi api'si çalıştırılır ve konumda bulunan kişi sayısına göre yüzdesini bize verir.