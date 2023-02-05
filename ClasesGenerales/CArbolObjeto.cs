using EstructurasDeDatos;

namespace ClasesGenerales
{
    public delegate void DelegadoProcesarObjeto(object O);
    public delegate bool DelegadoSeleccionarObjeto(object O);

    public abstract class CArbolObjeto
    {
        #region  ATRIBUTOS 
        private CArbolAVL aArbol;
        // ----- Delegado para procesar los objetos de la lista
        public DelegadoProcesarObjeto? deProcesarObjeto = null;
        // ----- Delegado para seleccionar los objetos de la lista
        public DelegadoSeleccionarObjeto? deSeleccionarObjeto = null;

        #endregion   

        #region  PROPIEDADES 
        public CArbolAVL Arbol
        {
            get { return aArbol; }
            set { aArbol = value; }
        }
        #endregion  PROPIEDADES 

        #region  CONSTRUCTORES 
        public CArbolObjeto()
        {
            aArbol = new CArbolAVL();
        }
        public CArbolObjeto(CArbolAVL ArbolAVL)
        {
            aArbol = ArbolAVL;
        }
        #endregion  CONSTRUCTORES 


        #region    OTROS     
        public virtual void Agregar(object Objeto)
        {
            if (Buscar(Objeto) == null)
            {
                Arbol.Agregar(Objeto);
            }
            else
            {
                Console.WriteLine("El elemento ya está registrado");
            }
        }

        // ==============================================================
        public virtual CArbolAVL GenerarSubArbolAVL()
        {
            // ----- Generar arbol vacio
            CArbolAVL ArbolFiltrado = new();
            CCola ColaDeElementos = Arbol.GenerarColaDeElementos();
            // ----- Recorrer la lista y seleccionar objetos para el arbol
            while (!ColaDeElementos.EsVacia())
            {
                if (deSeleccionarObjeto == null || deSeleccionarObjeto(ColaDeElementos.Primero()))
                {
                    ArbolFiltrado.Agregar(ColaDeElementos.Primero());
                }
                ColaDeElementos.Retirar();  
            }
            //-----Retornar sub arbol
            return ArbolFiltrado;
        }
        // ==============================================================
        public virtual void Listar()
        {
            if (!Arbol.EstaVacio())
            {
                // Se genera una cola con los elementos del arbol
                CCola Cola = Arbol.GenerarColaDeElementos();
                // Se muestran los elementos en pantalla
                while (!Cola.EsVacia())
                {
                    if (deProcesarObjeto != null)
                        deProcesarObjeto(Cola.Primero());
                    else 
                        Console.WriteLine(Cola.Primero());
                    Cola.Retirar();
                }
            }
        }
        public CCola GenerarColaDeElementos()
        {
            return Arbol.GenerarColaDeElementos();
        }
        // ==============================================================
        public void Eliminar(object Objeto)
        {
            Arbol.Eliminar(Objeto);
        }
        public object? Buscar(object Objeto)
        {
            try
            {
                return Arbol?.SubArbol(Objeto)?.Raiz;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public object Minimo()
        {
            return Arbol.Minimo();
        }
        public object Maximo()
        {
            return Arbol.Maximo();
        }
        public bool EstaVacio()
        {
            return Arbol.EstaVacio();
        }
        public void InOrden(Action<object> Modulo)
        {
            Arbol.InOrden(Modulo);
        }
        public void PostOrden(Action<object> Modulo)
        {
            Arbol.PostOrden(Modulo);
        }
        #endregion
    }
}
