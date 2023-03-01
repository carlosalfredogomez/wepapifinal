using Microsoft.AspNetCore.Mvc;
using webapifinal.Models;
using webapifinal.Repository;

namespace webapifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public List<ProductoVendido> BuscarProductosVendidosPorUsuario(long idUsuario)
        {
            return ProductoVendidoHandler.obtenerProductosVendidosPorUsuario(idUsuario);
        }
    }
}
