using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using probarApi.Models;

namespace probarApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly Facade _fachada;
        public HomeController(Facade facade) 
        {
            _fachada = facade;
        }

        [HttpPost("Validar")]
        public dynamic getValidation(string username, string password)
        {
             return _fachada.validacion(username, password);
        }

        [HttpGet("pedirInfo")]
        public dynamic info(string descripcion)
        {
            return _fachada.pedirInfor(descripcion);
        }

        [HttpGet("enviar")]
        public dynamic enviar(string metodo, string opcion)
        {
           return _fachada.enviar(metodo, opcion);
        }

        [HttpGet("ObtenerInterfaz")]
        public dynamic getMen()
        {
            return _fachada.mostrar();
        }
        
    }
}
