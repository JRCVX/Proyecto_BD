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
        
        private void Form1_Load(object sender, EventArgs e)
        {
               
            List<ClEntidades> lista = objNexo.ListaR();

            foreach (ClEntidades datos in lista)
            {
                listBox1.Items.Add("ID: " + datos.Id_Es + " | Nombre: " + datos.Nombre_Es + " | Nivel: " + datos.nivel);
            }
        }

        private void ingrsarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresar frmIngresar = new FrmIngresar();
            frmIngresar.ShowDialog();
        }
    }
}
