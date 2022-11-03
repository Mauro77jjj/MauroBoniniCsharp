using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models;

public class Producto
{
    public int id { get; set; }
    public string Descripcion { get; set; }
    public double Costo { get; set; }
    public double PrecioVenta { get; set; }
    public int Stock { get; set; }
    public int IdUsuario { get; set; }


    // por defecto
    public Producto()
    {
        id = 0;
        Descripcion = string.Empty;
        Costo = 0;
        PrecioVenta = 0;
        Stock = 0;
        IdUsuario = 0;
    }


    public Producto(int id, string Descripcion, double Costo, double PrecioVenta, int Stock, int IdUsuario)
    {
        id = id;
        Descripcion = Descripcion;
        Costo = Costo;
        PrecioVenta = PrecioVenta;
        Stock = Stock;
        IdUsuario = IdUsuario;
    }

}



