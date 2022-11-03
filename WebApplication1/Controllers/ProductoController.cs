using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp1.Handlers;
using ConsoleApp1.Models;

namespace WebApplication2
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProductoController : ControllerBase
        {
            [HttpGet("GetProductos")]
            public List<Producto> Get(ADO_Producto produ)
            {
                 return produ.TraerProducto();
            }
            [HttpGet("GetProductosId")]
            public Producto Get(Int32 id)
            {
                return ADO_Producto.TraerProductoId(id);
            }

            [HttpPost]
            public void Crear([FromBody] Producto prod)
            {
                ADO_Producto.CrearProducto(prod);
            }
            [HttpPut]
            public void Modificar([FromBody] Producto prod)
            {
                ADO_Producto.ModificarProducto(prod);
            }
            [HttpDelete]
            public void Eliminar([FromBody] long idProducto)
            {
                ADO_Producto.EliminarProducto(idProducto);
            }
        }
    }
