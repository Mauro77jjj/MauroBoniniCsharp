using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Models
{
    public class VentaProducto : Venta
    {
        private List<ProductoVendido> productos;

        public List<ProductoVendido> Productos { get => productos; set => productos = value; }

    }
}