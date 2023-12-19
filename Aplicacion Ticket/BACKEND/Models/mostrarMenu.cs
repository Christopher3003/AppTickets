using Newtonsoft.Json;

namespace probarApi.Models
{
    public class mostrarMenu
    {
        
        public  string mostrarM()
        {
            string rutaDelRoll = @"C:\Users\eldes\source\repos\apis\probarApi\Models\usuarioDesearializar.json";
            string jsonRoll = File.ReadAllText(rutaDelRoll);
            List<usuario> users = JsonConvert.DeserializeObject<List<usuario>>(jsonRoll);
            usuario _usuario = users.FirstOrDefault();
            string rol = _usuario.roll;
            IMenu _menu = Factory.getMenues(rol);
            return _menu.getMenu();
            
        }
    }
}
