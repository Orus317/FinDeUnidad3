using System.Xml;
using ClasesGenerales;

namespace AppElecciones
{
    public class CControlRepresentante
    {
        private CArbolRepresentante? _ArbolDeRepresentantes;
        public CArbolRepresentante? ArbolDeRepresentantes { get => _ArbolDeRepresentantes; set => _ArbolDeRepresentantes = value; }

        public CControlRepresentante(CArbolRepresentante inArbolDeRepresentantes)
        {
            ArbolDeRepresentantes = inArbolDeRepresentantes;
        }

        public CControlRepresentante()
        {
            ArbolDeRepresentantes = new();
        }

        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=========CONTROL DE REPRESENTANTES=========");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Listar");
            Console.WriteLine("4. Buscar (código)");
            Console.WriteLine("5. Salir ");
            Console.WriteLine();
            Console.Write(" -- Ingrese la opción: ");
        }

        public void EjecutarMenu()
        {
            int Opcion;
            do
            {
                Menu();
                Opcion = Utilidades.ValidarEntero("Debe ingresar un número positivo", 1, int.MaxValue);
                switch (Opcion)
                {
                case 1:
                    ArbolDeRepresentantes.Agregar();
                    break;
                case 2:
                    ArbolDeRepresentantes.Eliminar();
                    break;
                case 3:
                    ArbolDeRepresentantes.Listar();
                    break;
                case 4:
                    ArbolDeRepresentantes.Buscar();
                    break;
                default:
                    break;
                }
            }
            while (0 < Opcion && Opcion < 5);
        }
    }
}
