using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.IO;
using Capa_Negocios_Cliente;

namespace Aplicacion_Web
{
    public partial class CrearAporteOficial : System.Web.UI.Page
    {
        //Variables globales necesarias
        private Aporte aporte = new Aporte();
        byte[] bytes;

        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null) lblObtenerPuntos.Text = cookie["puntos"];

                //Insertar los tipos de aporte
                DataTable tableTipoAporte = aporte.listadoTipoAporte();
                DataRow row;
                for (int i = 0; i < tableTipoAporte.Rows.Count; i++)
                {
                    row = tableTipoAporte.Rows[i];
                    ddlTipoAporte.Items.Add(new ListItem(row["nombre"].ToString(), (i + 1).ToString()));
                }
            }
        }

        //Evento al agregar un aporte
        protected void btnAgregarAporte_Click(object sender, EventArgs e)
        {

            //Asignacion de la foto
            HttpPostedFile postedFile = fileUploadImage.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;
            lblRestriccionAgregarImagen.Visible = false;
            lblRestriccionFormatoImagen.Visible = false;

            if (fileUploadImage.HasFile == false) lblRestriccionAgregarImagen.Visible = true;
            //Verifica el formato de la foto
            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
               fileExtension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                bytes = binaryReader.ReadBytes((int)stream.Length);
                aporte.foto = bytes;


                //Asignacion de puntos
                int posicion = Int32.Parse(ddlTipoAporte.SelectedValue.ToString());
                int valor;
                if (posicion >= 1 && posicion <= 5)
                {
                    aporte.valor = 5;
                    valor = 5;
                }
                else
                {
                    aporte.valor = 10;
                    valor = 10;
                }
                //Asignacion del usuario
                HttpCookie cookie = Request.Cookies["UserInfo"];

                if (cookie != null)
                {
                    aporte.idUsuario = Int32.Parse(cookie["idUsuario"]);
                }

                //Actualiza los datos del usuario
                HttpCookie response = Response.Cookies["UserInfo"];
                if (response != null)
                {
                    response["idUsuario"] = cookie["idUsuario"];
                    response["Name"] = cookie["Name"];
                    int puntos = Int32.Parse(cookie["puntos"]) + valor;
                    response["puntos"] = puntos.ToString();
                }


                aporte.fecha = DateTime.Today;
                aporte.idTipoAporte = Int32.Parse(ddlTipoAporte.SelectedValue);
                aporte.registrarAporte();
                limpiarPantalla();
            }
            else lblRestriccionFormatoImagen.Visible = true;
        }

        //Metodo para limpiar la pantalla
        private void limpiarPantalla()
        {
            lblTipoAporte.Visible = false;
            lblExitoAporte.Visible = true;
            ddlTipoAporte.Visible = false;
            btnSalir.Visible = true;
            lblImagen.Visible = false;
            fileUploadImage.Visible = false;
            lblRestriccionAgregarImagen.Visible = false;
            lblRestriccionFormatoImagen.Visible = false;
            btnAgregarAporte.Visible = false;
        }

        //Evento al presionar el boton Salir
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeOficial.aspx", true);
        }
    }
}