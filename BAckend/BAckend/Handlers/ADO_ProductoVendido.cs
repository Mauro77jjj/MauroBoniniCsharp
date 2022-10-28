using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConsoleApp1.Models;
using System.Data;

namespace ConsoleApp1.Handlers
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> TraerProductoVendido(int Idusua)
        {
            ADO_Producto prd = new ADO_Producto();
            List<Producto> producto = prd.TraerProducto(Idusua);
            List<ProductoVendido> productoVendidos = new List<ProductoVendido>();
            foreach (Producto prod in producto)
            {
                SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
                connectionbuilder.DataSource = "DESKTOP-URBCJ9O";
                connectionbuilder.InitialCatalog = "SistemaGestion";
                connectionbuilder.IntegratedSecurity = true;
                var cs = connectionbuilder.ConnectionString;

                using SqlConnection connection = new(cs);
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("Select pv.id as IdProductoVendido, pv.IdProducto, pv.IdVenta, pv.Stock as cantidad" + "from ProductoVendido as pv WHERE pv.IDProducto = @idprod", connection);
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@idprod", prod));
                    connection.Open();
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    foreach (DataRow dr in tabla.Rows)
                    {
                        ProductoVendido prdVend = new ProductoVendido();
                        prdVend._id = Convert.ToInt32(dr["ID"]);
                        prdVend._IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        prdVend._IdVenta = Convert.ToInt32(dr["IdVenta"]);
                        prdVend._Stock = Convert.ToInt32(dr["cantidad"].ToString());
                        productoVendidos.Add(prdVend);
                    }



                    connection.Close();

                }
                
            }
            return productoVendidos;
        }
    } 
}

    