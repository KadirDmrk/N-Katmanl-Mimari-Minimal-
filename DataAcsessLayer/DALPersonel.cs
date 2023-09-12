using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAcsessLayer
{
    public  class DALPersonel
    {

        public static List<EntityPersonel> PersonelListesi() // EntityPersonel Personel listesi diye bir isim koyarak metod oluşturdum.
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>(); // değerler adında bir nesne türettim 
            SqlCommand komut1 = new SqlCommand("Select * From TBLBILGI", Baglanti.bgl); // Sql komutumuz 
            if (komut1.Connection.State != ConnectionState.Open) // Eğer Benım bağlantım acık değilse 
            {
                komut1.Connection.Open(); // Bağlantıyı Açın 
            }
            SqlDataReader dr=komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent= new EntityPersonel(); // ent yardımıyla nesne türettim ki ent yardımıyla proportilere yanı ıd,ad,gorev bunlara erişebileyim 
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Sehir = dr["SEHIR"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler; // geriye dondur 
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2=new SqlCommand("insert into TBLBILGI (AD,SOYAD,GOREV,SEHIR,MAAS) VALUES (@P1,@P2,@P3,@P4,@P5)",Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open) // Eğer Benım bağlantım acık değilse 
            {
                komut2.Connection.Open(); // Bağlantıyı Açın 
            }
            komut2.Parameters.AddWithValue("@P1", p.Ad);
            komut2.Parameters.AddWithValue("@P2", p.Soyad);
            komut2.Parameters.AddWithValue("@P3", p.Gorev);
            komut2.Parameters.AddWithValue("@P4", p.Sehir);
            komut2.Parameters.AddWithValue("@P5", p.Maas);
            return komut2.ExecuteNonQuery();
        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("DELETE from TBLBILGI where ID=@P1",Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open) // Eğer Benım bağlantım acık değilse 
            {
                komut3.Connection.Open(); // Bağlantıyı Açın 
            }
            komut3.Parameters.AddWithValue("@P1", p);
            return komut3.ExecuteNonQuery() > 0; 
            /* Şimdi ben return komut3.ExecuteNonQuery yazdıgım zaman bana hata dondurdu nıiye dondurdu ben en basta
            sınıfı bool yapısıyla oluşturdugum için bana boyle kullnamazsın dedi .Bool yapısı ture yada false adlıgı ıcın ben >0 diye kullanırsam
            program bu nsefr hata vermez .*/
        }                                     

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut4 = new SqlCommand("UPDATE TBLBILGI SET AD=@P1,SOYAD=@P2,MAAS=@P3,GOREV=@P4,SEHIR=@P5 WHERE ID=@P6", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open) // Eğer Benım bağlantım acık değilse 
            {
                komut4.Connection.Open(); // Bağlantıyı Açın 
            }
            komut4.Parameters.AddWithValue("@P1", ent.Ad);
            komut4.Parameters.AddWithValue("@P2", ent.Soyad);
            komut4.Parameters.AddWithValue("@P3", ent.Maas);
            komut4.Parameters.AddWithValue("@P4", ent.Gorev);
            komut4.Parameters.AddWithValue("@P5", ent.Sehir);
            komut4.Parameters.AddWithValue("@P6", ent.Id);
            return komut4.ExecuteNonQuery() > 0;

        }
    }
}
