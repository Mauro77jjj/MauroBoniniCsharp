using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Venta
    {
        public int _id { get; set; }
        public string _Comentarios { get; set; }
        public int _IdUsuario { get; set; }


        public Venta()
        {
            _id = 0;
            _Comentarios = string.Empty;
            _IdUsuario = 0;
        }

        public Venta(int id, string Comentarios, int IdUsuario)
        {
            _id = id;
            _Comentarios = Comentarios;
            _IdUsuario = IdUsuario;
        }
    }
}