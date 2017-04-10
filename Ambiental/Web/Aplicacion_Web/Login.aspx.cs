using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Capa_Negocios_Cliente;


namespace Aplicacion_Web
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {}

        //Metodo que verifica al usuario
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Variables que contienen los datos ingresados por el usuario
            string username = txtUsuario.Text;
            string password = txtPassword.Text;

            //Labels de verificacion de errores
            lblErrorUsername.Visible = false;
            lblErrorPassword.Visible = false;
            lblErrorIngreso.Visible = false;

            //Verifica si el textbox de usuario está vacío
            if (username == "") lblErrorUsername.Visible = true;
            
            //Verifica si el textbox de contraseña está vacío
            else if(password == "")lblErrorPassword.Visible = true;
            
            //Verificaciones realizadas
            else
            {
                //Asignacion de atributos a la instancia chequeoLogin
                InicioSesion login = new InicioSesion();
                string resultado;
                login.user = username;
                login.contraseña = password;
                resultado = login.verificarLogin();
                
                //Verifica si el usuario es el correcto
                if(resultado == "Desactivado") lblErrorIngreso.Visible = true;
                else if (resultado != "Incorrecto")
                {

                    try
                    {
                        //Se almacena en la cookie
                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie["idUsuario"] = resultado;
                        cookie["Name"] = txtUsuario.Text;
                        cookie.Expires = DateTime.Now.AddDays(30);
                        login.idUsuario = Int32.Parse(resultado);
                        DataTable puntos = login.recuperarPuntos();         //Se recuperan los puntos del usuario
                        cookie["puntos"] = puntos.Rows[0][0].ToString();
                        Response.Cookies.Add(cookie);                       //Se agrega la cookie

                        //Se busca el rol del usuario
                        string rolCorrespondiente = login.recuperarRol();
                        if (rolCorrespondiente == "Guardian")
                        {
                            Response.Redirect("HomeGuardian.aspx", false);
                        }
                        else if (rolCorrespondiente == "Oficial")
                        {
                            Response.Redirect("HomeOficial.aspx", false);
                        }
                        else if (rolCorrespondiente == "Juez")
                        {
                            Response.Redirect("HomeJuez.aspx", false);
                        }
                        else
                        {
                            lblErrorIngreso.Visible = true;
                        }
                    }
                    catch(Exception ex)
                    {
                        lblErrorIngreso.Visible = true;
                    }
                }
                else lblErrorIngreso.Visible = true;
            }
        }

        //Evento al presionar el link Crear Usuario
        protected void lnkCrearUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearUsuario.aspx");
        }

        //Evento al presionar el link Informacion
        protected void lnkInformacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcercaDe.aspx");
        }
    }
}