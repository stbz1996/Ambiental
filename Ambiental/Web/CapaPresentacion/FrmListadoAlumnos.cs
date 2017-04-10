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
    public partial class FrmListadoAlumnos : Form
    {
        private AgregarPersona Alu = new AgregarPersona();

        public FrmListadoAlumnos(){
            InitializeComponent();
        }

        private void FrmListadoAlumnos_Load(object sender, EventArgs e)
        {
            try{
                ListarPersonas();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }    
        }


        // Lista las personas
        private void ListarPersonas()
        {
            DataTable dt = new DataTable();
            dt = Alu.Listado();

            //Recorremos el DataTable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ventanaPersonas.Rows.Add(dt.Rows[i][0]);
                ventanaPersonas.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();//cedula
                ventanaPersonas.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString();//nombre
                ventanaPersonas.Rows[i].Cells[2].Value = dt.Rows[i][3].ToString() + " " + dt.Rows[i][4].ToString();//Apellidos
                ventanaPersonas.Rows[i].Cells[3].Value = DateTime.Now.Year - Convert.ToDateTime(dt.Rows[i][5].ToString()).Year;
                ventanaPersonas.Rows[i].Cells[4].Value = dt.Rows[i][6].ToString();
                ventanaPersonas.Rows[i].Cells[5].Value = dt.Rows[i][7].ToString();
                ventanaPersonas.Rows[i].Cells[6].Value = dt.Rows[i][9].ToString();
                ventanaPersonas.Rows[i].Cells[7].Value = dt.Rows[i][10].ToString();  
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
