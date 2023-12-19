

using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace probarApi.Models
{
    public class guardarTicket
    {
        private static guardarTicket _guardarTicket;

        private guardarTicket()
        {

        }

        public static guardarTicket GetGuardarTicket()
        {
            if (_guardarTicket == null)
            {
                return new guardarTicket();
            }

            return _guardarTicket;
        }
        public static string setTicket(string usuario, string rol, string desc)
        {

         
            try
            {
                string path = @"C:\Users\eldes\source\repos\apis\probarApi\Models\guardarTicket.txt";
                string tick = $"Usuario {usuario} \n Roll: {rol} \n Descripcion: {desc} \n Fecha: {DateTime.Now}";
                System.IO.File.AppendAllText(path,tick);

                return "Guardado exitosamente";
            }
            catch (Exception ex) { return ex.Message; }
            
        }
    }
}
