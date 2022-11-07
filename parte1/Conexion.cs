using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace AVL
{
    public class Conexion
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = Jamj.2003; Database = postgres");
        public void Conectar()
        {
            conn.Open();
            System.Windows.Forms.MessageBox.Show("Listo");
        }
    }
}
