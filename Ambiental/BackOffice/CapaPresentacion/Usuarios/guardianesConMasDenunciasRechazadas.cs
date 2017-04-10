using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class guardianesConMasDenunciasRechazadas : Form
    {
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public guardianesConMasDenunciasRechazadas()
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cant = Int32.Parse(cantidad.Text);
                dt = amd.cargarDenunciasRechazadasGuardian(cant);
                cargar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Debe colocar un número en el espacio de texto", "",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cant = Int32.Parse(cantidad.Text);
                DateTime fechaEnvio = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
                dt = amd.cargarDenunciasRechazadasGuardianXfecha(cant, fechaEnvio);
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe colocar un número en el espacio de texto", "",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
