using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogicaNegocio;
using System.Diagnostics;
using CapaPresentacion.Autoridades;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        private VerificaLogin log = new VerificaLogin();
        private MetodosAdministrador amd = new MetodosAdministrador();

     
        public Login(){
            InitializeComponent();
        }

        private void verifLogin()
        {
            try
            {
                String dt;
                log.user = this.pusuario.Text;
                log.contraseña = this.pcontrasena.Text;
                if (this.pusuario.Text == "" || this.pcontrasena.Text == "")
                {
                    MessageBox.Show("Debe colocar los datos correctamente", "No existe la Autoridad registrada en el sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
                else {
                    dt = log.VerificarLogin();
                    if (dt.ToString() == "Incorrecto") {
                        MessageBox.Show("Autoridad no registrada", "No existe la Autoridad registrada en el sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    
                    else {
                        log.id = dt;
                        String rolActual = log.BuscarRol();
                        int idX = Int32.Parse(log.id);
                        DateTime fechaX = DateTime.Now;
                        amd.insertarEnBitacora(fechaX, "Inició la sesión", idX);

                        if (rolActual == "administra" || rolActual == "consultant") {
                            establecePantallaPorRol(rolActual);
                        }
                        else
                        {
                            MessageBox.Show("No existe la Autoridad registrada en el sistema", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("No existe la Autoridad registrada en el sistema", "",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                String x = e.Message;
            }
        }
        
        // proporciona la interfaz de cada usuario
        private void establecePantallaPorRol(String rol) {
            if (rol == "administra")
            {

                AdminMejorado ventanaAdmin = new AdminMejorado(log.id);
                ventanaAdmin.Show();
            }
            else
            {
                Consultante ventanaconsultante = new Consultante(log.id);
                ventanaconsultante.Show();
            }
            this.Hide();




        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            verifLogin();
        }
    }
}
