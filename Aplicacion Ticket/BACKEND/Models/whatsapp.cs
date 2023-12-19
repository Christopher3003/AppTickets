using Newtonsoft.Json;
using RestSharp;

namespace probarApi.Models
{
    public class whatsapp:IEnvio
    {
        public string envio(string numero)
        {
            try
            {
                string rutaDeserializarU = @"C:\Users\eldes\source\repos\apis\probarApi\Models\usuarioDesearializar.json";
                string rutaDeserializarInfo = @"C:\Users\eldes\source\repos\apis\probarApi\Models\info.json";
                numero = "+1" + numero;
                //Deserializar usuario
                string jsonUser = System.IO.File.ReadAllText(rutaDeserializarU);
                List<usuario> users = JsonConvert.DeserializeObject<List<usuario>>(jsonUser);
                usuario _usuario = users.FirstOrDefault();

                //Deserializar informacion del reporte
                string jsonInfo = System.IO.File.ReadAllText(rutaDeserializarInfo);
                List<pedirInfo> _pedirInfo = JsonConvert.DeserializeObject<List<pedirInfo>>(jsonInfo);
                pedirInfo description = _pedirInfo.FirstOrDefault();


                string u = _usuario.nombreUsuario;
                string rol = _usuario.roll;
                string descripcion = description.descrip;
                string mensaje = $"Usuario: {u} \n Roll: {rol} \n Descripcion: {descripcion} \n Fecha: {DateTime.Now}";
                var url = "https://api.ultramsg.com/instance67354/messages/chat";
                var client = new RestClient(url);

                var request = new RestRequest(url, Method.Post);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("token", "mj0uhbqr08blur6h");
                request.AddParameter("to", numero);
                request.AddParameter("body", mensaje);

                var response = client.Execute(request);
                

                return "Tu reporte ha sido enviado con exito. Presiona 'Aceptar' para volver al inicio de sesion";
            }
            catch(Exception e)
            {
                return e.Message;
            }
            }
    }
}

