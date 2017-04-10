using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using Capa_Negocios_Cliente;

namespace Aplicacion_Web
{
    public partial class CrearUsuario : System.Web.UI.Page
    {

        //Variables globales necesarias
        private Usuario usuario = new Usuario();
        private Direccion direccion = new Direccion();

        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se cargan los posibles años
                calendarFecha.TodaysDate = new DateTime(2011, 1, 1);
                for (int i = 1900; i <= DateTime.Now.Year-5; i++)
                {
                    ddlAnio.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
                }

                //Se cargan las provincias
                DataTable tableProvincia = direccion.listadoProvincias();
                DataRow row;
                for (int i = 0; i < 7; i++)
                {
                    row = tableProvincia.Rows[i];
                    ddlProvincia.Items.Add(new ListItem(row["nombreProvincia"].ToString(), (i+1).ToString()));
                }
            }
        }

        //Evento al presionar el boton Actualizar Fecha
        protected void btnActualizarFecha_Click(object sender, EventArgs e)
        {
            
            string anio = ddlAnio.SelectedItem.Text;                            //Obtenemos el año que elija el usuario
            calendarFecha.TodaysDate = new DateTime(Int32.Parse(anio), 1, 1);   //Actualiza el calendario

        }

        //Evento al presionar el boton Actualizar Canton
        protected void btnActualizarCanton_Click(object sender, EventArgs e)
        {
            direccion.nombreProvincia = ddlProvincia.SelectedItem.Text;   //Obtenemos el id de la provincia seleccionada  
            DataTable tableCanton = direccion.listadoCanton();            //Obtenemos los cantones de la provincia correspondiente
            DataRow row;
            ddlCanton.Items.Clear();

            //Agrega los cantones al dropdownlist correspondiente
            for(int i = 0; i < tableCanton.Rows.Count; i++)
            {
                row = tableCanton.Rows[i];
                ddlCanton.Items.Add(new ListItem(row["nombreCanton"].ToString(), (i+1).ToString()));

            }
        }

        //Evento al presionar el boton Actualizar Distrito
        protected void btnActualizarDistrito_Click(object sender, EventArgs e)
        {
            direccion.nombreCanton = ddlCanton.SelectedItem.Text;       //Obtenemos el id del canton seleccionado
            DataTable tableDistrito = direccion.listadoDistrito();      //Obtenemos los distritos del canton correspondiente
            DataRow row;
            ddlDistrito.Items.Clear();

            //Agrega los distritos al dropdownlist correspondiente
            for(int i = 0; i < tableDistrito.Rows.Count; i++)
            {
                row = tableDistrito.Rows[i];
                ddlDistrito.Items.Add(new ListItem(row["nombreDistrito"].ToString(), (i+1).ToString()));
            }
        }

        //Evento al presionar el boton Crear Usuario
        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            //Cambios de la interfaz necesarios
            lblValidaCedula.Visible = false;
            lblRestriccionCedula.Visible = false;
            lblValidaPrimerNombre.Visible = false;
            lblValidaPrimerApellido.Visible = false;
            lblValidaEmail.Visible = false;
            lblRestriccionCorreo.Visible = false;
            lblValidaTelefono.Visible = false;
            lblRestriccionTelefono.Visible = false;
            lblValidaDireccion.Visible = false;
            lblValidaFechaNacimiento.Visible = false;
            lblValidaUsername.Visible = false;
            lblValidaContrasenia.Visible = false;
            lblValidaRol.Visible = false;
            lblDatosIncorrectos.Visible = false;

            //Validaciones necesarias
            if (txtCedula.Text == "") lblValidaCedula.Visible = true;
            else if (txtCedula.Text.Length != 9) lblRestriccionCedula.Visible = true;
            else if (txtPrimerNombre.Text == "") lblValidaPrimerNombre.Visible = true;
            else if (txtPrimerApellido.Text == "") lblValidaPrimerApellido.Visible = true;
            else if (txtEmail.Text == "") lblValidaEmail.Visible = true;
            else if (!validarCorreo()) lblRestriccionCorreo.Visible = true;
            else if (txtTelefono.Text == "") lblValidaTelefono.Visible = true;
            else if (txtTelefono.Text.Length != 8) lblRestriccionTelefono.Visible = true;
            else if ((ddlCanton.Items.Count == 0) || (ddlDistrito.Items.Count == 0)) lblValidaDireccion.Visible = true;
            else if (calendarFecha.SelectedDate.Date == DateTime.MinValue) lblValidaFechaNacimiento.Visible = true;
            else if (txtUsername.Text == "") lblValidaUsername.Visible = true;
            else if (txtContrasenia.Text == "") lblValidaContrasenia.Visible = true;
            else if (rdbRol.SelectedValue == "") lblValidaRol.Visible = true;
            else
            {
                try
                {
                    //Asignacion de datos al usuario
                    usuario.cedula = Int32.Parse(txtCedula.Text);
                    usuario.primerNombre = txtPrimerNombre.Text;
                    usuario.segundoNombre = txtSegundoNombre.Text;
                    usuario.primerApellido = txtPrimerApellido.Text;
                    usuario.segundoApellido = txtSegundoApellido.Text;
                    usuario.fechaNacimiento = calendarFecha.SelectedDate;
                    usuario.username = txtUsername.Text;
                    usuario.password = txtContrasenia.Text;
                    usuario.telefono = Int32.Parse(txtTelefono.Text);
                    usuario.email = txtEmail.Text;
                    usuario.provincia = ddlProvincia.SelectedItem.Text;
                    usuario.canton = ddlCanton.SelectedItem.Text;
                    usuario.distrito = ddlDistrito.SelectedItem.Text;
                    usuario.detalle = txtDetalle.Text;
                    usuario.tipoRol = rdbRol.SelectedValue;

                    usuario.registrarUsuario();
                    Response.Redirect("Login.aspx", true);

                }
                catch (Exception ex)
                {

                    lblDatosIncorrectos.Visible = true;
                }
            } 
        }

        //Metodo que valida el correo
        public bool validarCorreo()
        {
            return Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        //Evento al presionar el Button1 (Salida)
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }

        
    }
}