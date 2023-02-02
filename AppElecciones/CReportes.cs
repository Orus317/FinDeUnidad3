using EstructurasDeDatos;

namespace AppElecciones
{
    static public class CReportes
    {
        //Clase auxiliar para el desarrollo del reporte de orden descendente por número de firmas válidas
        private class PartidoNroFirmas
        {
            private readonly string? _id;
            private readonly string? _NombrePartido;
            private readonly int? _NroFirmasValidas;
            public PartidoNroFirmas(string? id, string? nombrePartido, int? nroFirmasValidas)
            {
                _id = id;
                _NombrePartido = nombrePartido;
                _NroFirmasValidas = nroFirmasValidas;
            }

            public int? NroFirmasValidas => _NroFirmasValidas;

            public void Mostrar()
            {
                Console.WriteLine("================");
                Console.WriteLine($"Id del partido: {_id}");
                Console.WriteLine($"Nombre del partido: {_NombrePartido}");
                Console.WriteLine($"Firmas Validas: {_NroFirmasValidas}");
            }
            public override string ToString()
            {
                return _NroFirmasValidas.ToString();
            }
        }
        static public void ListarPartidosPorOrdenDescendenteDeFirmas(CArbolPartido ArbolPartido)
        {
            string? id, nombrePartido;
            int? nroFirmasValidas;
            // Usamos una lista para facilitar el proceso de ordenamiento
            List<PartidoNroFirmas> Aux = new();
            // Usamos una cola para facilitar el acceso a los elementos
            CCola cola = ArbolPartido.GenerarColaDeElementos();
            while (!cola.EsVacia())
            {
                // Extraer el primer elemento y castearlo como un partido
                CPartido _ = (CPartido)cola.Primero();
                // Asignaciones
                id = _.Id;
                nombrePartido = _.Nombre;
                nroFirmasValidas = _.NroFirmasValidas;
                cola.Retirar();
                // Se agrega el elemento la lista auxiliar
                Aux.Add(new PartidoNroFirmas(id, nombrePartido, nroFirmasValidas));
            }
            // Se ordena la lista según el número de firmas
            Aux = Aux.OrderBy(el => el.NroFirmasValidas).ToList();
            foreach (PartidoNroFirmas Res in Aux)
            {
                Res.Mostrar();
            }

        }
        static public void ListarPartidosConVallaDeVotos(CArbolPartido ArbolPartido)
        {
            // Se genera una cola con los elementos
            CCola cola = ArbolPartido.GenerarColaDeElementos();
            // Se declarar una variable para la suma total de firmas
            int? totalFirmas = 0;
            // Se calculan todas las firmas
            while (!cola.EsVacia())
            {
                if (cola.Primero() is CPartido Partido)
                {
                    totalFirmas += Partido.NroFirmasPresentadas;
                }
                cola.Retirar();
            }
            // Se calcula la valla de las firmas
            int? vallaDeFirmas = totalFirmas / 3;
            // Se crea el arbol auxiliar
            CArbolPartido Aux = new();
            // Se vuelve a generar la cola de elementos
            cola = ArbolPartido.GenerarColaDeElementos();
            // Se agregan los partidos cuyo número de firmas válidas sea menor que la valla de firmas
            while (!cola.EsVacia())
            {
                if (cola.Primero() is CPartido Partido && Partido.NroFirmasValidas < vallaDeFirmas)
                {
                    Aux.Agregar(Partido);
                }
            }
            // Se muestran todos los resultados en pantalla
            Aux.Listar();
        }
    }
}
