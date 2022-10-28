using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp1.Handlers;
using ConsoleApp1.Models;


namespace WebApplication2
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductoVendidoController : ControllerBase
        {
            [HttpGet("GetProductosVendidos")]
            public List<ProductoVendido> Get(int id)
            {
                return ADO_ProductoVendido.TraerProductoVendido(id);
            }

        }

}
