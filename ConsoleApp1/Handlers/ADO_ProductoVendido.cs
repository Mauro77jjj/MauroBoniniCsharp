using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConsoleApp1.Models;


namespace ConsoleApp1.Handlers
{
    public class ADO_ProductoVendido
    {
        public static List<Producto> TraerProductoVendido(int nick) 
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
                cmd.CommandText = "Select * from Producto as p inner join ProductoVendido as pv on pv.idProducto = p.id where p.idUsuario =@Usu";
                cmd.Parameters.Add(new SqlParameter("@Usu", nick));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto prod = new Producto();

                    prod._id = Convert.ToInt32(reader.GetValue(0));
                    prod._Descripcion = reader.GetValue(1).ToString();
                    prod._Costo = Convert.ToInt32(reader.GetValue(2));
                    prod._PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    prod._Stock = Convert.ToInt32(reader.GetValue(4));
                    prod._IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    ListaProducto.Add(prod);
                }

                
                connection.Close();


            }
            return ListaProducto;
        }
    }
}
    