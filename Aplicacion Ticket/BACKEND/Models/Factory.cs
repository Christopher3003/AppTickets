namespace probarApi.Models
{
    public class Factory
    {
        public static IMenu getMenues(string opcion)
        {
            switch (opcion) 
            {
                case "Cliente":
                    return new cliente();
                case "Proveedor":
                    return new proveedor();
                case "Empleado":
                    return new empleado();
            }
            return null;
        }
    }
}
