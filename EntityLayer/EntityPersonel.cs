using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityPersonel
    {     // Burada Değişen tanımlaamsı yaptık Satırlar üzerinde ctrl-r-e yaptık alt tarafa yazdırdı 
        private int id;
        private string ad;
        private string soyad;
        private string sehir;
        private string gorev;
        private short maas;  // Sqldekı smallint karslıgı c# da short olarak geçiyor 

        public int Id { get => id; set => id = value; }  // Bu yapının hepsi kapsülleme diye geçiyor 
        public string Ad { get => ad; set => ad = value; }  // Her biri ise proporti diye geçiyor. 
        public string Soyad { get => soyad; set => soyad = value; }
        public string Sehir { get => sehir; set => sehir = value; }
        public string Gorev { get => gorev; set => gorev = value; }
        public short Maas { get => maas; set => maas = value; }
    }
}
