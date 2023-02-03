using ClasesGenerales;
namespace AppElecciones
{
    public class CMenu
    {

        public static void MostrarMenu(CControlPartido Partido, CControlRepresentante Representante, CArbolPartido ArbolPartido)
        {
            Console.WriteLine("========= Bibliteca =========");
            Console.WriteLine("1• Partido");
            Console.WriteLine("2• Representante");
            Console.WriteLine("3• Reportes");
            Console.WriteLine("4• Salir");
            Console.WriteLine();
            Console.Write(" -- Ingrese la opción: ");
            int Opcion = Utilidades.ValidarEntero("Debe ingresar un número del 1 al 4: ", 1, 5);
            EjecutarOpcion(Opcion, Partido, Representante, ArbolPartido);
        }

        public static void MenuReportes(CControlPartido Partido, CControlRepresentante Representante, CArbolPartido ArbolPartido)
        {
            Console.WriteLine("");
            Console.WriteLine("========= Reportes =========");
            Console.WriteLine("1. Reporte en pantalla 1");
            Console.WriteLine("2. Reporte en pantalla 2");
            Console.WriteLine("3. Reporte en pantalla 3");
            Console.WriteLine("4. Reporte en pantalla 4");
            Console.WriteLine("5. Salir ");
            Console.WriteLine();
            Console.Write(" -- Ingrese la opción: ");
            int opcion;
            do
            {
                opcion = Utilidades.ValidarEntero("Debe ingresar un número del 1 al 5: ", 1, 5);
                switch (opcion)
                {
                case 1:
                    ArbolPartido.nroFirmasValidasMayoraN();
                    break;
                case 2:
                    CReportes.ListarPartidosPorOrdenDescendenteDeFirmas(ArbolPartido);
                    break;
                case 3:
                    ArbolPartido.PartidoPorDni();
                    break;
                case 4:
                    CReportes.ListarPartidosConVallaDeVotos(ArbolPartido);
                    break;
                case 5:
                    CMenu.MostrarMenu(Partido, Representante, ArbolPartido);
                    break;
                default:
                    break;
                }
            }
            while (0 < opcion && opcion < 5);
        }

        private static void EjecutarOpcion(int opcion, CControlPartido partido, CControlRepresentante representante, CArbolPartido ArbolPartido)
        {
            do
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
                    MenuReportes(partido, representante, ArbolPartido);
                    break;
                case 4:
                    break;
                default:
                    break;
                }
            }
            while (0 < opcion && opcion < 4);
        }
    }
}

