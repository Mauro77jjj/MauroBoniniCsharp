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
    public class ADO_Usuario
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

        
        public static Usuario TraerUsuarioId(long idUsuario)
        {
            Usuario usuario = new Usuario();
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id ,Nombre ,Apellido ,NombreUsuario ,Contraseña ,Mail FROM Usuario WHERE Id = @IdUsuario", conn);
                adapter.SelectCommand.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = idUsuario;
                conn.Open();
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    DataRow dr = tabla.Rows[0];
                    usuario._id = (int)Convert.ToInt64(dr["Id"]); ;
                    usuario._Apellido = dr["Apellido"].ToString();
                    usuario._Nombre = dr["Nombre"].ToString();
                    usuario._NombreUsuario = dr["NombreUsuario"].ToString();
                    usuario._Contraseña = dr["Contraseña"].ToString();
                    usuario._Mail = dr["Mail"].ToString();
                }

                conn.Close();
            }
            return usuario;
        }

        public static long CrearUsuario(Usuario usu)

        {
            long id;
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail); Select scope_identity()", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = usu._Nombre;
                cmd.Parameters.Add(new SqlParameter("Apellido", SqlDbType.NVarChar)).Value = usu._Apellido;
                cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.NVarChar)).Value = usu._NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.NVarChar)).Value = usu._Contraseña;
                cmd.Parameters.Add(new SqlParameter("Mail", SqlDbType.NVarChar)).Value = usu._Mail;
                id = Convert.ToInt64(cmd.ExecuteScalar());
                conn.Close();
            }
            return id;

        }
        public static int ModificarUsuario(Usuario usu)

        {
            int filas_modificadas;
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Usuario SET  Nombre = @Nombre, Apellido = @Apellido , NombreUsuario = @NombreUsuario , Contraseña = @Contraseña , Mail = @Mail WHERE id = @id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.NVarChar)).Value = usu._id;
                cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = usu._Nombre;
                cmd.Parameters.Add(new SqlParameter("Apellido", SqlDbType.NVarChar)).Value = usu._Apellido;
                cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.NVarChar)).Value = usu._NombreUsuario;
                cmd.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.NVarChar)).Value = usu._Contraseña;
                cmd.Parameters.Add(new SqlParameter("Mail", SqlDbType.NVarChar)).Value = usu._Mail;
                filas_modificadas = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
            }
            return filas_modificadas;
        }
        public static int EliminarUsuario(long idUsuario)

        {
            int filas_eliminadas;
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete FROM Usuario WHERE Id = @IdUsuario", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.BigInt)).Value = idUsuario;
                filas_eliminadas = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
            }
            return filas_eliminadas;
        }
    }
}

      
