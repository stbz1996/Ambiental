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
    public partial class AgregarHashtagDenuncia : System.Web.UI.Page
    {
        //Variable global necesaria
        Denuncia denuncia = new Denuncia();
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

        //Evento al precionar el botón 'Agregar Hashtag'
        protected void btnAgregarHashtag_Click(object sender, EventArgs e)
        {
            
            string hashtag = txtHashtag.Text;
            lblRestriccionHashtag.Visible = false;
            lblExitoHashtag.Visible = false;

            //Verifica que no se encuentre vacío el textbox 
            if (hashtag != "")
            {
                //Verifica si el primer caracter corresponde un #
                if ((hashtag.Substring(0, 1)) == "#" && !(hashtag.Contains(" ")))
                {
                    //Solicita al usuario
                    HttpCookie cookie = Request.Cookies["UserInfo"];
                    if (cookie != null)
                    {
                        denuncia.idUsuario = Int32.Parse(cookie["idUsuario"]);
                    }
                    denuncia.hashtag = hashtag;        //Asigna el hashtag
                    denuncia.registroHashtag();        
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

        //Evento al presionar el botón salir
        protected void btnSalir_Click(object sender, EventArgs e)
        {
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
            Response.Redirect("HomeGuardian.aspx", true);
        }
    }
}