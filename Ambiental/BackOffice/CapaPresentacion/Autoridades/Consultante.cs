using CapaPresentacion.Denuncias;
using CapaPresentacion.Soluciones;
using CapaPresentacion.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;
using CapaPresentacion.Autoridades;
using CapaPresentacion.Aportes;

namespace CapaPresentacion
{
    public partial class Consultante : Form
    {
        static int id;
        private MetodosConsultante amd = new MetodosConsultante();
        public Consultante(String idx)
        {
            InitializeComponent();
            id = Int32.Parse(idx);
        }
        public Consultante()
        {
            InitializeComponent();
           
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            gravedadDenuncias denu = new gravedadDenuncias();
            denu.Show();
            this.Hide();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ListadosDeUsuarios list = new ListadosDeUsuarios();
            list.Show();
            this.Hide();
        }

        private void tileItem17_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            DateTime fechaX = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
            amd.insertarEnBitacora(fechaX, "Cerró la sesión como Consultante", id);
            Login atras = new Login();
            atras.Show();
            this.Hide();
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ListadoRoles listado = new ListadoRoles();
            listado.Show();
            this.Hide();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            guardianesConMasDenunciasRechazadas gu = new guardianesConMasDenunciasRechazadas();
            gu.Show();
            this.Hide();
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            reporteGeneralAportes rep = new reporteGeneralAportes();
            rep.Show();
            this.Hide();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            reporteGeneralDenuncias denuncias = new reporteGeneralDenuncias();
            denuncias.Show();
            this.Hide();
        }

     

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            promedioAportes mapX = new promedioAportes();
            mapX.Show();
            this.Hide();
        }

        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            listadosAportesDenunciasOG listado = new listadosAportesDenunciasOG();
            listado.Show();
            this.Hide();
        }

        private void tileItem15_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            mostrarXML xml = new mostrarXML();
            xml.Show();
            this.Hide();
        }

        private void tileItem12_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            reportePropuestasSolucion prop = new reportePropuestasSolucion();
            prop.Show();
            this.Hide();
        }

        private void tileItem13_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            bitacora bit = new bitacora();
            bit.Show();
            this.Hide();
        }

        private void tileItem9_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            solucionesXOficial soluciones = new solucionesXOficial();
            soluciones.Show();
            this.Hide();
        }

        private void tileItem11_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            solucionesXJuez evaluadas = new solucionesXJuez();
            evaluadas.Show();
            this.Hide();
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TopXDenunciasReportadas denu = new TopXDenunciasReportadas();
            denu.Show();
            this.Hide();
        }

        private void tileItem14_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            consultaDenunciaEspecifica consulta = new consultaDenunciaEspecifica();
            consulta.Show();
            this.Hide();
        }

        
    }
}
