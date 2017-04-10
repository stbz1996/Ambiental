using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Device.Location;
using Capa_Negocios_Cliente;

namespace Aplicacion_Web
{
    public partial class CrearDenunciaGuardian : System.Web.UI.Page
    {
        //Variables globales necesarias
        private Direccion direccion = new Direccion();
        Denuncia denuncia = new Denuncia();
        byte[] bytes;

        //Evento al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null) lblObtenerPuntos.Text = cookie["puntos"];

                //Se insertan las provincias
                DataTable tableProvincia = direccion.listadoProvincias();
                DataRow row;
                for (int i = 0; i < 7; i++)
                {
                    row = tableProvincia.Rows[i];
                    ddlProvincia.Items.Add(new ListItem(row["nombreProvincia"].ToString(), (i + 1).ToString()));
                }
            }
        }

        //Evento al presionar el botón de actualizar el cantón
        protected void btnActualizarCanton_Click(object sender, EventArgs e)
        {
            //Variables locales necesarias
            direccion.nombreProvincia = ddlProvincia.SelectedItem.Text;
            DataTable tableCanton = direccion.listadoCanton();
            DataRow row;
       
            ddlCanton.Items.Clear();                            //Se limpia la pantalla

            //Se insertan los cantones de la provincia correspondiente
            for (int i = 0; i < tableCanton.Rows.Count; i++)
            {
                row = tableCanton.Rows[i];
                ddlCanton.Items.Add(new ListItem(row["nombreCanton"].ToString(), (i+1).ToString()));

            }
        }

        //Evento al presionar el botón de actualizar distrito
        protected void btnActualizarDistrito_Click(object sender, EventArgs e)
        {
            //Variables locales
            direccion.nombreCanton = ddlCanton.SelectedItem.Text;
            DataTable tableDistrito = direccion.listadoDistrito();
            DataRow row;

            ddlDistrito.Items.Clear();                          //Se limpia la pantalla

            //Se insertan los distritos del cantón
            for (int i = 0; i < tableDistrito.Rows.Count; i++)
            {
                row = tableDistrito.Rows[i];
                ddlDistrito.Items.Add(new ListItem(row["nombreDistrito"].ToString(), (i+1).ToString()));
            }
        }

        //Evento al presionar el boton crear denuncia
        protected void btnCrearDenuncia_Click(object sender, EventArgs e)
        {
            //Modificación de elementos de la página necesarios
            lblRestriccionDireccion.Visible = false;
            lblRestriccionTitulo.Visible = false;
            lblRestriccionImagen.Visible = false;
            lblRestriccionAgregarImagen.Visible = false;
            lblRestriccionFormatoImagen.Visible = false;

            //Validaciones necesarias
            if (txtTitulo.Text == "") lblRestriccionTitulo.Visible = true;
            else if (ddlCanton.Items.Count == 0 ||
                    ddlDistrito.Items.Count == 0 ||
                    hdfLatitud.Value == "" || hdfLongitud.Value == "") lblRestriccionDireccion.Visible = true;
            else if (fileUploadImage.HasFile == false) lblRestriccionAgregarImagen.Visible = true;
            else crearDenuncia();                       //Llamar el método después de pasar las verificaciones

        }

        //Método que crea la denuncia
        protected void crearDenuncia()
        {
            //Asignacion del usuario
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                denuncia.idUsuario = Int32.Parse(cookie["idUsuario"]);
            }

            //Asignacion de la imagen
            HttpPostedFile postedFile = fileUploadImage.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
               fileExtension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                bytes = binaryReader.ReadBytes((int)stream.Length);
                denuncia.foto = bytes;

                //Asignar datos restantes
                denuncia.titulo = txtTitulo.Text;
                denuncia.latitud = hdfLatitud.Value;
                denuncia.longitud = hdfLongitud.Value;
                denuncia.descripcion = txtDescripcion.Text;
                denuncia.provincia = ddlProvincia.SelectedItem.Text;
                denuncia.canton = ddlCanton.SelectedItem.Text;
                denuncia.distrito = ddlDistrito.SelectedItem.Text;
                denuncia.detalle = txtDetalle.Text;
                denuncia.registroDenuncia();
                Response.Redirect("AgregarHashtagDenuncia.aspx", true);           // Se direcciona a otra página
            }
            else lblRestriccionFormatoImagen.Visible = true;
        }
    }
}