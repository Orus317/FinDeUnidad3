using ClasesGenerales;

namespace AppElecciones
{
    public class CArbolRepresentante : CArbolObjeto
    {
        public CArbolRepresentante() : base() { }
        public void Agregar()
        {
            CRepresentante _ = new();
            _.Registrar();
            base.Agregar(_);
        }
        public void Agregar(string idRepresentante, string apellidoPaterno, string apellidoMaterno, string nombres, string dni, string direccion  )
        {
            CRepresentante _ = new(idRepresentante, apellidoMaterno, apellidoMaterno, nombres, dni, direccion);
            base.Agregar(_);
        }
        public void Eliminar()
        {
            Console.Write("Escriba el ID del representante a que desea eliminar: ");
            string IdToErase = Console.ReadLine() ?? "";
            base.Eliminar(IdToErase);
        }
        public override void Listar()
        {
            deProcesarObjeto = delegate (object Objeto)
            {
                if (Objeto is CRepresentante Representante)
                    Representante.Mostrar();
            };
            base.Listar();
        }   
        public void Buscar()
        {
            Console.Write("Escriba el ID del representante que busca: ");
            string IdToSearch = Console.ReadLine() ?? "";
            if (base.Buscar(IdToSearch) is CRepresentante Representante)
                Representante.Mostrar();
            else
                Console.WriteLine("No se encontró el elemento");
        }

    }
}
