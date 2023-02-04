using System.Data;
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
            private readonly int? _NroFirmasPresentadas;
            public PartidoNroFirmas(string? id, string? nombrePartido, int? NroFirmasPresentadas)
            {
                _id = id;
                _NombrePartido = nombrePartido;
                _NroFirmasPresentadas = NroFirmasPresentadas;
            }

            public int? NroFirmasPresentadas => _NroFirmasPresentadas;

            public void Mostrar()
            {
                Console.WriteLine("================");
                Console.WriteLine($"Id del partido: {_id}");
                Console.WriteLine($"Nombre del partido: {_NombrePartido}");
                Console.WriteLine($"Firmas presentadas: {_NroFirmasPresentadas}");
            }
            public override string ToString()
            {
                return _NroFirmasPresentadas.ToString();
            }
            public override bool Equals(object? obj)
            {
                if (obj is PartidoNroFirmas parti)
                {
                    return parti._id == _id;
                }
                return false;
            }
        }
        static public void ListarPartidosPorOrdenDescendenteDeFirmas(CArbolPartido ArbolPartido)
        {
            // Se crea una lista auxiliar
            List<PartidoNroFirmas> Aux = new();
            // Se crea una función anónima que procesará cada elemento del arbol
            Action<object> TransformarArbol = (obj) =>
            {
                if (obj is CPartido Partido)
                {
                    // Se agrega el elemento transformado a la lista
                    PartidoNroFirmas objetoTransformado = new(Partido.Id, Partido.Nombre, Partido.NroFirmasPresentadas);
                    Aux.Add(objetoTransformado);
                }
            };
            // Se recorre el arbol aplicando el método anónimo
            ArbolPartido.InOrden(TransformarArbol);
            // Se ordena descendentemente en función de las firmas
            Aux = Aux.OrderByDescending(el => el.NroFirmasPresentadas).ToList();
            // Se procesa cada elemento
            foreach (PartidoNroFirmas item in Aux)
            {
                item.Mostrar();
            }
        }
        static public void ListarPartidosConVallaDeVotos(CArbolPartido ArbolPartido)
        {
            // Se crea el arbol auxiliar
            CArbolPartido Aux = new();
            // Se genera la función anónima que agregará cada elemento si cumple la condición de tener un número de firmas válidas menor al tercio de firmas presentadas
            Action<object> FiltroFirmas = (object Obj) =>
            {
                CPartido partidito = (CPartido)Obj;
                if (Obj is CPartido Partido && (Partido.NroFirmasValidas < (Partido.NroFirmasPresentadas / 3)))
                {
                    Aux.Agregar(Partido);
                }
            };
            // Se recorre el arbol con la función anónima creada
            ArbolPartido.InOrden(FiltroFirmas);
            // Se lista el árbol filtrado
            Aux.Listar();
        }

        public static void PartidoPorDni(CArbolRepresentante ArbolRepresentante, CArbolPartido ArbolPartido)
        {
            Console.Write("Ingrese el DNI del representante: ");
            string dni = Console.ReadLine();
            // Variable inicial
            string IdRepresentante = "";
            // Accederemos a los elementos del árbol de representantes a traves de una cola 
            CCola cola = ArbolRepresentante.GenerarColaDeElementos();
            while (!cola.EsVacia())
            { 
                if (cola.Primero() is CRepresentante Representantes)
                {
                    // Verificamos si el Dni del representante en cuestión es igual del proporcionado por el usuario
                    if(dni == Representantes.Dni)
                    {
                        // Almacenamos el Id del representante que se usará para encontral el partido al que representa 
                        IdRepresentante = Representantes.Id;
                    }
                }
                cola.Retirar();
            }
            // Verificamos que se haya encontrado al representante
            if (IdRepresentante == "")
                Console.WriteLine("No se encontró al representante de DNI {0}", dni);
            // Accederemos a los elementos del árbol de partidos a traves de otra cola
            CCola colaPartido = ArbolPartido.GenerarColaDeElementos();
            while (!colaPartido.EsVacia())
            {
                if (colaPartido.Primero() is CPartido Partido)
                {
                    // Econtramos al representante e imprimimos el partido al que representa
                    if (IdRepresentante == Partido.IdRepresentante)
                    {
                        Console.WriteLine("Partido representado: {0}", Partido.Nombre);
                    }
                }
                colaPartido.Retirar();
            }
        }

        static public void NroFirmasValidasMayoraN(CArbolPartido ArbolPartido)
        {
            Console.Write("Ingrese el un número N: ");
            int N = int.Parse(Console.ReadLine());
            // Accederemos a los elementos del árbol de partidos a traves de una cola
            CCola cola = ArbolPartido.GenerarColaDeElementos();
            // Generamos una arbol auxiliar en donde se guardarán los partidos cuyas firmas válidas sean mayores a N
            CArbolPartido Aux = new();
            while (!cola.EsVacia())
            {
                if (cola.Primero() is CPartido Partido)
                {
                    // Agregamos los partidos cuyas firmas válidas sean mayores a N
                    if (Partido.NroFirmasValidas > N)
                    {
                        Aux.Agregar(Partido);
                    }
                }
                cola.Retirar();
            }
            // Accederemos a los elementos del árbol auxiliar a traves de otra cola
            CCola colaAux = Aux.GenerarColaDeElementos();
            while (!colaAux.EsVacia())
            {
                if (colaAux.Primero() is CPartido Partido)
                {
                    // imprimimos la información requerida
                    Console.WriteLine("========================");
                    Console.WriteLine("Partido: {0}", Partido.Nombre);
                    Console.WriteLine("Número de firmas válidas: {0}", Partido.NroFirmasValidas);
                }
                colaAux.Retirar();
            }
        }
    }
}
