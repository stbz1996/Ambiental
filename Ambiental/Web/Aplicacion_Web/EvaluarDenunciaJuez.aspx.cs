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
    public partial class EvaluarDenunciaJuez : System.Web.UI.Page
    {
        //Variables globales necesarias
        private Denuncia denuncia = new Denuncia();
        private Direccion direccion = new Direccion();

        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            //Solicita el id del usuario
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                denuncia.idUsuario = Int32.Parse(cookie["idUsuario"]);
                lblObtenerPuntos.Text = cookie["puntos"];
            }

            //Variables locales necesarias
            DataTable denuncias = denuncia.listadoDenunciasJuez();
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

                //Se asignan los valores en las celdas correspondiente
                idDenuncia.Text = denuncias.Rows[i][0].ToString();
                titulo.Text = denuncias.Rows[i][1].ToString();
                fechaDenuncia = denuncias.Rows[i][2].ToString();
                fecha.Text = fechaDenuncia.Substring(0, 10);
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

                tblDenuncias.Rows.Add(nuevaFila);
                
            }
        }

        //Evento al presionar el boton Evaluar Denuncia
        protected void btnEvaluarDenuncia_Click(object sender, EventArgs e)
        {
            lblRestriccionEstado.Visible = false;
            lblRestriccionExisteID.Visible = false;
            lblRestriccionProvincia.Visible = false;
            
            try
            {
                //Solicitud del usuario
                HttpCookie cookie = Request.Cookies["UserInfo"];
                int idUsuario = Int32.Parse(cookie["idUsuario"]);
                direccion.idJuez = idUsuario;

                //Se obtiene la provincia del juez
                DataTable provincia = direccion.obtenerProvinciaJuez();

                //Se obtiene la denuncia que evalua el juez
                hdfIdDenuncia.Value = txtIdDenuncia.Text;               //Se almacena el idDenuncia
                denuncia.idDenuncia = Int32.Parse(hdfIdDenuncia.Value);
                DataTable tableDenuncia = denuncia.denunciaEspecifica();

                string newProvincia = provincia.Rows[0][0].ToString();

                //Verifica si la provincia del juez y la denuncia son diferentes
                if (provincia.Rows[0][0].ToString() != tableDenuncia.Rows[0][2].ToString()) lblRestriccionProvincia.Visible = true;

                //Verifica el estado de la denuncia
                else if (tableDenuncia.Rows[0][8].ToString() != "Registrado") lblRestriccionEstado.Visible = true;
                else
                {
                    //Limpia y carga la pagina
                    cargarInterfaz();
                    txtTitulo.Text = tableDenuncia.Rows[0][0].ToString();
                    txtDescripcion.Text = tableDenuncia.Rows[0][1].ToString();
                    txtProvincia.Text = tableDenuncia.Rows[0][2].ToString();
                    txtCanton.Text = tableDenuncia.Rows[0][3].ToString();
                    txtDistrito.Text = tableDenuncia.Rows[0][4].ToString();
                    txtDetalle.Text = tableDenuncia.Rows[0][5].ToString();
                    byte[] bytesFoto = (byte[])tableDenuncia.Rows[0][6];
                    string base64String = Convert.ToBase64String(bytesFoto, 0, bytesFoto.Length);
                    imgDenuncia.ImageUrl = "data:image/png;base64," + base64String;
                }
            }
            catch (Exception ex)
            {
                lblRestriccionExisteID.Visible = true;
            }
        }

        //Metodo para hacer cambios de interfaz
        protected void cargarInterfaz()
        {
            //Cambios necesarios de interfaz
            txtIdDenuncia.Visible = false;
            tblDenuncias.Visible = false;
            lblTitulo.Visible = true;
            txtTitulo.Visible = true;
            btnEvaluarDenuncia.Visible = false;
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            lblDireccion.Visible = true;
            lblProvincia.Visible = true;
            txtProvincia.Visible = true;
            lblCanton.Visible = true;
            txtCanton.Visible = true;
            lblDistrito.Visible = true;
            txtDistrito.Visible = true;
            lblDetalle.Visible = true;
            txtDetalle.Visible = true;
            lblFoto.Visible = true;
            imgDenuncia.Visible = true;
            lblEvaluacion.Visible = true;
            rdbDecision.Visible = true;
            btnTomarDecision.Visible = true;
            lblPedirDenuncia.Visible = false;
        }

        //Evento al presionar el boton TomarDecision
        protected void btnTomarDecision_Click(object sender, EventArgs e)
        {

            //Solicitud del usuario
            HttpCookie cookie = Request.Cookies["UserInfo"];
            denuncia.idUsuario = Int32.Parse(cookie["idUsuario"]);

            lblRestriccionOpcionEvaluacion.Visible = false;
            try
            {

                string decision = rdbDecision.SelectedItem.Text;        //Se obtiene la decision del juez
                denuncia.idDenuncia = Int32.Parse(hdfIdDenuncia.Value);

                //Verifica si escogió la opción Confirmar
                if (decision == "Confirmar")
                {
                    //Agrega elementos en la ventana
                    lblGradoSeveridad.Visible = true;
                    rdbGradoSeveridad.Visible = true;
                    btnGradoSeveridad.Visible = true;
                    rdbDecision.Enabled = false;
                    btnTomarDecision.Enabled = false;
                    
                }
                else if (decision == "Rechazar")
                {
                    //Se manda el estado a rechazado
                    denuncia.estado = "Rechazado";
                    denuncia.cambiarEstadoDenuncia();
                    limpiarPantalla();
                }
            }
            catch (Exception ex)
            {
                lblRestriccionOpcionEvaluacion.Visible = true;
            }
        }

        //Evento al presionar el boton GradoSeveridad
        protected void btnGradoSeveridad_Click(object sender, EventArgs e)
        {
            lblRestriccionOpcionGrado.Visible = false;

            try
            {
                //Se solicita informacion de usuario
                HttpCookie cookie = Request.Cookies["UserInfo"];
                denuncia.idUsuario = Int32.Parse(cookie["idUsuario"]);

                denuncia.idDenuncia = Int32.Parse(hdfIdDenuncia.Value);     //Se recupera el id de la denuncia
                denuncia.grado = rdbGradoSeveridad.SelectedItem.Text[0];    //Se obtiene el grado que puso el juez

                denuncia.estado = "En Proceso";

                //Se llaman a los metodos de la denuncia
                denuncia.cambiarEstadoDenuncia();       //Cambia el estado de la denuncia
                denuncia.agregarGradoSeveridad();       //Agrega la categoria en la denuncia
                limpiarPantalla();
            }
            catch(Exception ex)
            {
                lblRestriccionOpcionGrado.Visible = true;
            }
        }

        //Metodo para limpiar la ventana
        private void limpiarPantalla()
        {
            lblEvaluoTerminado.Visible = true;
            btnSalir.Visible = true;
            lblTitulo.Visible = false;
            txtTitulo.Visible = false;
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;
            lblDireccion.Visible = false;
            lblProvincia.Visible = false;
            txtProvincia.Visible = false;
            lblCanton.Visible = false;
            txtCanton.Visible = false;
            lblDistrito.Visible = false;
            txtDistrito.Visible = false;
            lblDetalle.Visible = false;
            txtDetalle.Visible = false;
            lblFoto.Visible = false;
            imgDenuncia.Visible = false;
            lblEvaluacion.Visible = false;
            rdbDecision.Visible = false;
            btnTomarDecision.Visible = false;
            lblGradoSeveridad.Visible = false;
            rdbGradoSeveridad.Visible = false;
            btnGradoSeveridad.Visible = false;

        }

        //Metodo al presionar el boton Salir
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeJuez.aspx", true);
        }
    }
}