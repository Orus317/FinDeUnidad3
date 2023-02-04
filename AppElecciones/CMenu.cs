using ClasesGenerales;
namespace AppElecciones
{
    public class CMenu
    {
        // Menú Principal
        public static void MostrarMenu()
        {
            Console.WriteLine("========= Bibliteca =========");
            Console.WriteLine("1• Partido");
            Console.WriteLine("2• Representante");
            Console.WriteLine("3• Reportes");
            Console.WriteLine("4• Salir");
            Console.WriteLine();
            Console.Write(" -- Ingrese la opción: ");
        }

        public static void EjecutarMenu(CControlPartido partido, CControlRepresentante representante, CArbolPartido ArbolPartido, CArbolRepresentante arbolRepresentante)
        {
            int opcion = -1;
            do
            {
                MostrarMenu();
                opcion = Utilidades.ValidarEntero("Debe ingresar un número del 1 al 4: ", 1, 5);
                switch (opcion)
                {
                case 1:
                    partido.EjecutarMenu(arbolRepresentante);
                    break;
                case 2:
                    representante.EjecutarMenu();
                    break;
                case 3:
                    EjecutarMenuReportes(partido, representante, ArbolPartido, arbolRepresentante);
                    break;
                case 4:
                    break;
                default:
                    break;
                }
            }
            while (0 < opcion && opcion < 4);
        }

        // Menú de los reportes en pantalla
        public static void MenuReportes()
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
        }

        public static void EjecutarMenuReportes(CControlPartido Partido, CControlRepresentante Representante, CArbolPartido ArbolPartido, CArbolRepresentante ArbolRepresentante)
        {
            int opcion;
            do
            {
                MenuReportes();
                opcion = Utilidades.ValidarEntero("Debe ingresar un número del 1 al 5: ", 1, 5);
                switch (opcion)
                {
                case 1:
                    CReportes.NroFirmasValidasMayoraN(ArbolPartido);
                    break;
                case 2:
                    CReportes.ListarPartidosPorOrdenDescendenteDeFirmas(ArbolPartido);
                    break;
                case 3:
                    CReportes.PartidoPorDni(ArbolRepresentante, ArbolPartido);
                    break;
                case 4:
                    CReportes.ListarPartidosConVallaDeVotos(ArbolPartido);
                    break;
                default:
                    break;
                }
            }
            while (0 < opcion && opcion < 5);
        }
    }
}
