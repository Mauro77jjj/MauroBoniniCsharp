using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using System.Data;
using System.Data.SqlClient;



namespace ConsoleApp1.Handlers
{

    public class ADO_Producto
    {
        public  List<Producto> TraerProducto()
        {
            var ListaProducto = new List<Producto>();


            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using SqlConnection connection = new(cs);
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from Producto";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto prod = new Producto();

                    prod.id = Convert.ToInt32(reader.GetValue(0));
                    prod.Descripcion = reader.GetValue(1).ToString();
                    prod.Costo = Convert.ToInt32(reader.GetValue(2));
                    prod.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    prod.Stock = Convert.ToInt32(reader.GetValue(4));
                    prod.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    ListaProducto.Add(prod);
                }
                connection.Close();
            }
            return ListaProducto;
        }
        public static long CrearProducto(Producto prod)
        {
            long id;
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var css = connectionbuilder.ConnectionString;

            using (SqlConnection conn = new SqlConnection(css))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES (@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario); Select scope_identity()", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.NVarChar)).Value = prod.id;
                cmd.Parameters.Add(new SqlParameter("Costo", SqlDbType.Float)).Value = prod.Costo;
                cmd.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Float)).Value = prod.PrecioVenta;
                cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = prod.Stock;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = prod.IdUsuario;
                id = Convert.ToInt64(cmd.ExecuteScalar());
                conn.Close();
            }
            return id;

        }
        public static int ModificarProducto(Producto prod)
        {
            int filas_modificadas;
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var csss = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(csss))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Producto  SET Descripciones = @Descripciones ,Costo = @Costo ,PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @idUsuario WHERE id = @id ", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt)).Value = prod.id;
                cmd.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.NVarChar)).Value = prod.Descripcion;
                cmd.Parameters.Add(new SqlParameter("Costo", SqlDbType.Float)).Value = prod.Costo;
                cmd.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Float)).Value = prod.PrecioVenta;
                cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = prod.Stock;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = prod.IdUsuario;
                filas_modificadas = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
            }
            return filas_modificadas;
        }
        public static int EliminarProducto(long idProducto)

        {
            int filas_eliminadas;
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var csss = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(csss))

            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Delete FROM ProductoVendido WHERE IdProducto = @idProducto", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("idProducto", SqlDbType.BigInt)).Value = idProducto;
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("Delete FROM Producto WHERE Id = @idProducto", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("idProducto", SqlDbType.BigInt)).Value = idProducto;
                filas_eliminadas = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
            }
            return filas_eliminadas;
        }
        public static Producto TraerProductoId(int IdProducto)
        {
            Producto producto = new Producto();


            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using SqlConnection connection = new(cs);
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Producto WHERE Id = @idProducto", connection);
                adapter.SelectCommand.Parameters.Add(new SqlParameter("idProducto", SqlDbType.BigInt)).Value = IdProducto;
                connection.Open();
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    DataRow dr = tabla.Rows[0];
                    producto.id = (int)Convert.ToInt64(dr["Id"]);
                    producto.Descripcion= dr["Descripciones"].ToString();
                    producto.Costo = Convert.ToDouble(dr["Costo"].ToString());
                    producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"].ToString());
                    producto.Stock = Convert.ToInt32(dr["Stock"].ToString());
                    producto.IdUsuario = (int)Convert.ToInt64(dr["IdUsuario"].ToString());
                }

                connection.Close();
            }
            return producto;
        }

        public  List<Producto> TraerProductoIdUsu(int IdUsu)
        {
            var ListaProducto = new List<Producto>();


            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using SqlConnection connection = new(cs);
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from Producto where IdUsuario = @PRODU";
                cmd.Parameters.Add(new SqlParameter("@IdUsu", IdUsu));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto prod = new Producto();

                    prod.id = Convert.ToInt32(reader.GetValue(0));
                    prod.Descripcion = reader.GetValue(1).ToString();
                    prod.Costo = Convert.ToInt32(reader.GetValue(2));
                    prod.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    prod.Stock = Convert.ToInt32(reader.GetValue(4));
                    prod.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    ListaProducto.Add(prod);
                }
                connection.Close();
            }
            return ListaProducto;
        }
    }
}
