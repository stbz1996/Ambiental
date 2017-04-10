using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;
using System.Xml;

namespace CapaPresentacion.Usuarios
{
    public partial class mostrarXML : Form
    {
        private MetodosConsultante amd = new MetodosConsultante();
        DataTable dt;
        public mostrarXML()
        {
            InitializeComponent();
            cargar();
        }

        public void cargar()
        {
            dt = amd.DocXML();
            Console.Write(dt.Rows[0][0].ToString());
            label.Text = dt.Rows[0][0].ToString();

        }
    }
}
