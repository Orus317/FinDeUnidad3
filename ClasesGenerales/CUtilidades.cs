namespace ClasesGenerales
{
    public static class Utilidades
    {
        public static int ValidarEntero(string message, int low, int high)
        {
            //Console.Write("Ingrese el valor: ");
            // Modulo para validar un entero entre dos límites
            string _opcion = Console.ReadLine();
            int opcion = 0;
            // Usar una estructura try-catch para poder poder manejar errores de tipo, generalmente cuando
            // se ingresan letras u otros caracteres 
            try
            {
                // Intentar parsear el string ingresado
                opcion = int.Parse(_opcion);
                // si el string es parseado se verifica que esté entre los límites
                while (opcion > high || opcion < low)
                {
                    // mostrar el mensaje de warning en consola
                    Console.WriteLine(message);
                    // recibir nuevamente la opcion
                    _opcion = Console.ReadLine();
                    // intentar parsear
                    opcion = int.Parse(_opcion);
                }
            }
            catch (Exception)
            {
                // En caso de que el parseo no funcione inmediatamente se mostrará el warn message y se ejecutará el validador nuevamente
                Console.WriteLine(message);
                return ValidarEntero(message, low, high);
            }
            return opcion;
        }
        public static float ValidarFlotante(string message, float low, float high)
        {
            // Modulo para validar un entero entre dos límites
            string _opcion = Console.ReadLine();
            float opcion = 0;
            // Usar una estructura try-catch para poder poder manejar errores de tipo, generalmente cuando
            // se ingresan letras u otros caracteres 
            try
            {
                // Intentar parsear el string ingresado
                opcion = float.Parse(_opcion);
                // si el string es parseado se verifica que esté entre los límites
                while (opcion > high || opcion < low)
                {
                    // mostrar el mensaje de warning en consola
                    Console.WriteLine(message);
                    // recibir nuevamente la opcion
                    _opcion = Console.ReadLine();
                    // intentar parsear
                    opcion = float.Parse(_opcion);
                }
            }
            catch (Exception)
            {
                // En caso de que el parseo no funcione inmediatamente se mostrará el warn message y se ejecutará el validador nuevamente
                Console.WriteLine(message);
                ValidarFlotante(message, low, high);
            }
            return opcion;
        }
    }
}
