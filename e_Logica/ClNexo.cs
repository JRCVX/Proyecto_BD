using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_Datos;
using e_Entidad;

namespace e_Logica
{
    public class ClNexo
    {
        ClOperaciones objOpera = new ClOperaciones();
        public List<ClEntidades> ListaR()
        {
            return objOpera.ListaD();
        }

        public void Ingresar(ClEntidades Datos)
        {
            objOpera.Insertar(Datos);
        }

        public void Borrar(int dato)
        {
            objOpera.Eliminar(dato);
        }
    }
}
