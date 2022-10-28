using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models;

public class Producto
{
    public int _id { get; set; }
    public string _Descripcion { get; set; }
    public double _Costo { get; set; }
    public double _PrecioVenta { get; set; }
    public int _Stock { get; set; }
    public int _IdUsuario { get; set; }


    // por defecto
    public Producto()
    {
        _id = 0;
        _Descripcion = string.Empty;
        _Costo = 0;
        _PrecioVenta = 0;
        _Stock = 0;
        _IdUsuario = 0;
    }


    public Producto(int id, string Descripcion, double Costo, double PrecioVenta, int Stock, int IdUsuario)
    {
        _id = id;
        _Descripcion = Descripcion;
        _Costo = Costo;
        _PrecioVenta = PrecioVenta;
        _Stock = Stock;
        _IdUsuario = IdUsuario;
    }

}



