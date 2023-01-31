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
            Ejecutar(ArbolDePartidos);
        }
        public void Ejecutar(CArbolPartido ArbolDePartidos)
        {
            int Opcion;
            do
            {
                Opcion = Utilidades.ValidarEntero("Debe ingresar un número positivo", 1, int.MaxValue);
                switch (Opcion)
                {
                    case 1:
                        ArbolDePartidos.Agregar();
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
                Menu();
            } while (0 < Opcion && Opcion < 5);
        }
    }
}
