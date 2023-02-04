using EstructurasDeDatos;
using ClasesGenerales;

namespace AppElecciones
{
    public class CArbolPartido : CArbolObjeto
    {
        public CArbolPartido() : base() { }
        public CArbolPartido(CArbolAVL Arbol) : base(Arbol) { }
        public void Agregar(object Obj)
        {
            base.Agregar(Obj);
        }
        public void Agregar(CArbolRepresentante arbolRepresentante)
        {
            CPartido _ = new();
            _.ArbolRepresentante = arbolRepresentante;
            _.Registrar();
            base.Agregar(_);
        }
        public void Agregar(string idPartido, string nombrePartido, string idRepresentante, int nroFirmasPresentadas, int nroFirmasValidas, CArbolRepresentante arbolRepresentante)
        {
            CPartido _ = new(idPartido, nombrePartido, idRepresentante, nroFirmasPresentadas, nroFirmasValidas, arbolRepresentante);
            base.Agregar(_);
        }
        public void Eliminar()
        {
            Console.Write("Escriba el ID del partido que desea eliminar: ");
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
        public override CArbolAVL GenerarSubArbolAVL()
        {
            return base.GenerarSubArbolAVL();
        }
        public void Buscar()
        {
            Console.Write("Escriba el ID del partido que busca: ");
            string IdToSearch = Console.ReadLine() ?? "";
            if (base.Buscar(IdToSearch) is CPartido Partido)
                Partido.Mostrar();
            else
                Console.WriteLine("No se encontró el elemento");
        }
    }
}
