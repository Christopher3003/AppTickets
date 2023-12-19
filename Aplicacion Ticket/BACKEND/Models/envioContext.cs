namespace probarApi.Models
{
    public class envioContext
    {
        IEnvio method;
        public envioContext(IEnvio envio)
        {
            this.method = envio;
        }

        public string envio(string opcion)
        {
            return method.envio(opcion);
        }
    }
}
