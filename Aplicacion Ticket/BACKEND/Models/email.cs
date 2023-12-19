using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace probarApi.Models
{
    public class email:IEnvio
    {
        
        public string envio(string correo) 
        {
            try
            {
                string rutaDeserializarU = @"C:\Users\eldes\source\repos\apis\probarApi\Models\usuarioDesearializar.json";
                string rutaDeserializarInfo = @"C:\Users\eldes\source\repos\apis\probarApi\Models\info.json";

                //Deserializar usuario
                string jsonUser = File.ReadAllText(rutaDeserializarU);
                List<usuario> users = JsonConvert.DeserializeObject<List<usuario>>(jsonUser);
                usuario _usuario = users.FirstOrDefault();

                //Deserializar informacion del reporte
                string jsonInfo = File.ReadAllText(rutaDeserializarInfo);
                List<pedirInfo> _pedirInfo = JsonConvert.DeserializeObject<List<pedirInfo>>(jsonInfo);
                pedirInfo description = _pedirInfo.FirstOrDefault();


                string u = _usuario.nombreUsuario;
                string rol = _usuario.roll;
                string descripcion = description.descrip;

                guardarTicket.setTicket(u, rol, descripcion);
                string reporte = $"Usuario: {u} \n Roll: {rol} \n Descripcion: {descripcion}  \n Fecha: {DateTime.Now} \n Gracias por usar nuestra app ;)";
                string correoRemitente = "r00263439@gmail.com";
                string contraseña = "fait dyfy zqth qazo";

                string correoDestinatario = correo;

                MailMessage mensaje = new MailMessage(correoRemitente, correoDestinatario);
                mensaje.From = new MailAddress(correoRemitente, "REPORTES");
                mensaje.Subject = "Reporte Ticket";
                mensaje.Body = reporte;

                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                clienteSmtp.Port = 587;
                clienteSmtp.Host = "smtp.gmail.com";
                clienteSmtp.EnableSsl = true;
                clienteSmtp.Credentials = new NetworkCredential(correoRemitente, contraseña);

                try
                {
                    clienteSmtp.Send(mensaje);
                    return "Tu reporte ha sido enviado con exito. Presiona 'Aceptar' para volver al inicio de sesion";
                }
                catch (Exception ex)
                {
                  return $"Error al enviar el correo: {ex.Message}";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "Correo incorrecto";
        }
    }
}
