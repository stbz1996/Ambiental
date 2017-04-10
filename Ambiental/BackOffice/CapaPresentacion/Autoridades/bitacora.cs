using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;

namespace CapaPresentacion.Autoridades
{
    public partial class bitacora : Form
    {
        DataTable dt;
        MetodosConsultante amd = new MetodosConsultante();

        public bitacora()
        {
            InitializeComponent();
            dt = amd.cargarBitacora();
            cargar();
        }


        public void cargar()
        {
            try
            {
                grid3.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grid3.Rows.Add(dt.Rows[i][0]);
                    grid3.Rows[i].Cells[0].Value = dt.Rows[i][3].ToString();
                    grid3.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    grid3.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show("No se han podido cargar los datos, intente mas tarde", "",
                 MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }


        public void cargarXfecha()
        {
            // ocupo las fechas
            DateTime fechaInicio = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
            DateTime fechaFinal = Convert.ToDateTime(fecha2.Value.Date.ToString("dd/MM/yyyy"));

            if (fechaInicio > fechaFinal)
            {
                dt = amd.cargarBitacoraXfecha(fechaFinal, fechaInicio);
                cargar();
            }
            else
            {
                dt = amd.cargarBitacoraXfecha(fechaInicio, fechaFinal);
                cargar();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarXfecha();
        }

        private void bitacora_Load(object sender, EventArgs e)
        {

        }
    }


}
