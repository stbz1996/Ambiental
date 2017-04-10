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
    public partial class ListadoRoles : Form
    {
        private MetodosConsultante amd = new MetodosConsultante();
      
        public ListadoRoles()
        {
            InitializeComponent();
            grid1.Hide();
            grid2.Hide();
            grid3.Hide();
        }

        public void cargarJueces()
        {
            DataTable dt = amd.listadoJueces();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grid1.Rows.Add(dt.Rows[i][0]);
                grid1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                grid1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
               
            }
        }
        public void cargarOficiales()
        {
            DataTable dt = amd.listadoOficiales();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grid3.Rows.Add(dt.Rows[i][0]);
                grid3.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                grid3.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();

            }
        }
        public void cargarGuardianess()
        {
            DataTable dt = amd.listadoGuardianes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grid2.Rows.Add(dt.Rows[i][0]);
                grid2.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                grid2.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            grid3.Hide();
            grid1.Hide();
            grid2.Show();
            grid2.Rows.Clear();
            cargarGuardianess();
        }
        private void button1_Click(object sender, EventArgs e)
        {   
            grid1.Hide();
            grid2.Hide();
            grid3.Show();
            grid3.Rows.Clear();
            cargarOficiales();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cargarJueces();
            grid3.Hide();
            grid2.Hide();
            grid1.Show();
            grid1.Rows.Clear();
            cargarJueces();
        }
    }
}
