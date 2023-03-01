using Microsoft.AspNetCore.Mvc;
using webapifinal.Models;
using webapifinal.Repository;

namespace webapifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
       
        [HttpGet("{idUsuario}")]
        public List<Producto> BuscarProductosPorUsuario(long idUsuario)
        {
            return ProductoHandler.obtenerProductosPorUsuario(idUsuario);
        }

        [HttpPost]
        public void CrearProducto(Producto nuevoProducto)
        {
            ProductoHandler.CargarProducto(nuevoProducto);
        }


        [HttpPut]
        public int ModificarProducto(Producto aModificar)
        {
            return ProductoHandler.ModificarProducto(aModificar);
        }

        [HttpDelete("{id}")]
        public int BorrarProducto(long id)
        {
            return ProductoHandler.EliminarProducto(id);
        }


    }

}
