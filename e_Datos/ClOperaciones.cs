using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using e_Entidad;

namespace e_Datos
{
    public class ClOperaciones
    {
        ClConexion objConec = new ClConexion();

        public List<ClEntidades> ListaD()
        {
            List<ClEntidades> datos = new List<ClEntidades> ();
            try {
                
                objConec.Abrir();
                SqlCommand sqlC = new SqlCommand("SELECT * FROM TblDatos", objConec.conectar);
                SqlDataReader sqlLeer = sqlC.ExecuteReader();
                while (sqlLeer.Read())
                {
                    ClEntidades objEnti = new ClEntidades
                    {
                        Id_Es = Convert.ToInt32(sqlLeer["Id_Estudiante"]),
                        Nombre_Es = sqlLeer["Nombre"].ToString(),
                        nivel = Convert.ToInt32(sqlLeer["Nivel"])
                    };
                    datos.Add(objEnti);

                }
                
            } catch (Exception ex)
            {
                Console.WriteLine("Error al listar los datos: " + ex.Message);

               datos = null;

            }
            objConec.Cerrar();
            return datos;
        }

        public void Insertar (ClEntidades Datos)
        {
            objConec.Abrir();
            string sql = "INSERT INTO TblDatos (Nombre, Nivel) VALUES ('"+Datos.Nombre_Es+"','"+Datos.nivel+"')";
            SqlCommand sqlC = new SqlCommand(sql, objConec.conectar);
            sqlC.ExecuteNonQuery();
            objConec.Cerrar();
        }

        public void Eliminar (int dato)
        {
            objConec.Abrir();
            string sql = "DELETE FROM TblDatos WHERE Id_Estudiante = '"+dato+"'";
            SqlCommand sqlC = new SqlCommand (sql, objConec.conectar);
            sqlC.ExecuteNonQuery();
            objConec.Cerrar();
        }

        public ClEntidades DarValores(int Dato)
        {
            objConec.Abrir();  
            string sql = "SELECT * FROM TblDatos WHERE Id_Estudiante = '"+Dato+"'";
            SqlCommand sqlC = new SqlCommand(sql, objConec.conectar);
            sqlC.ExecuteNonQuery();
            objConec.Cerrar();
        }
    }
}
