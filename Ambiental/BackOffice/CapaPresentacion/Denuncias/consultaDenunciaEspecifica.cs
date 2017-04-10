using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;
using System.IO;

namespace CapaPresentacion.Denuncias
{
    public partial class consultaDenunciaEspecifica : Form
    {
        private DatosDireccion dir = new DatosDireccion();
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public consultaDenunciaEspecifica()
        {
            InitializeComponent();
        }

        public void cargar()
        {       
                grid3.Rows.Clear();
                grid4.Rows.Clear();
                grid3.Rows.Add(dt.Rows[0][0]);
                grid4.Rows.Add(dt.Rows[0][0]);
                grid3.Rows[0].Cells[0].Value = dt.Rows[0][0].ToString();
                grid3.Rows[0].Cells[1].Value = dt.Rows[0][1].ToString();
                grid3.Rows[0].Cells[2].Value = dt.Rows[0][2].ToString();
                grid3.Rows[0].Cells[3].Value = dt.Rows[0][3].ToString();
                grid3.Rows[0].Cells[4].Value = dt.Rows[0][4].ToString();
                grid3.Rows[0].Cells[5].Value = dt.Rows[0][5].ToString();
                grid3.Rows[0].Cells[6].Value = dt.Rows[0][6].ToString();
                grid3.Rows[0].Cells[7].Value = dt.Rows[0][7].ToString();
                grid3.Rows[0].Cells[8].Value = amd.obtenerGuardianDenuncia(Int32.Parse(dt.Rows[0][8].ToString())).Rows[0][0].ToString();
                grid3.Rows[0].Cells[9].Value = amd.obtenerTextoDireccion(Int32.Parse(dt.Rows[0][9].ToString())).Rows[0][0].ToString();


                try{
                    byte[] datos = (byte[])dt.Rows[0][7];
                    MemoryStream Bin = new MemoryStream(datos);
                    Image imagen = Image.FromStream(Bin);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = imagen;
                }
                catch(Exception exx){}

                try
                {
                    grid4.Rows[0].Cells[0].Value = dt.Rows[0][10].ToString();
                    grid4.Rows[0].Cells[1].Value = dt.Rows[0][11].ToString();
                    grid4.Rows[0].Cells[2].Value = dt.Rows[0][13].ToString();
                    grid4.Rows[0].Cells[3].Value = dt.Rows[0][14].ToString();
                    grid4.Rows[0].Cells[4].Value = amd.obtenerOficialDenuncia(Int32.Parse(dt.Rows[0][15].ToString())).Rows[0][0].ToString();
                }
                catch(Exception e)
                {
                    grid4.Rows[0].Cells[0].Value = "--------";
                    grid4.Rows[0].Cells[1].Value = "--------";
                    grid4.Rows[0].Cells[2].Value = "--------";
                    grid4.Rows[0].Cells[3].Value = "--------";
                    grid4.Rows[0].Cells[4].Value = "--------";
                }
            
            
        }

        public void cargarDenuncia()
        {
            if (ide.Text != "")
            {
                try
                {
                    int ident = Int32.Parse(ide.Text);
                    dt = amd.CargarDenunciaEspecifica(ident);
                    cargar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La denuncia con ese identificador no está registrada", "Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ide.Text = "";
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            cargarDenuncia();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultante atras = new Consultante();
            atras.Show();
            this.Hide();
        }

  

       
    }
}
