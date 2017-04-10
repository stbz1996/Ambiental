using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using Capa_Negocios_Cliente;

namespace Aplicacion_Web
{
    public partial class ConsultaDenunciasGuardian : System.Web.UI.Page
    {
        //Variable global necesaria
        private Denuncia denuncia = new Denuncia();
        
        //Evento al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Solicita al usuario
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                lblObtenerPuntos.Text = cookie["puntos"];
                denuncia.idUsuario = Int32.Parse(cookie["idUsuario"]);
                DataTable denuncias = denuncia.listadoDenunciasGuardian();     //Se crea una tabla con las denuncias del usuario

                //Ingresa los valores en la tabla
                for(int i = 0; i < denuncias.Rows.Count; i++)
                {
                    //Se crea una nueva fila y varias celdas
                    TableRow nuevaFila = new TableRow();
                    TableCell celda1 = new TableCell();
                    TableCell celda2 = new TableCell();
                    TableCell celda3 = new TableCell();
                    TableCell celda4 = new TableCell();
                    TableCell celda5 = new TableCell();
                    TableCell celda6 = new TableCell();
                    TableCell celda7 = new TableCell();

                    //Se les agrega informacion a las celdas 
                    celda1.Text = denuncias.Rows[i][0].ToString();
                    celda2.Text = denuncias.Rows[i][1].ToString();
                    celda3.Text = denuncias.Rows[i][2].ToString();
                    celda4.Text = denuncias.Rows[i][3].ToString();
                    celda5.Text = denuncias.Rows[i][4].ToString();
                    celda6.Text = denuncias.Rows[i][5].ToString();
                    celda7.Text = denuncias.Rows[i][6].ToString();

                    //Se agregan las celdas en la fila
                    nuevaFila.Cells.Add(celda1);
                    nuevaFila.Cells.Add(celda2);
                    nuevaFila.Cells.Add(celda3);
                    nuevaFila.Cells.Add(celda4);
                    nuevaFila.Cells.Add(celda5);
                    nuevaFila.Cells.Add(celda6);
                    nuevaFila.Cells.Add(celda7);

                    //Se agrega la fila en la tabla
                    tblDenuncias.Rows.Add(nuevaFila);
                }
            }
        }

        //Evento al presionar el boton ModificarDenuncia
        protected void btnModificarDenuncia_Click(object sender, EventArgs e)
        {
            lblRestriccionExisteID.Visible = false;
            lblRestriccionDenunciaDiferente.Visible = false;
            lblRestriccionEstado.Visible = false;
            try
            {
                //Se solicita informacion del usuario
                HttpCookie cookie = Request.Cookies["UserInfo"];
                int idUsuario;
                idUsuario = Int32.Parse(cookie["idUsuario"]);

                //Se obtiene la denuncia que quiere modificar el usuario
                hdfIdDenuncia.Value = txtIdDenuncia.Text;
                denuncia.idDenuncia = Int32.Parse(hdfIdDenuncia.Value);
                DataTable tableDenuncia = denuncia.denunciaEspecifica();

                //Se realizan validaciones
                if (idUsuario.ToString() != tableDenuncia.Rows[0][7].ToString()) lblRestriccionDenunciaDiferente.Visible = true;
                else if (tableDenuncia.Rows[0][8].ToString() != "Registrado") lblRestriccionEstado.Visible = true;
                else
                {
                    //Carga la ventana con los datos de la denuncia
                    cargarInterfaz();
                    txtTitulo.Text = tableDenuncia.Rows[0][0].ToString();
                    txtDescripcion.Text = tableDenuncia.Rows[0][1].ToString();
                }
            }
            catch (Exception)
            {
                lblRestriccionExisteID.Visible = true;
            }
        }

        //Metodo para cargar la interfaz
        private void cargarInterfaz()
        {
            //Se limpia la ventana y se agregan otros elementos
            lblConsultaDenuncia.Visible = false;
            lblModificaDenuncia.Visible = true;
            lblTitulo.Visible = true;
            tblDenuncias.Visible = false;
            txtIdDenuncia.Visible = false;
            btnModificarDenuncia.Visible = false;
            lblRestriccionDenunciaDiferente.Visible = false;
            lblRestriccionEstado.Visible = false;
            lblRestriccionExisteID.Visible = false;
            txtTitulo.Visible = true;
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            lblFoto.Visible = true;
            fileUploadImage.Visible = true;
            lblAvisoModificacion.Visible = true;
            btnModificarDenuncia2.Visible = true;

        }

        //Evento al presionar el boton ModificarDenuncia2
        protected void btnModificarDenuncia2_Click(object sender, EventArgs e)
        {
            //Se obtiene la denuncia a modificar
            denuncia.idDenuncia = Int32.Parse(hdfIdDenuncia.Value);
            DataTable tableDenuncia = denuncia.denunciaEspecifica();

            //Se solicita informacion del usuario
            HttpPostedFile postedFile = fileUploadImage.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            lblRestriccionTitulo.Visible = false;
            lblRestriccionFormatoFoto.Visible = false;

            //Verifica si el titulo esta vacio
            if (txtTitulo.Text == "")
            {
                lblRestriccionTitulo.Visible = true;
            }
            else
            {
                denuncia.titulo = txtTitulo.Text;
                denuncia.descripcion = txtDescripcion.Text;

                //Verifica si el archivo posee informacion
                if (fileUploadImage.HasFile == false)
                {
                    denuncia.foto = (byte[])tableDenuncia.Rows[0][6];
                    denuncia.actualizarDenuncia();
                    limpiarPantalla();
                    
                }

                //Verifica si el archivo no posee los formatos necesarios
                else if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".bmp" &&
                fileExtension.ToLower() != ".png")
                {
                    lblRestriccionFormatoFoto.Visible = true;
                }
                else
                {
                    //Se agrega la nueva foto
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    denuncia.foto = bytes;
                    denuncia.actualizarDenuncia();
                    limpiarPantalla();

                }
            }
        }

        //Metodo para limpiar la pantalla
        private void limpiarPantalla()
        {
            lblTitulo.Visible = false;
            lblAsterisco1.Visible = false;
            lblExitoModificarDenuncia.Visible = true;
            btnSalir.Visible = true;
            txtTitulo.Visible = false;
            lblRestriccionTitulo.Visible = false;
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;
            lblFoto.Visible = false;
            fileUploadImage.Visible = false;
            lblRestriccionFormatoFoto.Visible = false;
            lblAvisoModificacion.Visible = false;
            btnModificarDenuncia2.Visible = false;
        }

        //Evento al presionar el boton Salir
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeGuardian.aspx", true);
        }
    }
}