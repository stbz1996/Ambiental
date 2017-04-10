using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
    public class VerificaLogin{
        // atributos

        // manejador (conecta y desconecta la base de datos)
        private Manejador M = new Manejador();
        public String id { get; set; }
        public String rol { get; set; }
        public String user { get; set; }
        public String contraseña { get; set; }
        public String resultado { get; set; }


        // Busca el rol de un usuario en especifico 
        public String BuscarRol()
        {
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@cedula", Int64.Parse(this.id)));
            lista.Add(new Parametro("@retorno", SqlDbType.NVarChar, 10));
            M.EjecutarPA("buscarRolAdmin", ref lista);
            this.rol = lista[1].m_Valor.ToString();
            return this.rol;
        }

        // Verifica que el usuario esté registrado en la BD
        public String VerificarLogin() {
            List<Parametro> lista = new List<Parametro>();
            String Mensaje = "##";

            try { 
                lista.Add(new Parametro("@user", this.user));
                lista.Add(new Parametro("@Pass", this.contraseña));
                lista.Add(new Parametro("@Result", SqlDbType.NVarChar, 10));
                M.EjecutarPA("LoginAdmin", ref lista);
                
                // Atrapamos el parametro de respuesta
                Mensaje = lista[2].m_Valor.ToString();
                this.id = lista[2].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Mensaje;
        }
    }
}
