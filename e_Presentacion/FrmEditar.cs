using e_Entidad;
using e_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Presentacion
{
    public partial class FrmEditar : Form
    {
        ClNexo objNexo = new ClNexo();
        ClEntidades objEntidad = new ClEntidades();
        public FrmEditar()
        {
            InitializeComponent();
            // Deshabilitar campos al iniciar
            TxtNom.Enabled = false;
            TxtNivel.Enabled = false;
            BtnGuardar.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtID.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int codigo = int.Parse(TxtID.Text);
                ClEntidades estudiante = objNexo.DarValores(codigo);

                if (estudiante != null)
                {
                    // Estudiante encontrado, llenar campos y habilitarlos
                    TxtNom.Text = estudiante.Nombre_Es;
                    TxtNivel.Text = estudiante.nivel.ToString();

                    // Guardamos el ID en nuestro objeto
                    objEntidad.Id_Es = estudiante.Id_Es;

                    TxtNom.Enabled = true;
                    TxtNivel.Enabled = true;
                    BtnGuardar.Enabled = true;
                    TxtID.Enabled = false; // Bloquear el ID después de buscar
                    BtnBuscar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Estudiante no encontrado.", "Búsqueda Fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Asignar los NUEVOS valores al objeto entidad
                // El ID ya lo teníamos guardado desde la búsqueda
                objEntidad.Nombre_Es = TxtNom.Text;
                objEntidad.nivel = int.Parse(TxtNivel.Text);

                // Llamar al método de actualizar
                objNexo.Actualizar(objEntidad);

                MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar y resetear el formulario
                LimpiarCampos();
                TxtID.Enabled = true;
                BtnBuscar.Enabled = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("El Nivel debe ser un número.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            TxtID.Clear();
            TxtNom.Clear();
            TxtNivel.Clear();
            TxtNom.Enabled = false;
            TxtNivel.Enabled = false;
            BtnGuardar.Enabled = false;
        }
    }
}
