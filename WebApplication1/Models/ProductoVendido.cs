using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{

    public class ProductoVendido
    {
        public int _id { get; set; }
        public int _IdProducto { get; set; }
        public int _Stock { get; set; }
        public int _IdVenta { get; set; }



        public ProductoVendido()
        {
            _id = 0;
            _IdProducto = 0;
            _Stock = 0;
            _IdVenta = 0;
        }

        public ProductoVendido(int id, int IdProducto, int Stock, int IdVenta)
        {
            _id = id;
            _IdProducto = IdProducto;
            _Stock = Stock;
            _IdVenta = IdVenta;
        }
    }
}