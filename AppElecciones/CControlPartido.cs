using System.Xml;
using ClasesGenerales;

namespace AppElecciones
{
    public class CControlPartido
    {
        private CArbolPartido? _ArbolDePartidos;
        public CArbolPartido? ArbolDePartidos { get => _ArbolDePartidos; set => _ArbolDePartidos = value; }
        public CControlPartido(CArbolPartido inArbolDePartidos)
        {
            ArbolDePartidos = inArbolDePartidos;
        }
        public CControlPartido()
        {
            ArbolDePartidos = new();
        }
        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=========CONTROL DE PARTIDOS=========");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Listar");
            Console.WriteLine("4. Buscar (código)");
            Console.WriteLine("5. Salir ");
            Console.WriteLine();
            Console.Write(" -- Ingrese la opción: ");
        }
        public void EjecutarMenu(CArbolRepresentante arbolRepresentante)
        {
            int Opcion;
            do
            {
                Menu();
                Opcion = Utilidades.ValidarEntero("Debe ingresar un número entre 1 y 5", 1, 5);
                switch (Opcion)
                {
                case 1:
                    ArbolDePartidos.Agregar(arbolRepresentante);
                    break;
                case 2:
                    ArbolDePartidos.Eliminar();
                    break;
                case 3:
                    ArbolDePartidos.Listar();
                    break;
                case 4:
                    ArbolDePartidos.Buscar();
                    break;
                default:
                    break;
                }
                Console.WriteLine(Opcion);
            }
            while (0 < Opcion && Opcion < 5);
        }
    }
}
