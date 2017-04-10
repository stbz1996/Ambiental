using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;

namespace CapaPresentacion.Aportes
{
    public partial class promedioAportes : Form
    {
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public promedioAportes()
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

                if (Int32.Parse(dt.Rows[i][1].ToString()) > 0)
                {
                    grid3.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                }
                else
                {
                    grid3.Rows[i].Cells[1].Value = "0";
                }
                
            }
        }

        public void filtraXfechas()
        {
            DateTime fechaInicio = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
            DateTime fechaFinal = Convert.ToDateTime(fecha2.Value.Date.ToString("dd/MM/yyyy"));
            if (fechaInicio > fechaFinal)
            {
                dt = amd.promedioAportesPorUsuario(fechaFinal, fechaInicio);
            }
            else
            {
                dt = amd.promedioAportesPorUsuario(fechaInicio, fechaFinal);         
            }
            cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filtraXfechas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }
    }
}
