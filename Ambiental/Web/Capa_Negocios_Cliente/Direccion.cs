using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEnlaceDatos;

namespace Capa_Negocios_Cliente
{
    public class Direccion
    {
        Manejador manejador = new Manejador();

        public string nombreProvincia { get; set; }
        public string nombreCanton { get; set; }
        public int idJuez { get; set; }
        public DataTable listadoProvincias()
        {
            return manejador.listado("cargarProvincias", null);
        }

        public DataTable obtenerProvinciaJuez()
        {
            List<Parametro> listaParametros = new List<Parametro>();
            listaParametros.Add(new Parametro("@idJuez", idJuez));
            return manejador.listado("evaluarProvinciaJuez", listaParametros);
        }

        public DataTable listadoCanton()
        {
            List<Parametro> provincia = new List<Parametro>();
            provincia.Add(new Parametro("@provincia", nombreProvincia));

            return manejador.listado("cargarCantones", provincia);
        }

        public DataTable listadoDistrito()
        {
            List<Parametro> canton = new List<Parametro>();
            canton.Add(new Parametro("@canton", nombreCanton));

            return manejador.listado("cargarDistritos", canton);
        }
    }
}
