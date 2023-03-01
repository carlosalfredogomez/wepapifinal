using Microsoft.AspNetCore.Mvc;
using webapifinal.Models;
using webapifinal.Repository;

namespace webapifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{usuario}/{contrasena}")]
        public Usuario InicioSesion(string usuario, string contrasena)
        {
            return UsuarioHandler.InicioSesion(usuario, contrasena);

        }

        [HttpGet("{usuario}")]
        public Usuario TraerUsuario(string usuario)
        {
            return UsuarioHandler.buscarUsuario(usuario);

        }

        [HttpPost]
        public void CrearUsuario(Usuario nuevoUsuario)
        {
            UsuarioHandler.CargarUsuario(nuevoUsuario);
        }

        [HttpPut]
        public void ModificarUsuario(Usuario nuevoUsuario)
        {
            UsuarioHandler.ModificarUsuario(nuevoUsuario);
        }

        [HttpDelete("{idUsuario}")]
        public void EliminarUnUsuario(long idUsuario)
        {
            UsuarioHandler.EliminarUsuario(idUsuario);

        }

    }
}
