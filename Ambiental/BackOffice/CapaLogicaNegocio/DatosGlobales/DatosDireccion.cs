using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaLogicaNegocio;
using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
    public class DatosDireccion
    {
        // atributos
        private Manejador M = new Manejador();

        // Carga el listado de nombres de provincias 
        public DataTable cargarProvincias()
        {
            return M.Consulta("cargarProvincias", null);
        }

        // Carga el listado de nombres de los cantones
        public DataTable cargarCantones(String provincia)
        {
            DataTable dt = new DataTable();
            List<Parametro> lista = new List<Parametro>();
            try{
                lista.Add(new Parametro("@provincia", provincia));
                dt = M.Consulta("cargarCantones", lista);
            }
            catch (Exception ex){
                throw ex;
            }
            return dt;
        }

        // Carga el listado de nombres de distritos
        public DataTable cargarDistritos(String canton)
        {
            DataTable dt = new DataTable();
            List<Parametro> lista = new List<Parametro>();
            try
            {
                lista.Add(new Parametro("@canton", canton));
                dt = M.Consulta("cargarDistritor", lista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
