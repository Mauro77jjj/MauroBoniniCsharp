using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using ConsoleApp1.Handlers;
using ConsoleApp1.Models;

namespace WebApplication1
{
        [Route("api/[controller]")]
        [ApiController]
        public class UsuarioController : ControllerBase
        {

            [HttpGet("GetUsuarios")]
            
            [HttpGet("GetUsuariosId")]
            public Usuario Get(Int32 id)
            {
                return ADO_Usuario.TraerUsuarioId(id);
            }

            [HttpGet("GetUsuariosNombre")]
            public Usuario Get(string nick)
            {
                return ADO_Usuario.TraerUsuario(nick);
            }

            [HttpGet("GetInicioSesion")]
            public Usuario Get(String nombre, String contraseña)
            {
                return ADO_Usuario.IniciarSesion(nombre, contraseña);
            }

            [HttpPost]
            public long Crear([FromBody] Usuario usu)
            {
                return ADO_Usuario.CrearUsuario(usu);

            }

            [HttpPut]
            public long Actualizar([FromBody] Usuario usu)
            {
                return ADO_Usuario.ModificarUsuario(usu);
            }

            [HttpDelete]
            public long Eliminar([FromBody] long idUsuario)
            {
                return ADO_Usuario.EliminarUsuario(idUsuario);
            }



        }
    }
    
 