using Microsoft.Extensions.Options;

namespace probarApi.Models
{
    public class Facade
    {
        private readonly validarUser _validarUser;
        private readonly pedirInfo _pedirInfo;
        private  envioContext _envioContext;
        private readonly mostrarMenu _mostrarMenu;


        public Facade(validarUser validarUser, pedirInfo pedirInfo, mostrarMenu mostrarMenu)
        {
            _validarUser = validarUser;
            _pedirInfo = pedirInfo;
            _mostrarMenu = mostrarMenu; 
        }
        public object validacion(string username, string password)
        {
            return _validarUser.validar(username, password);
        }

        public string pedirInfor(string descripcion)
        {
            return _pedirInfo.getInfo(descripcion);
        }

        public string enviar(string metodo, string opcion)
        {
            _envioContext = new envioContext(factoryEnvio.GetEnvio(opcion));
            return _envioContext.envio(metodo);
            
        }

        public string mostrar()
        {
            return _mostrarMenu.mostrarM();
        }
        
    }
}
