using Microsoft.AspNetCore.Mvc;
using webapifinal.Models;
using webapifinal.Repository;

namespace webapifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("{idUsuario}")]
        public void CargarNuevaVenta(long idUsuario, List<Producto> productosVendidos)
        {
            VentasHandler.CargarVenta(idUsuario, productosVendidos);
        }

        [HttpGet("{idUsuario}")]
        public List<Venta> BuscarVentasPorUsuario(long idUsuario)
        {
            return VentasHandler.ObtenerVentasPorUsuario(idUsuario);
        }

    }
}
