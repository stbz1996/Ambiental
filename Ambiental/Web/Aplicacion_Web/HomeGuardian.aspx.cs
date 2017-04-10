using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion_Web
{
    public partial class HomeGuardian : System.Web.UI.Page
    {
        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Uso de cookies para el usuario
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                //Se realizan cambios en la ventana
                lblNombre.Text = cookie["Name"];
                lblObtenerPuntos.Text = cookie["puntos"];
            }

        }
    }
}