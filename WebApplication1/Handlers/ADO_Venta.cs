using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1.Handlers
{
    public class ADO_Venta
    {
        public static List<Venta> TraerVenta(int IdUs)
        {
            var ListaVenta = new List<Venta>();
            

            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using SqlConnection connection = new(cs);
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from Venta where IdUsuario = @Usu";
                cmd.Parameters.Add(new SqlParameter("@Usu", IdUs));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta vent = new Venta();

                    vent._id = Convert.ToInt32(reader.GetValue(0));
                    vent._Comentarios = reader.GetValue(1).ToString();
                    vent._IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    ListaVenta.Add(vent);
                }
             
                connection.Close(); 

            }
            return ListaVenta;  
        }


        public static void CargarVenta(VentaProducto vtaProductos)
        {
            long idVenta;
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //INSERT en tabla venta y obtener el id de la venta
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Venta] (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario); Select scope_identity();", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value = vtaProductos._Comentarios;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = vtaProductos._IdUsuario;
                idVenta = Convert.ToInt64(cmd.ExecuteScalar());

                //INSERT en tabla producto vendido con lista de productos enviados
                foreach (ProductoVendido producto in vtaProductos.Productos)
                {
                    //Agregar Venta
                    cmd = new SqlCommand("INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta)  VALUES   (@Stock,@IdProducto,@IdVenta) ", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto._Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto._IdProducto;
                    cmd.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt)).Value = idVenta;
                    cmd.ExecuteNonQuery();
                    //Actualizar Stock en Productos
                    cmd = new SqlCommand("UPDATE Producto SET Stock = Stock - @Stock WHERE idProducto = @IdProducto", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto._Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto._IdProducto;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }

    }
}



    


