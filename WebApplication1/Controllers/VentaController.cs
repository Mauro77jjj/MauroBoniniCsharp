
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using ConsoleApp1.Handlers;
using ConsoleApp1.Models;


namespace WebApplication2
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public void CargarVenta([FromBody] VentaProducto vtas)
        {
            ADO_Venta.CargarVenta(vtas);
        }
        [HttpGet("GetVentas")]
        public List<Venta> Get(int id)
        {
            return ADO_Venta.TraerVenta(id);
        }

        [HttpDelete]
        public void EliminarVenta([FromBody] Venta vtas)
        {
            ADO_Venta.EliminarVenta(vtas);
        }
    }



}
