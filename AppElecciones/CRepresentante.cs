using ClasesGenerales;

namespace AppElecciones
{
    //clase CPartido(IdPartido, Nombre, IdRepresentante, NroFirmasPresentadas, NroFirmasValidas).
    public class CRepresentante : CObjeto
    {
        private string? _ApellidoPaterno;
        private string? _ApellidoMaterno;
        private string? _Nombres;
        private string? _Dni;
        private string? _Direccion;

        public CRepresentante(string? idRepresentante, string? apellidoPaterno, string? apellidoMaterno, string? nombres, string? dni, string? direccion )
        {
            Id = idRepresentante;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = nombres;
            Dni = dni;
            Direccion = direccion;
        }

        public CRepresentante()
        {
            Id = null;
            ApellidoPaterno = null;
            ApellidoMaterno = null;
            Nombres = null;
            Dni = null;
            Direccion = null;
        }

        public string? ApellidoPaterno { get => _ApellidoPaterno; set => _ApellidoPaterno = value; }
        public string? ApellidoMaterno { get => _ApellidoMaterno; set => _ApellidoMaterno = value; }
        public string? Nombres { get => _Nombres; set => _Nombres = value; }
        public string? Dni { get => _Dni; set => _Dni = value; }
        public string? Direccion { get => _Direccion; set => _Direccion = value; }

        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine(" Apellido Paterno: {0}", ApellidoPaterno);
            Console.WriteLine(" Apellido Materno: {0}", ApellidoMaterno);
            Console.WriteLine(" Nombres: {0}", Nombres);
            Console.WriteLine(" DNI: {0}", Dni);
            Console.WriteLine(" Dirección: {0}", Direccion);
        }

        public override void Registrar()
        {
            Console.WriteLine("\nIngrese los datos\n");
            base.Registrar();
            Console.Write("Apellido Paterno:");
            ApellidoPaterno = Console.ReadLine();
            Console.Write("Apellido Materno:");
            ApellidoMaterno = Console.ReadLine();
            Console.Write("Nombres:");
            Nombres = Console.ReadLine();
            Console.Write("DNI:");
            Dni = Console.ReadLine();
            Console.Write("Dirección:");
            Direccion = Console.ReadLine();
        }
        public override bool Equals(object Objeto)
        {
            if ( Objeto is CRepresentante Representante)
            {
                return Representante.Id == Id;
            }
            else if ( Objeto is string id)
            {
                return Id == id;
            }
            return base.Equals(Objeto);
        }
    }
}
