using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;


namespace CapaPresentacion.Soluciones
{
    public partial class solucionesXJuez : Form
    {
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public solucionesXJuez()
        {
            InitializeComponent();
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
                grid3.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    int topX = Int32.Parse(textBox1.Text);
                    dt = amd.cargarTopXJuecesConSoluciones(topX);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe colocar un número en el espacio de texto", "",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }
    }
}
