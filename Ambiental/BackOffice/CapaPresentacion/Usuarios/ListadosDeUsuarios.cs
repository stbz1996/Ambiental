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
    public partial class ListadosDeUsuarios : Form
    {
        
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public ListadosDeUsuarios()
        {
            InitializeComponent();
            dt = amd.cargarUsuarios();
            this.llenaDatos(dt, "Persona");
        }

        public void llenaDatos(DataTable dt, String tipo)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grid1.Rows.Add(dt.Rows[i][0]);
                    grid1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    grid1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    grid1.Rows[i].Cells[3].Value = amd.BuscarRol(dt.Rows[i][0].ToString());
                    grid1.Rows[i].Cells[4].Value = dt.Rows[i][1].ToString();
                    grid1.Rows[i].Cells[1].Value = amd.verEstado(dt.Rows[i][0].ToString());
                    grid1.Rows[i].Cells[5].Value = dt.Rows[i][3].ToString();
                    grid1.Rows[i].Cells[6].Value = dt.Rows[i][5].ToString();
                    grid1.Rows[i].Cells[7].Value = dt.Rows[i][6].ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error a la hora de cargar los datos, Intente más tarde", "",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }

    }
}
