using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ConsoleApp1.Models;

namespace ConsoleApp1.Handlers
{
    public class UsuarioHandler
    {
        public static Usuario TraerUsuario(string nickname)
        {
            var Resultad = new Usuario();

            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using SqlConnection connection = new(cs);
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from Usuario where NombreUsuario = @User";
                cmd.Parameters.Add(new SqlParameter("@User", nickname));
                var reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {

                    Resultad._id = Convert.ToInt32(reader.GetValue(0));
                    Resultad._Nombre = reader.GetValue(1).ToString();
                    Resultad._Apellido = reader.GetValue(2).ToString();
                    Resultad._NombreUsuario = reader.GetValue(3).ToString();
                    Resultad._Contraseña = reader.GetValue(4).ToString();
                    Resultad._Mail = reader.GetValue(5).ToString();
                  
                    
                }
                
                connection.Close();

            }

            return Resultad;
        }










        /// encontra usuario y PW


        public static Usuario IniciarSesion(string nicknameus, string nicknamepw)
        {
            var Resultado = new Usuario();  
            

            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using SqlConnection connection = new(cs);
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from Usuario where NombreUsuario = @User and Contraseña = @pw";
                cmd.Parameters.Add(new SqlParameter("@User", nicknameus));
                cmd.Parameters.Add(new SqlParameter("@pw", nicknamepw));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    

                    Resultado._id = Convert.ToInt32(reader.GetValue(0));
                    Resultado._Nombre = reader.GetValue(1).ToString();
                    Resultado._Apellido = reader.GetValue(2).ToString();
                    Resultado._NombreUsuario = reader.GetValue(3).ToString();
                    Resultado._Contraseña = reader.GetValue(4).ToString();
                    Resultado._Mail = reader.GetValue(5).ToString();

                }

                connection.Close();

            }
            return Resultado;   
        }
    }
}
