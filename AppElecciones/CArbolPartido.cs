using ClasesGenerales;

namespace AppElecciones
{
    public class CArbolPartido : CArbolObjeto
    {
        public CArbolPartido() : base() { }
        public void Agregar()
        {
            CPartido _ = new();
            _.Registrar();
            base.Agregar(_);
        }
        public void Eliminar()
        {
            Console.Write("Escriba el ID del partido que desea eliminar");
            string IdToErase = Console.ReadLine() ?? "";
            base.Eliminar(IdToErase);
        }
        public override void Listar()
        {
            deProcesarObjeto = delegate (object Objeto)
            {
                if (Objeto is CPartido Partido)
                    Partido.Mostrar();
            };
            base.Listar();
        }   
        public void Buscar()
        {
            Console.Write("Escriba el ID del partido que busca");
            string IdToSearch = Console.ReadLine() ?? "";
            if (base.Buscar(IdToSearch) is CPartido Partido)
                Partido.Mostrar();
            else
                Console.WriteLine("No se encontró el elemento");
        }

    }
}
