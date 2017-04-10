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
    public partial class gravedadDenuncias : Form
    {
        DataTable dt;
        private MetodosConsultante amd = new MetodosConsultante();
        private DatosDireccion dir = new DatosDireccion();
        public gravedadDenuncias()
        {
            InitializeComponent();
            fFecha.Hide();
            fecha.Hide();
            fecha2.Hide();
            Provincia.Hide();
            canton.Hide();
            distritos.Hide();
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
        public void consultarFiltroDenunciaFecha()
        {
            DateTime inicio = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
            DateTime final = Convert.ToDateTime(fecha2.Value.Date.ToString("dd/MM/yyyy"));
            if (inicio < final)
            {
                dt = amd.FiltroDenunciaGravedadFecha(inicio, final);
            }
            else
            {
                dt = amd.FiltroDenunciaGravedadFecha(final, inicio);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            consultarFiltroDenunciaFecha();
            cargar();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo1.SelectedItem.ToString() == "Total de Denuncias"){
                fFecha.Hide();
                fecha.Hide();
                fecha2.Hide();
                Provincia.Hide();
                canton.Hide();
                distritos.Hide();
                dt = amd.denunciasPorGravedad();
                cargar();
            }

            else if (combo1.SelectedItem.ToString() == "Filtro por Fechas")
            {
                fFecha.Show();
                fecha.Show();
                fecha2.Show();
                Provincia.Hide();
                canton.Hide();
                distritos.Hide();
            }
            else if (combo1.SelectedItem.ToString() == "Filtro por Provincia"){
                fFecha.Hide();
                fecha.Hide();
                fecha2.Hide();
                Provincia.Show();
                canton.Hide();
                distritos.Hide();
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
                distritos.Items.Clear();
                distritos.Text = "Distrito";
                canton.Items.Clear();
                canton.Text = "Cantón";
                Provincia.Items.Clear();
                Provincia.Text = "Provincia";
                cargarProvincia();
            }

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

            dt = amd.FiltroDenunciaGravedadCanton(canton.SelectedItem.ToString());
            cargar();
        } 
        private void cargarProvincia() {
            dt = dir.cargarProvincias();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Provincia.Items.Add(dt.Rows[i][0].ToString());
            }
        }
        private void cargarCantones()
        {
            dt = dir.cargarCantones(Provincia.SelectedItem.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                canton.Items.Add(dt.Rows[i][0].ToString());
            }
        }
        private void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            canton.Items.Clear();
            distritos.Items.Clear();
            canton.Text = "Canton";
            distritos.Text = "Distrito";
            cargarCantones();
            dt = amd.FiltroDenunciaGravedadProvincia(Provincia.SelectedItem.ToString());
            cargar();
        }
        private void distritos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dt = amd.FiltroDenunciaGravedadDistrito(distritos.SelectedItem.ToString());
            cargar();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }

        
    }
}


