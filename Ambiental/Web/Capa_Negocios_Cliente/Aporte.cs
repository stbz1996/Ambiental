using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEnlaceDatos;

namespace Capa_Negocios_Cliente
{
    public class Aporte
    {
        private Manejador manejador = new Manejador();
        public DateTime fecha { get; set; }
        public byte[] foto { get; set; }
        public int valor { get; set; }
        public int idTipoAporte { get; set; }
        public int idUsuario { get; set; }

        public void registrarAporte()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            try
            {
                listaParametros.Add(new Parametro("@fecha", fecha));
                listaParametros.Add(new Parametro("@foto", foto));
                listaParametros.Add(new Parametro("@valor", valor));
                listaParametros.Add(new Parametro("@idTipoAporte", idTipoAporte));
                listaParametros.Add(new Parametro("@idUsuario", idUsuario));

                manejador.EjecutarPA("insertarAporte", ref listaParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //Probablemente se tenga que quitar
        public string recuperarRol()
        {
            string rol;
            List<Parametro> listaParametros = new List<Parametro>();

            try
            {
                listaParametros.Add(new Parametro("@cedula", idUsuario));
                //lista.Add(new Parametro("@Pass", this.contraseña));
                // retorno
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

        public DataTable listadoTipoAporte()
        {
            return manejador.listado("consultaTipoAporte", null);
        }
    }
}
