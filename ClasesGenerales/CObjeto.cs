namespace ClasesGenerales
{
    public abstract class CObjeto
    {
        #region  ATRIBUTOS 
        private string? _Id;
        public string? Id { get => _Id; set => _Id = value; }
        #endregion

        #region  CONSTRUCTORES
        public CObjeto()
        {
            // Constructor de un objeto vacío
            Id = null;
        }
        public CObjeto(string pId)
        {
            Id = pId;
        }
        #endregion   

        #region MÉTODOS     
        // ================================================================
        public override string ToString()
        {
            return Id;
        }

        // ================================================================
        public override bool Equals(object Objeto)
        {
            return (Objeto.ToString() == ToString());
        }

        // ================================================================
        public virtual void Registrar()
        {
            Console.Write("Identificador: ");
            Id = Console.ReadLine();
        }

        // ================================================================
        public virtual void EscribirID()
        {
            Console.WriteLine(Id);
        }

        // ================================================================
        public virtual void Mostrar()
        {
            Console.WriteLine("================");
            Console.WriteLine("Identificador: " + Id);
        }
        #endregion          
    }
}