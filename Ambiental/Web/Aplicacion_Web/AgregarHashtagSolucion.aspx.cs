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
    public partial class AgregarHashtagSolucion : System.Web.UI.Page
    {
        //Variables globales necesarias
        private Solucion solucion = new Solucion();

        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            //Uso de cookies para el usuario
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                //Se realizan cambios en la ventana
                lblObtenerPuntos.Text = cookie["puntos"];
            }
        }

        //Evento al presionar el boton AgregarHashtag
        protected void btnAgregarHashtag_Click(object sender, EventArgs e)
        {
            string hashtag = txtHashtag.Text;
            lblRestriccionHashtag.Visible = false;
            lblExitoHashtag.Visible = false;

            //Verifica que no se encuentre vacío el textbox 
            if (hashtag != "")
            {
                //Verifica si el primer caracter corresponde un #
                if (hashtag.Substring(0, 1) == "#" && !(hashtag.Contains(" ")))
                {
                    //Solicita al usuario
                    HttpCookie cookie = Request.Cookies["UserInfo"];
                    if (cookie != null)
                    {
                        solucion.idUsuario = Int32.Parse(cookie["idUsuario"]);
                    }
                    solucion.hashtag = hashtag;        //Asigna el hashtag
                    solucion.registroHashtag();
                    txtHashtag.Text = "";                   //Se limpia el textBox
                    lblExitoHashtag.Visible = true;
                }
                else
                {
                    lblRestriccionHashtag.Visible = true;
                }
            }
            else
            {
                lblRestriccionHashtag.Visible = true;
            }
        }

        //Evento al presionar el boton Salir
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            //Se cambiam los elementos de la ventana
            lblHashtag.Visible = false;
            txtHashtag.Visible = false;
            lblExitoHashtag.Visible = false;
            lblRestriccionHashtag.Visible = false;
            btnAgregarHashtag.Visible = false;
            btnSalir.Visible = false;
            btnSalir2.Visible = true;
            lblExitoCrearDenuncia.Visible = true;
        }

        //Evento al presionar el boton Salir2
        protected void btnSalir2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeOficial.aspx", true);
        }
    }
}