using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEnlaceDatos;

namespace Capa_Negocios_Cliente
{
    public class Solucion
    {
        private Manejador manejador = new Manejador();
        public int idDenuncia { get; set; }
        public string titulo { get; set; }
        public byte[] foto { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public int idUsuario { get; set; }
        public int idSolucion { get; set; }
        public string nuevoEstado { get; set; }
        public string hashtag { get; set; }

        public void registrarSolucion()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            try
            {
                listaParametros.Add(new Parametro("@titulo", titulo));
                listaParametros.Add(new Parametro("@foto", foto));
                listaParametros.Add(new Parametro("@descripcion", descripcion));
                listaParametros.Add(new Parametro("@idDenuncia", idDenuncia));
                listaParametros.Add(new Parametro("@idOficial", idUsuario));

                manejador.EjecutarPA("insertarSolucion", ref listaParametros);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void registroHashtag()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idOficial", idUsuario));
            listaParametros.Add(new Parametro("@nombreHashtag", hashtag));
            manejador.EjecutarPA("insertarHashtagSolucion", ref listaParametros);
        }

        public DataTable listadoSolucionJuez()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idJuez", idUsuario));
            return manejador.listado("consultarSolucionesJuez", listaParametros);
        }

        public DataTable solucionEspecificaJuez()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idSolucion", idSolucion));
            return manejador.listado("consultaSolucionJuez", listaParametros);
        }

        public void cambiarEstadoDenuncia()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idSolucion", idSolucion));
            listaParametros.Add(new Parametro("@nuevoEstado", nuevoEstado));
            listaParametros.Add(new Parametro("@idJuez", idUsuario));
            manejador.EjecutarPA("finalizarDenuncia", ref listaParametros);
        }

        public void cambiarEstadoSolucion()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idSolucion", idSolucion));
            manejador.EjecutarPA("cambiarEstadoSolucion", ref listaParametros);
        }
    }
}
