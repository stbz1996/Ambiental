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
    public partial class reporteGeneralAportes : Form
    {
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public reporteGeneralAportes()
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
                grid3.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
                DateTime fechaFinal = Convert.ToDateTime(fecha2.Value.Date.ToString("dd/MM/yyyy"));

                if (fechaInicio > fechaFinal) {
                    dt = amd.cargarAportesPorFecha(fechaFinal, fechaInicio);
                    cargar();
                }
                else
                {
                    dt = amd.cargarAportesPorFecha(fechaInicio, fechaFinal);
                    cargar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Disculpe, ha ocurrido un error, intente mas tarde", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }

        
    }
}
