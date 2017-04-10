using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class crearAutoridades : Form
    {
        String id;
        private MetodosAdministrador amd = new MetodosAdministrador();
        private DatosDireccion dir = new DatosDireccion();
        DataTable dt;

        public crearAutoridades(String id){
            this.id = id;
            InitializeComponent();
            cargarProvincias();
            rolAdditems();
        }
        public void crearConsultante(){
            try{
                amd.cedula = Int32.Parse(pcedula.Text);
                amd.primerNombre = pprimernombre.Text;
                amd.segundoNombre = psegundonombre.Text;
                amd.primerApellido = pprimerapellido.Text;
                amd.segundoApellido = psegundoapellido.Text;
                amd.fechaNacimiento = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
                amd.username = pusername.Text;
                amd.conraseña = pcontrasena.Text;
                amd.telefono = Int32.Parse(telefono.Text);
                amd.email = pemail.Text;
                amd.provincia = Provincia.SelectedItem.ToString();
                amd.canton = canton.SelectedItem.ToString();
                amd.distrito = distritos.SelectedItem.ToString();
                amd.detalle = pdetalle.Text;
                String msj = amd.registrarConsultante();
                int idX = Int32.Parse(this.id);
                DateTime fechaX = DateTime.Now;

                if (msj == "no registrado"){
                    amd.insertarEnBitacora(fechaX, "Intento registrar un Consultante", idX);
                    MessageBox.Show("Nombre de usuario o cédula ya exixte", "Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else{
                    amd.insertarEnBitacora(fechaX, "Registro a " + pusername.Text + " como Consultante desde el BackOffice", idX);
                    MessageBox.Show("Registrado correctamente", "Completo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
   
            }
            catch(Exception e){
                MessageBox.Show("Debe colocar los datos correctamente", "Incompleto",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void crearAdministrador()
        {
            try
            {
                /* crea autoridad */
                amd.cedula = Int32.Parse(pcedula.Text);
                amd.primerNombre = pprimernombre.Text;
                amd.segundoNombre = psegundonombre.Text;
                amd.primerApellido = pprimerapellido.Text;
                amd.segundoApellido = psegundoapellido.Text;
                amd.fechaNacimiento = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));
                amd.username = pusername.Text;
                amd.conraseña = pcontrasena.Text;
                amd.telefono = Int32.Parse(telefono.Text);
                amd.email = pemail.Text;
                amd.provincia = Provincia.SelectedItem.ToString();
                amd.canton = canton.SelectedItem.ToString();
                amd.distrito = distritos.SelectedItem.ToString();
                amd.detalle = pdetalle.Text;
                String msj = amd.registrarAdmine();
    
                /* aqui se lama lo de bitacora */
                int idX = Int32.Parse(this.id);
                DateTime fechaX = DateTime.Now;

                if (msj == "no registrado")
                {
                    amd.insertarEnBitacora(fechaX, "Intento registrar un Administrador", idX);
                    MessageBox.Show("Nombre de usuario o cédula ya exixte", "Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    amd.insertarEnBitacora(fechaX, "Registro a " + pusername.Text + " como administrador desde el BackOffice", idX);
                    MessageBox.Show("Registrado correctamente", "Completo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Debe colocar los datos correctamente", "Incompleto",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rolAdditems()
        {
            rol.Items.Add("Administrador");
            rol.Items.Add("Consultante");
        }

        public void cargarProvincias()
        {
            dt = dir.cargarProvincias();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Provincia.Items.Add(dt.Rows[i][0].ToString());
            }

        }

        public void cargarCantoness()
        {
            dt = dir.cargarCantones(Provincia.SelectedItem.ToString());           
            for (int i = 0; i < dt.Rows.Count; i++){
                canton.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        public void cargarDistritos()
        {
            dt = dir.cargarDistritos(canton.SelectedItem.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                distritos.Items.Add(dt.Rows[i][0].ToString());
            }
        }



        private void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            canton.Items.Clear();
            distritos.Items.Clear();
            canton.Text = "Canton";
            distritos.Text = "Distrito";
            cargarCantoness();
        }

        private void canton_SelectedIndexChanged(object sender, EventArgs e)
        {
            distritos.Items.Clear();
            distritos.Text = "Distrito";
            cargarDistritos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminMejorado ventanaAdmin = new AdminMejorado(id);
            ventanaAdmin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verificarDatosInterfaz();
        }

        private Boolean verificarDatosInterfaz() {
            if (pcedula.Text == "")
            {
                MessageBox.Show("Debe digitar la cédula", "Incompleto",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                return true;
            }
            if (pcedula.Text.Length != 9)
            {
                MessageBox.Show("La cédula debe tener 9 digitos", "Incompleto",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                return true;
            }
            if (pcontrasena.Text != "")
            {
                try
                {
                    int ced = Int32.Parse(pcedula.Text);
                }
                catch (Exception e)
                {
                    MessageBox.Show("La cédula solo debe contener caracteres numéricos", "Intente de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }
            if (pprimernombre.Text == ""){
                MessageBox.Show("Debe digitar el primer nombre", "Incompleto",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                return true;
            }
            if (pprimerapellido.Text == ""){
                MessageBox.Show("Debe digitar el primer apellido", "Incompleto",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                return true;
            }

            if (pcontrasena.Text == "" || repita.Text == "")
            {
                MessageBox.Show("Los espacios de contraseñas no pueden estar vacios", "Intente de nuevo",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                return true;
            }

                if (pcontrasena.Text != "" && repita.Text != "")
            {
                if (pcontrasena.Text != repita.Text)
                {
                    MessageBox.Show("Las contraseñas no son iguales", "Intente de nuevo",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                    return true;
                }
            }

            if (telefono.Text.Length != 8)
            {
                MessageBox.Show("El teléfono debe tener solo 8 caracteres", "Intente de nuevo",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true;
            }

            if (telefono.Text != "")
            {
                try
                {
                    int tel = Int32.Parse(telefono.Text);
                }
                catch (Exception w){
                    MessageBox.Show("El teléfono solo debe contener caracteres numéricos", "Intente de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }
            
            if (true) {
                try
                {
                    Provincia.SelectedItem.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Debes seleccionar una Provincia", "Intente de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }
            if (true)
            {
                try
                {
                    canton.SelectedItem.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Debes seleccionar un Canton", "Intente de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }
            if (true)
            {
                try
                {
                    distritos.SelectedItem.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Debes seleccionar un Distrito", "Intente de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }
            if (true)
            {
                try
                {
                    rol.SelectedItem.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Debes seleccionar el Rol de el nuevo usuario", "Intente de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }
    
            if (true)
            {
                String sFormato;
                String seMailAComprobar = pemail.Text;
                sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(seMailAComprobar, sFormato))
                {
                    if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                    {}
                    else
                    {
                        MessageBox.Show("El correo no tiene el formato correcto", "Incompleto",
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("El correo no tiene el formato correcto", "Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }


            if (true)
            {
                DateTime x = Convert.ToDateTime(fecha.Value.Date.ToString("dd/MM/yyyy"));

                if (x.Year >= DateTime.Now.Year || x.Year < 1900)
                {
                    MessageBox.Show("La fecha de nacimiento es incorrecta", "Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
            }

            if (true){
                try
                {
                    if(rol.SelectedItem.ToString() == "Administrador")
                    {
                        crearAdministrador();                       
                    }
                    else
                    {
                        crearConsultante();
                        
                    }                    
                }
                catch (Exception err)
                {
                    MessageBox.Show("Debe colocar los datos en el formato correcto", "Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    throw err;
                }

            }
            return true;
        }

        private void limpiar()
        {
            pcedula.Clear();
            pprimernombre.Clear();
            pprimerapellido.Clear();
            psegundonombre.Clear();
            psegundoapellido.Clear();
            pcontrasena.Clear();
            repita.Clear();
            telefono.Clear();
            pusername.Clear();
            pemail.Clear();
            distritos.Text = "Distrito";
            Provincia.Items.Clear();
            canton.Items.Clear();
            distritos.Items.Clear();
            rol.Items.Clear();
            rolAdditems();
            cargarProvincias();
            canton.Text = "Canton";
            Provincia.Text = "Provincia";
            rol.Text = "Rol";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

    }
}
