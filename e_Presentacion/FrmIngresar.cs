using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Logica;
using e_Entidad;

namespace e_Presentacion
{
    public partial class FrmIngresar : Form
    {
        ClEntidades objEntidad = new ClEntidades();
        ClNexo objNexo = new ClNexo();
        public FrmIngresar()
        {
            InitializeComponent();
        }

        string nom;
        int nivel;

        private void TxtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es una letra, espacio o tecla de retroceso
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea la tecla
            }
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    nom = TxtNom.Text;
                    TxtNivel.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Ingrese Numeros", "Intentelo de Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNom.Clear();
            }
        }

        private void TxtNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir dígitos y retroceso
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            // Bloquear cualquier otra tecla
            e.Handled = true;

            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    nivel = int.Parse(TxtNivel.Text);

                    objEntidad.Nombre_Es = nom;
                    objEntidad.nivel = nivel;
                    objNexo.Ingresar(objEntidad);

                }
            }
            catch
            {
                MessageBox.Show("Ingrese Numeros", "Intentelo de Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNom.Clear();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            nom = TxtNom.Text;
            nivel = int.Parse(TxtNivel.Text);
            objEntidad.Nombre_Es = nom;
            objEntidad.nivel = nivel;
            objNexo.Ingresar(objEntidad);
        }
    }
}
