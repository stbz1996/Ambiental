using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
    public class MetodosConsultante: MetodosAdministrador
    {
        // Atributos
        private Manejador M = new Manejador();

        // Obtiene el listado de jueces existentes
        public DataTable listadoJueces()
        {
            return M.Consulta("consultaDistritosJueces", null);
        }

        // Obtiene el listado de guardianes existentes
        public DataTable listadoGuardianes()
        {
            return M.Consulta("consultaDistritosGuardianes", null);
        }

        // Obtiene el listado de oficiales existentes
        public DataTable listadoOficiales()
        {
            return M.Consulta("consultaDistritosficiales", null);
        }
        
        // Carga todos los usuarios registrados
        public DataTable cargarUsuarios()
        {
            return M.Consulta("consultaGeneralUsuarios", null);
        }
        
        // Carga las denuncias juno con su gravedad
        public DataTable denunciasPorGravedad()
        {
            return M.Consulta("consultaGravedadDenuncia", null);
        }
        
        // Carga las denuncias con su gravedad filtradas entre fechas
        public DataTable FiltroDenunciaGravedadFecha(DateTime inicio, DateTime final)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@inicial", inicio));
                lst.Add(new Parametro("@final", final));
                dt = M.Consulta("consultaDenunciaFiltroXFechas", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga las denuncias con su gravedad filtradas por provincia
        public DataTable FiltroDenunciaGravedadProvincia(String provincia)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@provincia", provincia));
                dt = M.Consulta("consultaDenunciaFiltroXProvincia", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga las denuncias con su gravedad filtradas por canton
        public DataTable FiltroDenunciaGravedadCanton(String canton)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@canton", canton));
                dt = M.Consulta("consultaDenunciaFiltroXCanton", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga las denuncias con su gravedad filtradas por distrito
        public DataTable FiltroDenunciaGravedadDistrito(String dist)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@distrito", dist));
                dt = M.Consulta("consultaDenunciaFiltroXDistrito", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga las denuncias de cada guardian y que han sido rechasadas
        public DataTable cargarDenunciasRechazadasGuardian(int cantidad) {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@cantidad", cantidad));
                dt = M.Consulta("conteoDenunciasRechazadas", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga las denuncias de cada guardian y que han sido rechasadas con filtro de fechas
        public DataTable cargarDenunciasRechazadasGuardianXfecha(int cantidad, DateTime fecha)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@cantidad", cantidad));
                lst.Add(new Parametro("@fecha", fecha));
                dt = M.Consulta("conteoDenunciasRechazadasFiltroXFecha", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga listado de aportes filtrados por fecha
        public DataTable cargarAportesPorFecha(DateTime inicio, DateTime final)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@fechaInicial", inicio));
                lst.Add(new Parametro("@fechaFinal", final));
                dt = M.Consulta("consultaAportePorMes", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga listado de denuncias filtradas por fecha
        public DataTable cargarDenunciasXfecha(DateTime inicio, DateTime final)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@inicial", inicio));
                lst.Add(new Parametro("@limite", final));
                dt = M.Consulta("consultaDenunciasFiltroFecha", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // Carga listado de denuncias filtradas por provincia
        public DataTable cargarDenunciasXprovinciaa(String provincia)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@provincia", provincia));
                dt = M.Consulta("consultaDenunciasFiltroProvincia", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga listado de denuncias filtradas por canton
        public DataTable cargarDenunciasXCanton(String canton)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@canton", canton));
                dt = M.Consulta("consultaDenunciasFiltroCanton", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga listado de denuncias filtradas por distrito
        public DataTable cargarDenunciasXDistrion(String dist)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@distrito", dist));
                dt = M.Consulta("consultaDenunciasFiltroDistrito", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // Carga listado de denuncias filtradas por hashtag
        public DataTable cargarDenunciasXhastag(String hash)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@hashtag", hash));
                dt = M.Consulta("consultaDenunciasFiltroHashtag", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // carga top X de usuarios con mas denuncias
        public DataTable cargarTopXUsuariosConDenuncias(int top)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@top", top));
                dt = M.Consulta("consultaTopDenuncias", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // carga top X de oficiales con mas soluciones planteadas
        public DataTable cargarTopXOficialesConSoluciones(int top)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@cantidad", top));
                dt = M.Consulta("consultaTopSolucion", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // carga top X de jueces on mas soluciones aceptadas y rechazadas
        public DataTable cargarTopXJuecesConSoluciones(int top)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@cantidad", top));
                dt = M.Consulta("consultaTopJuezXDenunciaEvaluadas", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        // carga los reportes de las soluciones propuestas
        public DataTable cargarReportePropuestaSolucion()
        {
            try
            {
                return M.Consulta("consultaDenunciasConSolucion", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        // carga los reportes de las soluciones propuestas filtradas por fecha
        public DataTable cargarReportePropuestaSolucionFiltroFecha(DateTime fecha)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@fecha", fecha));
                dt = M.Consulta("consultaDenunciasConSolucionFiltroPorFecha", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // carga los reportes de las soluciones propuestas filtradas por provincias
        public DataTable cargarReportePropuestaSolucionFiltroProvincia(String prov)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@provincia", prov));
                dt = M.Consulta("consultaDenunciasConSolucionFiltroPorProvincia", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // carga los reportes de las soluciones propuestas filtradas por canton
        public DataTable cargarReportePropuestaSolucionFiltroCanton(String cant)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@canton", cant));
                dt = M.Consulta("consultaDenunciasConSolucionFiltroPorCanton", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // carga los reportes de las soluciones propuestas filtradas por distrito
        public DataTable cargarReportePropuestaSolucionFiltroDistrito(String dist)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@distrito", dist));
                dt = M.Consulta("consultaDenunciasConSolucionFiltroPorDistrito", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // carga los reportes de las soluciones propuestas filtradas por hashtag
        public DataTable cargarReportePropuestaSolucionFiltroHashtag(String has)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@hashtag", has));
                dt = M.Consulta("consultaDenunciasConSolucionFiltroPorHashtag", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // carga los datos de una denuncia especifica
        public DataTable CargarDenunciaEspecifica(int identificador)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idDenuncia", identificador));
                dt = M.Consulta("MostrarInformacionDenuncia", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // retorna el id del guardian que hizo la denunciasPorGravedad
        public DataTable obtenerGuardianDenuncia(int identificador)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idGuardian", identificador));
                dt = M.Consulta("obtenerGuardianDenuncia", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // retorna la direccion escrita de una denunciasPorGravedad
        public DataTable obtenerTextoDireccion(int identificador)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idDireccion", identificador));
                dt = M.Consulta("obtenerTextoDireccion", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // retorna el id del oficial que tiene relacion con la denuncia
        public DataTable obtenerOficialDenuncia(int identificador)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@idOficial", identificador));
                dt = M.Consulta("obtenerOficialDenuncia", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // retorn el documento xml de las denuncias
        public DataTable DocXML()
        {
            return M.Consulta("consultaDenunciasXML", null);
        }

        // retorna la bitacora del sistema
        public DataTable cargarBitacora()
        {
            return M.Consulta("cargarBitcora", null);
        }

        // retorna las acciones que hay en bitacora en un rango de fechas
        public DataTable cargarBitacoraXfecha(DateTime inicio, DateTime final)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@inicio", inicio));
                lst.Add(new Parametro("@final", final));
                dt = M.Consulta("cargarBitcoraFiltroFecha", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // cargar un listado con la cantidad de aportes y denuncias que ha hecho un guardian
        // y la cantidad de soluciones y aportes que ha hecho un oficial
        public DataTable cargarAportesDenunciasGO()
        {
            return M.Consulta("listadoGuardianesOfifialesTotal", null);
        }

        // cargar un listado con la cantidad de aportes y denuncias que ha hecho un guardian
        // y la cantidad de soluciones y aportes que ha hecho un oficial filtrado por fecha
        public DataTable cargarAportesDenunciasGOFiltroNombre(String nom)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@nombre", nom));
                dt = M.Consulta("listadoGuardianesOfifialesTotalFiltroNombre", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        // retorna un promedio de aportes por usuario
        public DataTable promedioAportesPorUsuario(DateTime inicio, DateTime final)
        {
            DataTable dt = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            try
            {
                lst.Add(new Parametro("@inicio", inicio));
                lst.Add(new Parametro("@final", final));
                dt = M.Consulta("promedioAportesPorUsuario", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }
    }
}

