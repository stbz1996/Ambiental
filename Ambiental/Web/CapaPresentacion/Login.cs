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

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        private VerificaLogin log = new VerificaLogin();
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
                dt = log.VerificarLogin();


                if (dt.ToString() == "Incorrecto")
                {
                    // verificar lo de la cedula jaja
                    MessageBox.Show("Usuario no registrado", "My Application",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show(dt + " Login completado" , "My Application",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /*########################################################*/

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verifLogin();
            //interfazAdministrador admin =  new interfazAdministrador();
            //admin.Show();
            //this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
