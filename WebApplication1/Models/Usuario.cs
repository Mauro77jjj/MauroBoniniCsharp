using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models;


public class Usuario
{
    public int id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }
    public string Mail { get; set; }

    // por defecto
    public Usuario()
    {
        id = 0;
        Nombre = string.Empty;
        Apellido = string.Empty;
        NombreUsuario = string.Empty;
        Contraseña = string.Empty;
        Mail = string.Empty;
    }


    // parametrizado

    public Usuario(int id, string Nombre, string Apellido, string NombreUsuario, string Contraseña, string Mail)
    {
        id = id;
        Nombre = Nombre;
        Apellido = Apellido;
        NombreUsuario = NombreUsuario;
        Contraseña = Contraseña;
        Mail = Mail;
    }
}