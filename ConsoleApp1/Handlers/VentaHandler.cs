using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using System.Data.SqlClient;

namespace ConsoleApp1.Handlers
{
    public class VentaHandler
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
                    vent._IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    ListaVenta.Add(vent);
                }
             
                connection.Close();

            }
            return ListaVenta;  
        }

    }
}



    


