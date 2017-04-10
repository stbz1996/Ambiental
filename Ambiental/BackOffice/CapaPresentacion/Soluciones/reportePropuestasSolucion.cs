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
    public partial class reportePropuestasSolucion : Form
    {
        private DatosDireccion dir = new DatosDireccion();
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public reportePropuestasSolucion()
        {
            InitializeComponent();
            fecha.Hide();
            label1.Hide();
            Provincia.Hide();
            canton.Hide();
            distritos.Hide();
            box.Hide();
            hash.Hide();
        }
        public void cargarTodas()
        {
            dt = amd.cargarReportePropuestaSolucion();
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
                    grid3.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    grid3.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    grid3.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    grid3.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    grid3.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    grid3.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    grid3.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();

                    Console.WriteLine(dt.Rows[i][7].ToString());
                    if (dt.Rows[i][7].ToString() == "True")
                    {
                        grid3.Rows[i].Cells[7].Value = "Aceptada";
                    }
                    else
                    {
                        grid3.Rows[i].Cells[7].Value = "No Aceptada";
                    }
                    
                }
            }
            catch (Exception ex){
                MessageBox.Show("No se han podido cargar los datos, intente mas tarde", "",
               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid3.Rows.Clear();
            if (combo.SelectedItem.ToString() == "Cargar todas las denuncias")
            {
                fecha.Hide();
                label1.Hide();
                Provincia.Hide();
                canton.Hide();
                distritos.Hide();
                box.Hide();
                hash.Hide();
                cargarTodas();
 
            }
            else if (combo.SelectedItem.ToString() == "Filtro por Fecha")
            {
                fecha.Show();
                Provincia.Hide();
                canton.Hide();
                distritos.Hide();
                label1.Show();
                box.Hide();
                hash.Hide();
            }
            else if (combo.SelectedItem.ToString() == "Filtro por Provincia")
            {
                fecha.Hide();
                label1.Hide();    
                Provincia.Show();
                canton.Hide();
                distritos.Hide();
                Provincia.Items.Clear();
                Provincia.Text = "Provincia";
                box.Hide();
                hash.Hide();
                cargarProvincia();
            }
            else if (combo.SelectedItem.ToString() == "Filtro por Cantón")
            {
                fecha.Hide();
                label1.Hide();               
                Provincia.Show();
                canton.Show();
                distritos.Hide();

                canton.Items.Clear();
                canton.Text = "Cantón";
                Provincia.Items.Clear();
                Provincia.Text = "Provincia";
                box.Hide();
                hash.Hide();
                cargarProvincia();
            }
            else if (combo.SelectedItem.ToString() == "Filtro por Distrito")
            {
                fecha.Hide();
                label1.Hide();
                Provincia.Show();
                canton.Show();
                distritos.Show();
                distritos.Items.Clear();
                distritos.Text = "Distrito";
                canton.Items.Clear();
                canton.Text = "Cantón";
                Provincia.Items.Clear();
                Provincia.Text = "Provincia";
                box.Hide();
                hash.Hide();
                cargarProvincia();
            }
            else if (combo.SelectedItem.ToString() == "Filtro por HashTag")
            {
                fecha.Hide();
                label1.Hide();
                Provincia.Hide();
                canton.Hide();
                distritos.Hide();
                box.Show();
                hash.Show();

            }
        }
        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaX = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
            dt = amd.cargarReportePropuestaSolucionFiltroFecha(fechaX);
            cargar();
        }
        private void cargarCantones()
        {
            dt = dir.cargarCantones(Provincia.SelectedItem.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                canton.Items.Add(dt.Rows[i][0].ToString());
            }
        }
        private void cargarProvincia()
        {
            dt = dir.cargarProvincias();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Provincia.Items.Add(dt.Rows[i][0].ToString());
            }
        }
        private void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            canton.Items.Clear();
            distritos.Items.Clear();
            canton.Text = "Canton";
            distritos.Text = "Distrito";
            cargarCantones();

            dt = amd.cargarReportePropuestaSolucionFiltroProvincia(Provincia.SelectedItem.ToString());
            cargar();
        }
        private void canton_SelectedIndexChanged(object sender, EventArgs e)
        {
            distritos.Items.Clear();
            distritos.Text = "Distrito";

            dt = dir.cargarDistritos(canton.SelectedItem.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                distritos.Items.Add(dt.Rows[i][0].ToString());
            }
            dt = amd.cargarReportePropuestaSolucionFiltroCanton(canton.SelectedItem.ToString());
            cargar();
        }
        private void distritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = amd.cargarReportePropuestaSolucionFiltroDistrito(distritos.SelectedItem.ToString());
            cargar();
        }
        private void box_TextChanged(object sender, EventArgs e)
        {
            dt = amd.cargarReportePropuestaSolucionFiltroHashtag(box.Text);
            cargar();
        }
    }
}
