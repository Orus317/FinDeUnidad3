using ClasesGenerales;

namespace AppElecciones
{
    //clase CPartido(IdPartido, Nombre, IdRepresentante, NroFirmasPresentadas, NroFirmasValidas).
    public class CPartido : CObjeto
    {
        #region Atributos
        //private string? _IdPartido;
        private string? _Nombre;
        private string? _IdRepresentante;
        private int? _NroFirmasPresentadas;
        private int? _NroFirmasValidas;
        #endregion
        #region Propiedades
        public string? Nombre { get => _Nombre; set => _Nombre = value; }
        public string? IdRepresentante { get => _IdRepresentante; set => _IdRepresentante = value; }
        public int? NroFirmasPresentadas { get => _NroFirmasPresentadas; set => _NroFirmasPresentadas = value; }
        public int? NroFirmasValidas { get => _NroFirmasValidas; set => _NroFirmasValidas = value; }
        #endregion
        #region Constructores
        public CPartido(string? idPartido, string? nombre, string? idRepresentante, int? nroFirmasPresentadas, int? nroFirmasValidas)
        {
            Id = idPartido;
            Nombre = nombre;
            IdRepresentante = idRepresentante;
            NroFirmasPresentadas = nroFirmasPresentadas;
            NroFirmasValidas = nroFirmasValidas;
        }
        public CPartido()
        {
            Id = null;
            Nombre = null;
            IdRepresentante = null;
            NroFirmasPresentadas = null;
            NroFirmasValidas = null;
        }

        #endregion
        #region Métodos
        // Definir Equals y ToString 
        public override void Registrar()
        {
            base.Registrar();
            Console.Write("Nombre del partido: ");
            Nombre = Console.ReadLine();
            Console.Write("Id del representante: ");
            IdRepresentante = Console.ReadLine();
            Console.Write("Número de firmas presentadas: ");
            NroFirmasPresentadas = Utilidades.ValidarEntero("Debe ser un número positivo", 1, int.MaxValue);
            Console.Write("Número de firmas válidas: ");
            NroFirmasValidas = Utilidades.ValidarEntero("Debe ser un número positivo", 1, int.MaxValue);
            while (NroFirmasValidas > NroFirmasPresentadas)
            {
                Console.WriteLine("Las firmas válidas deben ser menores a las presentadas");
                Console.Write("Número de firmas válidas: ");
                NroFirmasValidas = Utilidades.ValidarEntero("Debe ser un número positivo", 1, int.MaxValue);
            }
        }
        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine($"Nombre del partido: {Nombre}");
            Console.WriteLine($"Identificador del representante: {IdRepresentante}");
            Console.WriteLine($"Número de firmas presentadas: {NroFirmasPresentadas}");
            Console.WriteLine($"Número de firmas válidas: {NroFirmasValidas}");
        }
        public override bool Equals(object Objeto)
        {
            if ( Objeto is CPartido Partido)
            {
                return Partido.Id == Id;
            } else if ( Objeto is string id)
            {
                return Id == id;
            }
            return base.Equals(Objeto);
        }

        public string Representante(){
            return IdRepresentante;
        } 
        public string Partido(){
            return Nombre;
        }
        #endregion
    }
}
