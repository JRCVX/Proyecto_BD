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
using System.Security.Cryptography.X509Certificates;

namespace e_Presentacion
{
    public partial class Form1 : Form
    {
        ClNexo objNexo = new ClNexo();
        public Form1()
        {
            InitializeComponent();
        }
        private void CargarLista()
        {
            // 1. Limpiar el ListBox para evitar duplicados
            listBox1.Items.Clear();

            // 2. Obtener la lista actualizada desde la base de datos
            List<ClEntidades> lista = objNexo.ListaR();

            // 3. Volver a llenar el ListBox
            if (lista != null) // Buena práctica: verificar que la lista no sea nula
            {
                foreach (ClEntidades datos in lista)
                {
                    listBox1.Items.Add("ID: " + datos.Id_Es + " | Nombre: " + datos.Nombre_Es + " | Nivel: " + datos.nivel);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void ingrsarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresar frmIngresar = new FrmIngresar();
            frmIngresar.ShowDialog();
            CargarLista();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEliminar frmEliminar = new FrmEliminar();
            frmEliminar.ShowDialog();
            CargarLista();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscar frmBuscar= new FrmBuscar();
            frmBuscar.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditar frmEditar = new FrmEditar();
            frmEditar.ShowDialog();
            CargarLista();
        }
    }
}
