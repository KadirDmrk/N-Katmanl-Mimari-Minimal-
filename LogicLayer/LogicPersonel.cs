using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAcsessLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int LLPersonekEkle(EntityPersonel p)  // Personel Ekle adında bir nesne oluşturp p ye atadık.       
        {
            if(p.Ad!="" && p.Soyad!=""&& p.Maas>=3500 && p.Ad.Length>=3) 
            {
                return DALPersonel.PersonelEkle(p);     
                
            }
            else // aksi durumda 
            {
                return -1; // Eğer yukarıdakı şartlar sağlanmazsa hiçbir şey yapma.
            }
        }
        /* Logic layer şartların sağlandıgı katman olduğu için Üsttekı tarafta şar yazdık adı null döndürme soyadı null 
          dondurme maasş 3500 den buyuk olsun harf uzunlugu 3 den buyuk olsun bunalr gibi ornek şeyler yazdık */
         public static bool LLPersonelSil(int per)  // bool yaspısı true ya da false olarak değiştiği için boyle yazdık.
        {
            if (per >= 1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }
        }

         public static bool LLPersonelGuncelle(EntityPersonel ent)
        {
            if(ent.Ad.Length>3 && ent.Ad!="" && ent.Maas>=4500)
            {
                return DALPersonel.PersonelGuncelle(ent);
            }
            else
            {
                return false;
            }
        }
  
    }
}
