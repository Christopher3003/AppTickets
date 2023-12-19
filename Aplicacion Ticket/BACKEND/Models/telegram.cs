using Newtonsoft.Json;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace probarApi.Models
{
    public class telegram : IEnvio
    {
        public string envio(string IDChat)
        {
            try
            {
                string rutaDeserializarU = @"C:\Users\eldes\source\repos\apis\probarApi\Models\usuarioDesearializar.json";
                string rutaDeserializarInfo = @"C:\Users\eldes\source\repos\apis\probarApi\Models\info.json";

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

                string botToken = "6775537078:AAFhpHziwgWzclbjYa7DJLDyaglLLpi3XH8";
                string mensaje = $"Usuario: {u} \n Roll: {rol} \n Descripcion: {descripcion} \n Fecha: {DateTime.Now}";
                var botClient = new TelegramBotClient(botToken);

                Message message = botClient.SendTextMessageAsync(chatId: IDChat, text: mensaje).Result; 

                if (message != null && message.MessageId > 0)
                {
                    return "Tu reporte ha sido enviado con exito. Presiona 'Aceptar' para volver al inicio de sesion";
                }
                else
                {
                    return "Error al enviar el mensaje.";
                }
            }
            catch (Exception ex)
            {
                return "Error al enviar el mensaje: " + ex.Message;
            }
        }
    }
}

