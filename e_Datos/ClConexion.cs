using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace e_Datos
{
    public class ClConexion
    {
        public string cadenaConexionMySQL = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BD_Estudiantes; Integrated Security = True";
        public SqlConnection conectar = new SqlConnection();

        public ClConexion()
        {
            conectar.ConnectionString = cadenaConexionMySQL;
        }
        public void Abrir()
        {
            try
            {
                conectar.Open();
                Console.WriteLine("Conexion Realizada");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de Conexion: " + ex.Message);
            }
        }

        public void Cerrar()
        {
            conectar.Close();

        }
    }
}
