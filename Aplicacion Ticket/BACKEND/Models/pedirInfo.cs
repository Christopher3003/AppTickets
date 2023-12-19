using Newtonsoft.Json;

namespace probarApi.Models
{
    public class pedirInfo
    {
        public string descrip { get; set; }
        public string getInfo(string descripcion) 
        { 
            this.descrip = descripcion;
            string rutaInfo = @"C:\Users\eldes\source\repos\apis\probarApi\Models\info.json";

            try
            {
                List<pedirInfo> newInfo = new List<pedirInfo>
                {
                    new pedirInfo
                    {
                        descrip = descripcion,
                    }
                };

                string serializarInfo = JsonConvert.SerializeObject(newInfo);
                File.WriteAllText(rutaInfo, serializarInfo);

            }catch(Exception e)
            {
                return e.Message;
            }

            return "Enviado";
        }
    }
}
