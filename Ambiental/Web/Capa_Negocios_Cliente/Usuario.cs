using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEnlaceDatos;

namespace Capa_Negocios_Cliente
{
    public class Usuario
    {
        private Manejador manejador = new Manejador();

        public int cedula { get; set; }
        public int idUsuario { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string detalle { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string tipoRol { get; set; }

        public string registrarUsuario()
        {
            string mensaje = "";
            List<Parametro> listaParametros = new List<Parametro>();

            try
            {
                listaParametros.Add(new Parametro("@cedula", cedula));
                listaParametros.Add(new Parametro("@primerNombre", primerNombre));
                listaParametros.Add(new Parametro("@segundoNombre", segundoNombre));
                listaParametros.Add(new Parametro("@primerApellido", primerApellido));
                listaParametros.Add(new Parametro("@segundoApellido", segundoApellido));
                listaParametros.Add(new Parametro("@fechaNacimiento", fechaNacimiento));
                listaParametros.Add(new Parametro("@username", username));
                listaParametros.Add(new Parametro("@passw", password));
                listaParametros.Add(new Parametro("@telefono", telefono));
                listaParametros.Add(new Parametro("@email", email));
                listaParametros.Add(new Parametro("@provincia", provincia));
                listaParametros.Add(new Parametro("@canton", canton));
                listaParametros.Add(new Parametro("@distrito", distrito));
                listaParametros.Add(new Parametro("@detalle", detalle));

                listaParametros.Add(new Parametro("@mensaje", SqlDbType.NVarChar, 100));

                if (tipoRol == "Guardian") manejador.EjecutarPA("insertarGuardian", ref listaParametros);
                else if (tipoRol == "Oficial") manejador.EjecutarPA("insertarOficial", ref listaParametros);
                else if (tipoRol == "Juez") manejador.EjecutarPA("insertarJuez", ref listaParametros);
                mensaje = listaParametros[14].ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return mensaje;
        }

        public DataTable informacionPersona()
        {
            List<Parametro> persona = new List<Parametro>();
            persona.Add(new Parametro("@idUsuario", idUsuario));
            return manejador.listado("consultaPersona", persona);
        }
        public string recuperarRol()
        {
            string rol;
            List<Parametro> listaParametros = new List<Parametro>();

            try
            {
                listaParametros.Add(new Parametro("@cedula", idUsuario));
                listaParametros.Add(new Parametro("@retorno", SqlDbType.NVarChar, 20));

                // Ejecuta el procedimiento
                manejador.EjecutarPA("buscarRolAdmin", ref listaParametros);

                // Atrapamos el parametro de respuesta
                rol = listaParametros[1].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            return rol;
        }
        public void actualizarInformacion()
        {
            List<Parametro> listaParametros = new List<Parametro>();

            listaParametros.Add(new Parametro("@idUsuario", idUsuario));
            listaParametros.Add(new Parametro("@primerNombre", primerNombre));
            listaParametros.Add(new Parametro("@segundoNombre", segundoNombre));
            listaParametros.Add(new Parametro("@primerApellido", primerApellido));
            listaParametros.Add(new Parametro("@segundoApellido", segundoApellido));
            listaParametros.Add(new Parametro("@email", email));
            listaParametros.Add(new Parametro("@telefono", telefono));
            listaParametros.Add(new Parametro("@provincia", provincia));
            listaParametros.Add(new Parametro("@canton", canton));
            listaParametros.Add(new Parametro("@distrito", distrito));
            listaParametros.Add(new Parametro("@detalle", detalle));
            listaParametros.Add(new Parametro("@fechaNacimiento", fechaNacimiento));
            listaParametros.Add(new Parametro("@username", username));
            manejador.EjecutarPA("cambiarDatosUsuario", ref listaParametros);
        }


    }
}
