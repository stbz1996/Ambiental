using Capa_Negocios_Cliente;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace Aplicacion_Web
{
    public partial class ModificarDatosUsuario : System.Web.UI.Page
    {
        //Variables globales necesarias
        private Usuario usuario = new Usuario();
        private Direccion direccion = new Direccion();

        //Evento al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se recupera la informacion de la pagina
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    usuario.idUsuario = Int32.Parse(cookie["idUsuario"]);
                }
                int posPersona = 0;
                DataTable informacionPersona = usuario.informacionPersona();

                //Llenado de textbox
                txtCedula.Text = informacionPersona.Rows[posPersona][0].ToString();
                txtPrimerNombre.Text = informacionPersona.Rows[posPersona][1].ToString();
                txtSegundoNombre.Text = informacionPersona.Rows[posPersona][2].ToString();
                txtPrimerApellido.Text = informacionPersona.Rows[posPersona][3].ToString();
                txtSegundoApellido.Text = informacionPersona.Rows[posPersona][4].ToString();
                txtEmail.Text = informacionPersona.Rows[posPersona][5].ToString();
                txtTelefono.Text = informacionPersona.Rows[posPersona][6].ToString();
                txtProvincia.Text = informacionPersona.Rows[posPersona][7].ToString();
                txtCanton.Text = informacionPersona.Rows[posPersona][8].ToString();
                txtDistrito.Text = informacionPersona.Rows[posPersona][9].ToString();
                txtDetalle.Text = informacionPersona.Rows[posPersona][10].ToString();
                txtFechaNacimiento.Text = informacionPersona.Rows[posPersona][11].ToString();
                txtUsername.Text = informacionPersona.Rows[posPersona][12].ToString();
                txtRol.Text = usuario.recuperarRol();
            }
        }

        //Evento al presionar el boton Salir
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            usuario.idUsuario = Int32.Parse(txtCedula.Text);
            if (usuario.recuperarRol() == "Guardian") Response.Redirect("HomeGuardian.aspx");
            else if (usuario.recuperarRol() == "Oficial") Response.Redirect("HomeOficial.aspx");
            else if (usuario.recuperarRol() == "Juez") Response.Redirect("HomeJuez.aspx");
            
        }

        //Evento al presionar el boton ModificarUsuario
        protected void btnModificarUsuario1_Click(object sender, EventArgs e)
        {
            habilitarElementos();       //Los textbox se habilitan para modificar

            //Se agrega el calendario
            calendarFecha.TodaysDate = new DateTime(2011, 1, 1);
            for (int i = 1900; i <= DateTime.Now.Year - 5; i++)
            {
                ddlAnio.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
            }

            //Insertar las provincias
            DataTable tableProvincia = direccion.listadoProvincias();
            DataRow row;
            for (int i = 0; i < 7; i++)
            {
                row = tableProvincia.Rows[i];
                ddlProvincia.Items.Add(new ListItem(row["nombreProvincia"].ToString(), (i + 1).ToString()));
            }

            btnModificarUsuario1.Visible = false;
            btnModificarUsuario2.Visible = true;
        }

        //Metodo para habilitar los textbox
        private void habilitarElementos()
        {
            txtPrimerNombre.Enabled = true;
            txtSegundoNombre.Enabled = true;
            txtPrimerApellido.Enabled = true;
            txtSegundoApellido.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtProvincia.Visible = false;
            ddlProvincia.Visible = true;
            btnActualizarCanton.Visible = true;
            txtCanton.Visible = false;
            ddlCanton.Visible = true;
            btnActualizarDistrito.Visible = true;
            txtDistrito.Visible = false;
            ddlDistrito.Visible = true;
            txtDetalle.Enabled = true;
            txtFechaNacimiento.Visible = false;
            ddlAnio.Visible = true;
            btnActualizarFecha.Visible = true;
            calendarFecha.Visible = true;
            txtUsername.Enabled = true;
            lblDecision.Visible = true;
            lblPreviaInformacion.Visible = true;
            lblAsterisco1.Visible = true;
            lblAsterisco2.Visible = true;
            lblAsterisco3.Visible = true;
            lblAsterisco4.Visible = true;
            lblAsterisco5.Visible = true;
            lblAsterisco6.Visible = true;
            lblAsterisco7.Visible = true;
            lblAsterisco8.Visible = true;
            lblAsterisco9.Visible = true;
        }

        //Evento al presionar el boton actualizar fecha
        protected void btnActualizarFecha_Click(object sender, EventArgs e)
        {
            string anio = ddlAnio.SelectedItem.Text;                            //Obtenemos el año que elija el usuario
            calendarFecha.TodaysDate = new DateTime(Int32.Parse(anio), 1, 1);   //Actualiza el calendario

        }

        //Evento al presionar el boton ActualizarCanton
        protected void btnActualizarCanton_Click(object sender, EventArgs e)
        {
            direccion.nombreProvincia = ddlProvincia.SelectedItem.Text;   //Obtenemos el id de la provincia seleccionada  
            DataTable tableCanton = direccion.listadoCanton();                 //Obtenemos los cantones de la provincia correspondiente
            DataRow row;
            ddlCanton.Items.Clear();

            //Agrega los cantones al dropdownlist nuevo
            for (int i = 0; i < tableCanton.Rows.Count; i++)
            {
                row = tableCanton.Rows[i];
                ddlCanton.Items.Add(new ListItem(row["nombreCanton"].ToString(), (i + 1).ToString()));

            }
        }

        //Evento al presionar el boton ActualizarDistrito
        protected void btnActualizarDistrito_Click(object sender, EventArgs e)
        {
            direccion.nombreCanton = ddlCanton.SelectedItem.Text;       //Obtenemos el id del canton seleccionado
            DataTable tableDistrito = direccion.listadoDistrito();           //Obtenemos los distritos del canton correspondiente
            DataRow row;
            ddlDistrito.Items.Clear();

            //Agrega los distritos al dropdownlist nuevo
            for (int i = 0; i < tableDistrito.Rows.Count; i++)
            {
                row = tableDistrito.Rows[i];
                ddlDistrito.Items.Add(new ListItem(row["nombreDistrito"].ToString(), (i + 1).ToString()));
            }
        }

        //Evento al presionar l boton ModificarUsuario2
        protected void btnModificarUsuario2_Click(object sender, EventArgs e)
        {
            lblRestriccionNombre.Visible = false;
            lblRestriccionApellido.Visible = false;
            lblRestriccionEmail.Visible = false;
            lblRestriccionTelefono.Visible = false;
            lblRestriccionUsername.Visible = false;
            lblError.Visible = false;

            try
            {
                //Valida si los textbox estan vacios
                if (txtPrimerNombre.Text == "") lblRestriccionNombre.Visible = true;
                else if (txtPrimerApellido.Text == "") lblRestriccionApellido.Visible = true;
                else if (txtEmail.Text == "" || !validarCorreo()) lblRestriccionEmail.Visible = true;
                else if (txtTelefono.Text == "" || txtTelefono.Text.Length != 8) lblRestriccionTelefono.Visible = true;
                else if (txtUsername.Text == "") lblRestriccionUsername.Visible = true;
                else
                {
                    //Revisa si los dropdownlist estan vacíos
                    if(ddlDistrito.Items.Count != 0)
                    {
                        usuario.provincia = ddlProvincia.SelectedItem.Text;
                        usuario.canton = ddlCanton.SelectedItem.Text;
                        usuario.distrito = ddlDistrito.SelectedItem.Text;
                    }
                    else
                    {
                        usuario.provincia = txtProvincia.Text;
                        usuario.canton = txtCanton.Text;
                        usuario.distrito = txtDistrito.Text;
                    }

                    //Verifica si la fecha se selecciono
                    if (calendarFecha.SelectedDate.Date != DateTime.MinValue)
                        usuario.fechaNacimiento = calendarFecha.SelectedDate;
                    else
                    {
                        usuario.fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                    }

                    //Datos restantes
                    usuario.idUsuario = Int32.Parse(txtCedula.Text);
                    usuario.primerNombre = txtPrimerNombre.Text;
                    usuario.segundoNombre = txtSegundoNombre.Text;
                    usuario.primerApellido = txtPrimerApellido.Text;
                    usuario.segundoApellido = txtSegundoApellido.Text;
                    usuario.email = txtEmail.Text;
                    usuario.telefono = Int32.Parse(txtTelefono.Text);
                    usuario.detalle = txtDetalle.Text;
                    usuario.username = txtUsername.Text;
                    usuario.actualizarInformacion();
                }
                //Verifica el rol de la persona
                if (txtRol.Text == "Guardian") Response.Redirect("HomeGuardian.aspx");
                else if (txtRol.Text == "Oficial") Response.Redirect("HomeOficial.aspx");
                else if (txtRol.Text == "Juez") Response.Redirect("HomeJuez.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Metodo para validar el correo
        public bool validarCorreo()
        {
            return Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}