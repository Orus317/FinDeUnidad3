using ClasesGenerales;
namespace AppElecciones 
{
    public class CMenu
    {

        public static void MostrarMenu(CControlPartido Partido, CControlRepresentante Representante)
        {
            Console.WriteLine("========= Bibliteca =========");
            Console.WriteLine("1• Partido");
            Console.WriteLine("2• Representante");
            Console.WriteLine("3• Reportes");
            Console.WriteLine("4• Devoluciones");
            Console.WriteLine();

            Console.Write(" -- Ingrese la opción: ");
            int Opcion = Utilidades.ValidarEntero("Debe ingresar un número del 1 al 4: ", 1, 5);
            EjecutarOpcion(Opcion, Partido, Representante);
        }

        private static void EjecutarOpcion(int opcion, CControlPartido partido, CControlRepresentante representante)
        {
            switch (opcion)
            {
                case 1:
                    partido.Menu();
                    break;
                case 2:
                    representante.Menu();
                    break;
                case 3:
                    // Devoluciones.Ejecutar();
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
    }
}

