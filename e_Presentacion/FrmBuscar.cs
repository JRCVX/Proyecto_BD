using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Entidad;
using e_Logica;

namespace e_Presentacion
{
    public partial class FrmBuscar : Form
    {
        
        ClNexo objNexo = new ClNexo();
        public FrmBuscar()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                int codigo = Convert.ToInt16(TxtID.Text);
                objNexo.DarValores(codigo);
                ClEntidades estudiantes = objNexo.DarValores(codigo);
                if (estudiantes != null)
                {
                    LblNom.Text = estudiantes.Nombre_Es;
                    LblNivel.Text = estudiantes.nivel.ToString();
                }
                else
                    MessageBox.Show("El estudiante solicitado no existe");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el estudiante: " + ex.Message);


            }
        }


    }
}

