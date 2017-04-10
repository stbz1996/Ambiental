using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaEnlaceDatos;


namespace CapaLogicaNegocio
{
    public class MetodosAdministrador
    {
        // Atributos para los Metodos
        private Manejador M = new Manejador();

        // Atributos
        public int cedula { get; set; }
        public String primerNombre { get; set; }
        public String segundoNombre { get; set; }
        public String primerApellido { get; set; }
        public String segundoApellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String username { get; set; }
        public String conraseña { get; set; }
        public int telefono { get; set; }
        public String email { get; set; }
        public String provincia { get; set; }
        public String canton { get; set; }
        public String distrito { get; set; }
        public String detalle { get; set; }
        public String mensaje { get; set; }

        // regitrar Autoridades en la BD
        public String registrarConsultante()
        {
            List<Parametro> lista = new List<Parametro>();
            String Mensaje = "";
            try
            {
                //Pasamos los parametros de entrada
                lista.Add(new Parametro("@cedula", this.cedula));
                lista.Add(new Parametro("@primerNombre", this.primerNombre));
                lista.Add(new Parametro("@segundoNombre", this.segundoNombre));
                lista.Add(new Parametro("@primerApellido", this.primerApellido));
                lista.Add(new Parametro("@segundoApellido", this.segundoApellido));
                lista.Add(new Parametro("@fechaNacimiento", this.fechaNacimiento));
                lista.Add(new Parametro("@username", this.username));
                lista.Add(new Parametro("@passw", this.conraseña));
                lista.Add(new Parametro("@telefono", this.telefono));
                lista.Add(new Parametro("@email", this.email));
                lista.Add(new Parametro("@provincia", this.provincia));
                lista.Add(new Parametro("@canton", this.canton));
                lista.Add(new Parametro("@distrito", this.distrito));
                lista.Add(new Parametro("@detalle", this.detalle));
                //Pasamos los datos de Salida
                lista.Add(new Parametro("@mensaje", SqlDbType.NVarChar, 100));
                // Ejecuta el procedimiento
                M.EjecutarPA("insertarConsultante", ref lista);
                // Atrapamos el parametro de respuesta
                Mensaje = lista[14].m_Valor.ToString();
            }
            catch (Exception ex){                
                throw ex;
            }
            return Mensaje;
         }
        public String registrarAdmine()
        {
            List<Parametro> lista = new List<Parametro>();
            String Mensaje = "";
            try
            {
                //Pasamos los parametros de entrada
                lista.Add(new Parametro("@cedula", this.cedula));
                lista.Add(new Parametro("@primerNombre", this.primerNombre));
                lista.Add(new Parametro("@segundoNombre", this.segundoNombre));
                lista.Add(new Parametro("@primerApellido", this.primerApellido));
                lista.Add(new Parametro("@segundoApellido", this.segundoApellido));
                lista.Add(new Parametro("@fechaNacimiento", this.fechaNacimiento));
                lista.Add(new Parametro("@username", this.username));
                lista.Add(new Parametro("@passw", this.conraseña));
                lista.Add(new Parametro("@telefono", this.telefono));
                lista.Add(new Parametro("@email", this.email));
                lista.Add(new Parametro("@provincia", this.provincia));
                lista.Add(new Parametro("@canton", this.canton));
                lista.Add(new Parametro("@distrito", this.distrito));
                lista.Add(new Parametro("@detalle", this.detalle));
                //Pasamos los datos de Salida
                lista.Add(new Parametro("@mensaje", SqlDbType.NVarChar, 100));
                // Ejecuta el procedimiento
                M.EjecutarPA("insertarAdministrador", ref lista);
                // Atrapamos el parametro de respuesta
                Mensaje = lista[14].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        

        // cargan los diferentes tipos de usuarios
        public DataTable cargarPersonas()
        {
            return M.Consulta("listadoPersonas", null);
        }
        public DataTable cargarGuardianes(){
            return M.Consulta("listadoGuardianes", null);
        }
        public DataTable cargarOficiales()
        {
            return M.Consulta("listadoOficiales", null);
        }
        public DataTable cargarJueces()
        {
            return M.Consulta("listadoJueces", null);
        }
        public DataTable cargarConsultantes()
        {
            return M.Consulta("listadoConsultantes", null);
        }
        public DataTable cargarAdministradores()
        {
            return M.Consulta("listadoAdministradores", null);
        }
        

        // Obtiene el tipo de rol de un usuario
        public String BuscarRol(String id){
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@cedula", Int64.Parse(id)));
            lista.Add(new Parametro("@retorno", SqlDbType.NVarChar, 20));
            M.EjecutarPA("buscarRolAdmin", ref lista);
            return lista[1].m_Valor.ToString(); 
        }

        // obtiene el estado de un usuario
        public String verEstado(String id)
        {
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@cedula", Int64.Parse(id)));
            lista.Add(new Parametro("@resultado", SqlDbType.NVarChar, 20));
            M.EjecutarPA("estaActivado", ref lista);
            return lista[1].m_Valor.ToString();
        }

        // Activa un usuario
        public void cambiarEstadoActivo(String id) {
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idUsuario", Int64.Parse(id)));
                lst.Add(new Parametro("@retorno", SqlDbType.NVarChar, 10));
                M.EjecutarPA("cambiarEstadoActivo", ref lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Desactiva un usuario
        public void cambiarEstadoDesactivo(String id)
        {
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idUsuario", Int64.Parse(id)));
                lst.Add(new Parametro("@retorno", SqlDbType.NVarChar, 10));
                M.EjecutarPA("cambiarEstadoDesactivo", ref lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Elimina autoridades
        public void eliminaConsultante(String id)
        {
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idConsultante", Int64.Parse(id)));
                lst.Add(new Parametro("@retorno", SqlDbType.NVarChar, 1));
                M.EjecutarPA("borrarConsultante", ref lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminaAdministrador(String id)
        {
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idAdministrador", Int64.Parse(id)));
                lst.Add(new Parametro("@retorno", SqlDbType.NVarChar, 1));
                M.EjecutarPA("borrarAdministrador", ref lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Inserta las actividades en bitacora
        public void insertarEnBitacora(DateTime fecha, String descripcion, int cedula)
        {
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@fecha", fecha));
                lst.Add(new Parametro("@descripcion", descripcion));
                lst.Add(new Parametro("@idQuienLaRealizó", cedula));

                lst.Add(new Parametro("@retorno", SqlDbType.NVarChar, 10));
                M.EjecutarPA("insertarEnBitacora", ref lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // retorna el username de un usuario o autoridad 
        public DataTable obtenerusername(int identificador)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@cedula", identificador));
                dt = M.Consulta("buscarUsername", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
