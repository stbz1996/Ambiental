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
    public partial class reporteGeneralDenuncias : Form
    {
        private DatosDireccion dir = new DatosDireccion();
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public reporteGeneralDenuncias()
        {
            InitializeComponent();
            fecha.Hide();
            fecha2.Hide();
            fFecha.Hide();
            Provincia.Hide();
            canton.Hide();
            distritos.Hide();
            hash.Hide();
            label.Hide();
            
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
                    grid3.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                    grid3.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cargarDenunciasXfecha()
        {
            DateTime fechaInicio = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
            DateTime fechaFinal = Convert.ToDateTime(fecha2.Value.Date.ToString("dd/MM/yyyy"));

            if (fechaInicio > fechaFinal)
            {
                dt = amd.cargarDenunciasXfecha(fechaFinal, fechaInicio);
                cargar();
            }
            else
            {
                dt = amd.cargarDenunciasXfecha(fechaInicio, fechaFinal);
                cargar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDenunciasXfecha();
        }

        private void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            canton.Items.Clear();
            distritos.Items.Clear();
            canton.Text = "Canton";
            distritos.Text = "Distrito";
            cargarCantones();

            dt = amd.cargarDenunciasXprovinciaa(Provincia.SelectedItem.ToString());
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
            //
            dt = amd.cargarDenunciasXCanton(canton.SelectedItem.ToString());
            cargar();
        }

        private void distritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = amd.cargarDenunciasXDistrion(distritos.SelectedItem.ToString());
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

        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo1.SelectedItem.ToString() == "Filtro por Fechas")
            {
                // oculta todo
                fFecha.Show();
                fecha.Show();
                fecha2.Show();
                Provincia.Hide();
                canton.Hide();
                distritos.Hide();
                hash.Hide();
                label.Hide();
                
            }
            else if (combo1.SelectedItem.ToString() == "Filtro por Provincia")
            {
                fFecha.Hide();
                fecha.Hide();
                fecha2.Hide();
                Provincia.Show();
                canton.Hide();
                distritos.Hide();
                hash.Hide();
                label.Hide();
                Provincia.Items.Clear();
                Provincia.Text = "Provincia";
                cargarProvincia();
            }

            else if (combo1.SelectedItem.ToString() == "Filtro por Canton")
            {
                fFecha.Hide();
                fecha.Hide();
                fecha2.Hide();
                Provincia.Show();
                canton.Show();
                distritos.Hide();
                hash.Hide();
                label.Hide();
                canton.Items.Clear();
                canton.Text = "Cantón";
                Provincia.Items.Clear();
                Provincia.Text = "Provincia";
                cargarProvincia();
            }
            else if (combo1.SelectedItem.ToString() == "Filtro por Distrito")
            {
                fFecha.Hide();
                fecha.Hide();
                fecha2.Hide();
                Provincia.Show();
                canton.Show();
                distritos.Show();
                
                hash.Hide();
                label.Hide();
                distritos.Items.Clear();
                distritos.Text = "Distrito";
                canton.Items.Clear();
                canton.Text = "Cantón";
                Provincia.Items.Clear();
                Provincia.Text = "Provincia";
                cargarProvincia();
            }
            else if (combo1.SelectedItem.ToString() == "Filtro por HashTag")
            {
                fFecha.Hide();
                fecha.Hide();
                fecha2.Hide();
                Provincia.Hide();
                canton.Hide();
                distritos.Hide();
                hash.Show();
                label.Show();  
            }
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            dt = amd.cargarDenunciasXhastag(hash.Text);
            cargar();
        }

        private void hash_TextChanged(object sender, EventArgs e)
        {
            dt = amd.cargarDenunciasXhastag(hash.Text);
            cargar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }
    }
}
