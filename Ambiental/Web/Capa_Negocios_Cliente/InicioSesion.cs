using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEnlaceDatos;

namespace Capa_Negocios_Cliente
{
    public class InicioSesion
    {
        private Manejador manejador = new Manejador();

        public String user { get; set; }
        public String contraseña { get; set; }
        public int idUsuario { get; set; }

        public String verificarLogin()
        {
            List<Parametro> lista = new List<Parametro>();
            String Mensaje;

            try
            {
                lista.Add(new Parametro("@user", this.user));
                lista.Add(new Parametro("@Pass", this.contraseña));
                // retorno
                lista.Add(new Parametro("@Result", SqlDbType.NVarChar, 10));

                // Ejecuta el procedimiento
                manejador.EjecutarPA("LoginUsuario", ref lista);

                // Atrapamos el parametro de respuesta
                Mensaje = lista[2].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Mensaje;
        }

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

        public DataTable recuperarPuntos()
        {
            DataTable dt = new DataTable();
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idUsuario", idUsuario));
            //listaParametros.Add(new Parametro("@puntos", SqlDbType.Int));
            dt = manejador.listado("obtenerPuntos", listaParametros);
            return dt;

        }
    }
}
