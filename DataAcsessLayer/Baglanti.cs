using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAcsessLayer
{
    public class Baglanti
    {

        public static SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-P0AC89F\\SQLEXPRESS;Initial Catalog=DbPersonel;Integrated Security=True");
    }
}

