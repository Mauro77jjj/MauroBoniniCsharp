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

                    vent.id = Convert.ToInt32(reader.GetValue(0));
                    vent.Comentarios = reader.GetValue(1).ToString();
                    vent.IdUsuario = Convert.ToInt32(reader.GetValue(2));

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
                cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value = vtaProductos.Comentarios;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = vtaProductos.IdUsuario;
                idVenta = Convert.ToInt64(cmd.ExecuteScalar());

                //INSERT en tabla producto vendido con lista de productos enviados
                foreach (ProductoVendido producto in vtaProductos.Productos)
                {
                    //Agregar Venta
                    cmd = new SqlCommand("INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta)  VALUES   (@Stock,@IdProducto,@IdVenta) ", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt)).Value = idVenta;
                    cmd.ExecuteNonQuery();
                    //Actualizar Stock en Productos
                    cmd = new SqlCommand("UPDATE Producto SET Stock = Stock - @Stock WHERE idProducto = @IdProducto", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }

        public static void EliminarVenta(Venta venta)
        {
            var listaPV = new List<ProductoVendido>();
            string query = "SELECT * FROM ProductoVendido Where IdProducto = @IdVn";
            string query2 = "UPDATE Producto SET Stock = Stock + @PvStock " +"WHERE Id = @IdProducto";
            string query3 = "DELETE FROM ProductoVendido where IdVenta = @IdVn";
            string query4 = "DELETE FROM venta WHERE Id = @Idvnt";
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                using (SqlCommand cmd3 = new SqlCommand(query, conn))
                {
                    var param = new SqlParameter();
                    param.ParameterName = "IdVn";
                    param.SqlDbType = SqlDbType.BigInt;
                    param.Value = venta.id;
                    cmd3.Parameters.Add(param);

                    using (SqlDataReader dr = cmd3.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var pv = new ProductoVendido();

                            pv.id = Convert.ToInt32(dr.GetValue(0));
                            pv.Stock = Convert.ToInt32(dr.GetValue(1));
                            pv.IdProducto = Convert.ToInt32(dr.GetValue(2));
                            pv.IdVenta = Convert.ToInt32(dr.GetValue(3));

                            listaPV.Add(pv);
                        }
                        dr.Close();
                    }
                }

                using SqlCommand cmd = new SqlCommand(query2, conn);
                {

                    foreach (ProductoVendido pv in listaPV)
                    {
                        cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.Int)).Value = pv.IdProducto;
                        cmd.Parameters.Add(new SqlParameter("PvStock", SqlDbType.Int)).Value = pv.Stock;
                        cmd.ExecuteNonQuery();
                    }

                }

                using SqlCommand cmd2 = new SqlCommand(query3, conn);
                {
                    var param = new SqlParameter();
                    param.ParameterName = "IdVn";
                    param.SqlDbType = SqlDbType.BigInt;
                    param.Value = venta.id;

                    cmd2.Parameters.Add(param);
                    cmd2.ExecuteNonQuery();

                }

                using (SqlCommand cmd4 = new SqlCommand(query4, conn))
                {
                    var param = new SqlParameter();
                    param.ParameterName = "Idvnt";
                    param.SqlDbType = SqlDbType.BigInt;
                    param.Value = venta.id;

                    cmd2.Parameters.Add(param);
                    cmd2.ExecuteNonQuery();

                }
                conn.Close();
            }

        }

    }
}



    


