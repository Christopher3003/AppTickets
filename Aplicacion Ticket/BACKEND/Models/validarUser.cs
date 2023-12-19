using Newtonsoft.Json;


namespace probarApi.Models
{
    public class validarUser
    {

        public object validar(string username, string password)
        {

            try
            {
                string rutaJsonUsuarios = @"C:\Users\eldes\source\repos\apis\probarApi\Models\usuariosRegistrados.json";
                string rutaSerializarU = @"C:\Users\eldes\source\repos\apis\probarApi\Models\usuarioDesearializar.json";

                string json = File.ReadAllText(rutaJsonUsuarios);
                List<usuario> usuarios = JsonConvert.DeserializeObject<List<usuario>>(json);

                usuario usuarioActual = usuarios.Find(u => u.nombreUsuario == username && u.password == password);


                if (usuarioActual != null)
                {
                    
                    string rol = usuarioActual.roll;
                    List<usuario> userList = new List<usuario>
                    {
                        new usuario()
                        {
                            nombreUsuario = username,
                            roll = rol
                        }
                    };

                    string serializado = JsonConvert.SerializeObject(userList);
                    File.WriteAllText(rutaSerializarU, serializado);
                    
                    var resultado = new
                    {
                        mensaje = "Verificado",
                        roll = rol,
                        nombreUsuario = username
                    };

                    return resultado;
                }
                else
                {
                    return new
                    {
                        mensaje = "Usuario o contraseña incorrectos"
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    mensaje = "Error: " + ex.Message
                };
            }




        }
    }
}
    
