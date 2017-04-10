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
    public partial class CrearSolucionOficial : System.Web.UI.Page
    {
        //Variables globales necesarias
        private Solucion solucion = new Solucion();
        private Denuncia denuncia = new Denuncia();

        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null) lblObtenerPuntos.Text = cookie["puntos"];

            //Variables locales necesarias
            DataTable denuncias = denuncia.listadoDenunciasOficial();
            string fechaDenuncia;

            //Cargar los elementos en una tabla
            for (int i = 0; i < denuncias.Rows.Count; i++)
            {
                //Se crea una nueva fila y varias celdas
                TableRow nuevaFila = new TableRow();
                TableCell idDenuncia = new TableCell();
                TableCell titulo = new TableCell();
                TableCell fecha = new TableCell();
                TableCell provincia = new TableCell();
                TableCell canton = new TableCell();
                TableCell distrito = new TableCell();
                TableCell detalle = new TableCell();

                //Se asignan los valores en las celdas correspondientes
                idDenuncia.Text = denuncias.Rows[i][0].ToString();
                titulo.Text = denuncias.Rows[i][1].ToString();
                fechaDenuncia = denuncias.Rows[i][2].ToString();
                fecha.Text = fechaDenuncia.Substring(0,10);
                provincia.Text = denuncias.Rows[i][3].ToString();
                canton.Text = denuncias.Rows[i][4].ToString();
                distrito.Text = denuncias.Rows[i][5].ToString();
                detalle.Text = denuncias.Rows[i][6].ToString();

                //Se agregan las celdas a la fila
                nuevaFila.Cells.Add(idDenuncia);
                nuevaFila.Cells.Add(titulo);
                nuevaFila.Cells.Add(fecha);
                nuevaFila.Cells.Add(provincia);
                nuevaFila.Cells.Add(canton);
                nuevaFila.Cells.Add(distrito);
                nuevaFila.Cells.Add(detalle);

                tblDenuncias.Rows.Add(nuevaFila);           //Se agrega la fila en la tabla correspondiente
            }
        }

        //Evento al presionar el boton Iniciar Solucion
        protected void btnIniciarSolucion_Click(object sender, EventArgs e)
        {
            lblRestriccionExisteID.Visible = false;
            lblRestriccionEstado.Visible = false;
            try
            {
                hdfIdDenuncia.Value = txtIdDenuncia.Text;
                denuncia.idDenuncia = Int32.Parse(hdfIdDenuncia.Value);
                DataTable tableDenuncia = denuncia.denunciaEspecifica();
                if (tableDenuncia.Rows[0][8].ToString() != "En Proceso") lblRestriccionEstado.Visible = true;
                else
                {
                    cargarInterfaz();
                }
            }
            catch (Exception)
            {
                lblRestriccionExisteID.Visible = true; ;
            }
            
        }

        //Metodo para cargarInterfaz
        private void cargarInterfaz()
        {
            //Realiza los cambios de ventana necesarios
            lblTitulo.Visible = true;
            tblDenuncias.Visible = false;
            lblElegirDenuncia.Visible = false;
            txtTitulo.Visible = true;
            txtIdDenuncia.Visible = false;
            lblRestriccionEstado.Visible = false;
            lblRestriccionExisteID.Visible = false;
            lblDescripcion.Visible = true;
            btnIniciarSolucion.Visible = false;
            txtDescripcion.Visible = true;
            lblFoto.Visible = true;
            fileUploadImage.Visible = true;
            btnCrearSolucion.Visible = true;
            lblAsterisco1.Visible = true;
            lblAsterisco2.Visible = true;
            lblAsterisco3.Visible = true;
        }

        //Evento al presionar el boton Crear Solucion
        protected void btnCrearSolucion_Click(object sender, EventArgs e)
        {
            //Cambios en la interfaz necesarios
            lblRestriccionDescripcion.Visible = false;
            lblRestriccionAgregarImagen.Visible = false;
            lblRestriccionFormatoImagen.Visible = false;
            lblRestriccionTitulo.Visible = false;
            //Obtener bytes de la foto
            HttpPostedFile postedFile = fileUploadImage.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);

            //Verificar los datos ingresados
            if (txtTitulo.Text == "") lblRestriccionTitulo.Visible = true;
            else if (txtDescripcion.Text == "") lblRestriccionDescripcion.Visible = true;
            else if (fileUploadImage.HasFile == false) lblRestriccionAgregarImagen.Visible = true;
            else if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
               fileExtension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                solucion.foto = bytes;

                //Obtener el id del Oficial
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    solucion.idUsuario = Int32.Parse(cookie["idUsuario"]);
                }

                //Asignacion de elementos restantes
                solucion.titulo = txtTitulo.Text;
                solucion.descripcion = txtDescripcion.Text;
                solucion.idDenuncia = Int32.Parse(hdfIdDenuncia.Value);
                solucion.registrarSolucion();
                Response.Redirect("AgregarHashtagSolucion.aspx", true);
            }
            else lblRestriccionFormatoImagen.Visible = true;
        }
    }
}