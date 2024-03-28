using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        public int IdUsuario { get; set; } 
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public decimal Sueldo { get; set; }
        public Negocio.Area area { get; set; }

        public static Dictionary<string, object> Add(Negocio.Usuario usuario)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exception", "" }, { "Resultado", false } };
            try
            {
                using (Datos.TestSolContext context = new Datos.TestSolContext())
                {
                    var filasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioADD'{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.FechaDeNacimiento}',{usuario.Sueldo},{usuario.area.IdArea}");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> Delete(int IdUsuario)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false } };
            try
            {
                using ( Datos.TestSolContext context = new Datos.TestSolContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioDelete {IdUsuario}");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"]= true;
                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }

            return diccionario;
        }

        public static Dictionary<string, object> UpDate(Negocio.Usuario usuario)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false } };
            try
            {
                using (Datos.TestSolContext context = new Datos.TestSolContext())
                {
                    var filasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioUpDate'{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.FechaDeNacimiento}',{usuario.Sueldo},{usuario.area.IdArea}");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Excepcion"]=ex.Message;
            }
            return diccionario;
        }
    }
    
}
