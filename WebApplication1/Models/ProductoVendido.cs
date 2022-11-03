using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{

    public class ProductoVendido
    {
        public int id { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }



        public ProductoVendido()
        {
            id = 0;
            IdProducto = 0;
            Stock = 0;
            IdVenta = 0;
        }

        public ProductoVendido(int id, int IdProducto, int Stock, int IdVenta)
        {
            id = id;
            IdProducto = IdProducto;
            Stock = Stock;
            IdVenta = IdVenta;
        }
    }
}