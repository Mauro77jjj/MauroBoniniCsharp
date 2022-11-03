using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Venta
    {
        public int id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }


        public Venta()
        {
            id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
        }

        public Venta(int id, string Comentarios, int IdUsuario)
        {
            id = id;
            Comentarios = Comentarios;
            IdUsuario = IdUsuario;
        }
    }
}