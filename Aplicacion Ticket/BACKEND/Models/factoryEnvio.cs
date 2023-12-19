namespace probarApi.Models
{
    public class factoryEnvio
    {
        public static IEnvio GetEnvio(string opcion)
        {
            switch (opcion)
            {
                case "Email":
                    return new email();
                case "Whatsapp":
                    return new whatsapp();
                case "Telegram":
                    return new telegram();
            }
            return null;
        }
    }
}
