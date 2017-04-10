using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEnlaceDatos;

namespace Capa_Negocios_Cliente
{
    public class Denuncia
    {
        private Manejador manejador = new Manejador();
        public string titulo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        //Cuando se envía siempre pasa a estado 'Registrado'
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        public int idUsuario { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string detalle { get; set; }
        public string hashtag { get; set; }
        public int idDenuncia { get; set; }
        public string estado { get; set; }
        public char grado { get; set; }

        public string registroDenuncia()
        {
            string mensaje = "";
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@titulo", titulo));
            listaParametros.Add(new Parametro("@latitud", latitud));
            listaParametros.Add(new Parametro("@longitud", longitud));
            listaParametros.Add(new Parametro("@descripcion", descripcion));
            listaParametros.Add(new Parametro("@foto", foto));
            listaParametros.Add(new Parametro("@idGuardian", idUsuario));
            listaParametros.Add(new Parametro("@provincia", provincia));
            listaParametros.Add(new Parametro("@canton", canton));
            listaParametros.Add(new Parametro("@distrito", distrito));
            listaParametros.Add(new Parametro("@detalle", detalle));
            manejador.EjecutarPA("insertarDenuncia", ref listaParametros);

            return mensaje;
        }
        public void registroHashtag()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idGuardian", idUsuario));
            listaParametros.Add(new Parametro("@nombreHashtag", hashtag));
            manejador.EjecutarPA("insertarHashtagDenuncia", ref listaParametros);

        }

        public DataTable listadoDenunciasGuardian()
        {
            List<Parametro> listaParametro = new List<Parametro>();
            listaParametro.Add(new Parametro("@idGuardian", idUsuario));
            return manejador.listado("consultaDenunciasGuardian", listaParametro);
        }

        public DataTable listadoDenunciasOficial()
        {
            return manejador.listado("consultaDenunciasOficial", null);
        }

        public DataTable listadoDenunciasJuez()
        {
            List<Parametro> listaParametro = new List<Parametro>();
            listaParametro.Add(new Parametro("@idJuez", idUsuario));
            return manejador.listado("consultaDenunciasJuez", listaParametro);
        }

        public DataTable denunciaEspecifica()
        {
            List<Parametro> listaParametro = new List<Parametro>();
            listaParametro.Add(new Parametro("@idDenuncia", idDenuncia));
            return manejador.listado("consultaDenunciaEspecifica", listaParametro);
        }

        //TODO: Se debe agregar el id del juez que realiza el cambio
        public void cambiarEstadoDenuncia()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idDenuncia", idDenuncia));
            listaParametros.Add(new Parametro("@nuevoEstado", estado));
            listaParametros.Add(new Parametro("@idJuez", idUsuario));
            manejador.EjecutarPA("cambiarEstadoDenuncia", ref listaParametros);
        }

        public void agregarGradoSeveridad()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idDenuncia", idDenuncia));
            listaParametros.Add(new Parametro("@grado", grado));
            manejador.EjecutarPA("agregarGradoDenuncia", ref listaParametros);
        }

        public void actualizarDenuncia()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idDenuncia", idDenuncia));
            listaParametros.Add(new Parametro("@titulo", titulo));
            listaParametros.Add(new Parametro("@descripcion", descripcion));
            listaParametros.Add(new Parametro("@foto", foto));
            manejador.EjecutarPA("cambiarDatosDenuncia", ref listaParametros);
        }
    }
}
