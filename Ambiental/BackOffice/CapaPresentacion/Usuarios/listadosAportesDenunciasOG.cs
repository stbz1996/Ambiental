using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;

namespace CapaPresentacion.Usuarios
{
    public partial class listadosAportesDenunciasOG : Form
    {
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public listadosAportesDenunciasOG()
        {
            InitializeComponent();
            dt = amd.cargarAportesDenunciasGO();
            cargar();
        }

        public void cargar()
        {
            grid3.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grid3.Rows.Add(dt.Rows[i][0]);
                grid3.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                grid3.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                grid3.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    dt = amd.cargarAportesDenunciasGOFiltroNombre(textBox1.Text);
                    cargar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Disculpenos, no logramos cargar los datos, intente mas tarde", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }

        private void grid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
