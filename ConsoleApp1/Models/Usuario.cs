using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models;


public class Usuario
{
    public int _id { get; set; }
    public string _Nombre { get; set; }
    public string _Apellido { get; set; }
    public string _NombreUsuario { get; set; }
    public string _Contraseña { get; set; }
    public string _Mail { get; set; }

    // por defecto
    public Usuario()
    {
        _id = 0;
        _Nombre = string.Empty;
        _Apellido = string.Empty;
        _NombreUsuario = string.Empty;
        _Contraseña = string.Empty;
        _Mail = string.Empty;
    }


    // parametrizado

    public Usuario(int id, string Nombre, string Apellido, string NombreUsuario, string Contraseña, string Mail)
    {
        _id = id;
        _Nombre = Nombre;
        _Apellido = Apellido;
        _NombreUsuario = NombreUsuario;
        _Contraseña = Contraseña;
        _Mail = Mail;
    }
}