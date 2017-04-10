using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion_Web
{
    public partial class HomeJuez : System.Web.UI.Page
    {
        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                //Se realizan cambios en la interfaz
                lblNombre.Text = cookie["Name"];
                lblObtenerPuntos.Text = cookie["puntos"];
            }
        }
    }
}