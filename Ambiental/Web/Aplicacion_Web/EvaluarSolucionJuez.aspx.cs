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
    public partial class EvaluarSolucionJuez : System.Web.UI.Page
    {
        //Variables globales necesarias
        private Solucion solucion = new Solucion();
        private List<string> listaIdSoluciones = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //Solicita el id del usuario
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                solucion.idUsuario = Int32.Parse(cookie["idUsuario"]);
                lblObtenerPuntos.Text = cookie["puntos"];
            }

            //Variables locales necesarias
            DataTable soluciones = solucion.listadoSolucionJuez();
            string fechaDenuncia;

            //Cargar los elementos en una tabla
            for (int i = 0; i < soluciones.Rows.Count; i++)
            {
                //Se crea una nueva fila y varias celdas
                TableRow nuevaFila = new TableRow();
                TableCell idSolucion = new TableCell();
                TableCell titulo = new TableCell();
                TableCell fecha = new TableCell();
                    
                //Se asignan los valores en las celdas correspondiente
                idSolucion.Text = soluciones.Rows[i][0].ToString();
                listaIdSoluciones.Add(idSolucion.Text);
                titulo.Text = soluciones.Rows[i][1].ToString();
                fechaDenuncia = soluciones.Rows[i][2].ToString();
                fecha.Text = fechaDenuncia.Substring(0, 10);

                //Se agregan las celdas en la fila
                nuevaFila.Cells.Add(idSolucion);
                nuevaFila.Cells.Add(titulo);
                nuevaFila.Cells.Add(fecha);
                  
                //Se agrega la fila en la tabla
                tblSoluciones.Rows.Add(nuevaFila);

            }
        }

        //Evento 
        protected void btnEvaluarSolucion_Click(object sender, EventArgs e)
        {
            
            lblRestriccionIdSolucion.Visible = false;           //Se hace invisible un label

            //Verifica si 
            if (listaIdSoluciones.Contains(txtIdSolucion.Text))
            {
                cargarInterfaz();

                hdfIdSolucion.Value = txtIdSolucion.Text;
                solucion.idSolucion = Int32.Parse(hdfIdSolucion.Value);

                DataTable tableSolucion = solucion.solucionEspecificaJuez();
                txtTitulo.Text = tableSolucion.Rows[0][0].ToString();
                txtDescripcion.Text = tableSolucion.Rows[0][1].ToString();
                txtFecha.Text = tableSolucion.Rows[0][2].ToString().Substring(0, 10);
                byte[] bytesFoto = (byte[])tableSolucion.Rows[0][3];
                string base64String = Convert.ToBase64String(bytesFoto, 0, bytesFoto.Length);
                imgSolucion.ImageUrl = "data:image/png;base64," + base64String;
            }
            else
            {
                lblRestriccionIdSolucion.Visible = true;
            }
        }

        protected void cargarInterfaz()
        {
            tblSoluciones.Visible = false;
            lblElegirSolucion.Visible = false;
            lblTitulo.Visible = true;
            txtIdSolucion.Visible = false;
            txtTitulo.Visible = true;
            btnEvaluarSolucion.Visible = false;
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            lblFecha.Visible = true;
            txtFecha.Visible = true;
            lblFoto.Visible = true;
            imgSolucion.Visible = true;
            lblEvaluacion.Visible = true;
            rdbDecision.Visible = true;
            btnTomarDecision.Visible = true;
        }

        protected void btnTomarDecision_Click(object sender, EventArgs e)
        {
            lblRestriccionOpcion.Visible = false;
            try
            {

                string decision = rdbDecision.SelectedItem.Text;
                solucion.idSolucion = Int32.Parse(txtIdSolucion.Text);

                if (decision == "Confirmar")
                {
                    HttpCookie cookie = Request.Cookies["UserInfo"];
                    solucion.idUsuario = Int32.Parse(cookie["idUsuario"]);
                    solucion.nuevoEstado = "Finalizada";
                    solucion.cambiarEstadoDenuncia();
                }
                limpiarPantalla();
                solucion.cambiarEstadoSolucion();
            }catch(Exception ex)
            {
                lblRestriccionOpcion.Visible = true;
            }
        }
        
        private void limpiarPantalla()
        {
            lblTitulo.Visible = false;
            lblEvaluoTerminado.Visible = true;
            txtTitulo.Visible = false;
            btnSalir.Visible = true;
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;
            lblFecha.Visible = false;
            txtFecha.Visible = false;
            lblFoto.Visible = false;
            imgSolucion.Visible = false;
            lblEvaluacion.Visible = false;
            rdbDecision.Visible = false;
            btnTomarDecision.Visible = false;
        }

        protected void btnSalir_Click1(object sender, EventArgs e)
        {
            Response.Redirect("HomeJuez.aspx", true);
        }
    }
}