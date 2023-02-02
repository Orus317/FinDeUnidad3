namespace EstructurasDeDatos
{
    public class CArbolBB
    {
        #region ***********************  Atributos   ************************* 
        private CArbolBB aSubArbolIzq;
        private object aRaiz;
        private CArbolBB aSubArbolDer;

        #endregion Atributos  

        #region *********************  Constructores   ***********************

        /* -------------------------------------------------------------- */
        public CArbolBB()
        {
            aSubArbolIzq = null;
            aRaiz = null;
            aSubArbolDer = null;
        }

        /* -------------------------------------------------------------- */
        public CArbolBB(object pRaiz)
        {
            aSubArbolIzq = null;
            aRaiz = pRaiz;
            aSubArbolDer = null;
        }

        /* -------------------------------------------------------------- */
        public CArbolBB(CArbolBB pSubArbolIzq, object pRaiz, CArbolBB pSubArbolDer)
        {
            aSubArbolIzq = pSubArbolIzq;
            aRaiz = pRaiz;
            aSubArbolDer = pSubArbolDer;
        }


        #endregion Constructores

        #region *********************  Propiedades  ***********************
        /* ---------------------------------------------------------- */
        public CArbolBB SubArbolIzq
        {
            get
            {
                return aSubArbolIzq;
            }
            set
            {
                aSubArbolIzq = value;
            }
        }

        /* ---------------------------------------------------------- */
        public object Raiz
        {
            get
            {
                return aRaiz;
            }
            set
            {
                aRaiz = value;
            }
        }

        /* ---------------------------------------------------------- */
        public CArbolBB SubArbolDer
        {
            get
            {
                return aSubArbolDer;
            }
            set
            {
                aSubArbolDer = value;
            }
        }

        #endregion Propiedades

        #region ***********************  Metodos  *************************

        /* -------------------------------------------------------------- */
        public bool EstaVacio()
        {
            return (aRaiz == null);
        }

        /* -------------------------------------------------------------- */
        public virtual void Agregar(object Elemento)
        {
            if (aRaiz == null)
            {
                aRaiz = Elemento;
            }
            else
            {
                if (Elemento.ToString().CompareTo(aRaiz.ToString()) < 0)
                {
                    if (aSubArbolIzq == null)
                        aSubArbolIzq = new CArbolBB(null, Elemento, null);
                    else
                        aSubArbolIzq.Agregar(Elemento);
                }
                else
                {
                    if (aSubArbolDer == null)
                        aSubArbolDer = new CArbolBB(null, Elemento, null);
                    else
                        aSubArbolDer.Agregar(Elemento);
                }
            }
        }

        /* -------------------------------------------------------------- */
        private void EliminarHoja()
        {
            aRaiz = null;
        }

        /* -------------------------------------------------------------- */
        private void EliminarNodoConHijoIzq()
        {
            aRaiz = aSubArbolIzq.Raiz;
            aSubArbolDer = aSubArbolIzq.aSubArbolDer;
            aSubArbolIzq = aSubArbolIzq.aSubArbolIzq;
        }

        /* -------------------------------------------------------------- */
        private void EliminarNodoConHijoDer()
        {
            aRaiz = aSubArbolDer.Raiz;
            aSubArbolIzq = aSubArbolDer.SubArbolIzq;
            aSubArbolDer = aSubArbolDer.SubArbolDer;
        }

        /* -------------------------------------------------------------- */
        private void EliminarNodoConDosHijos()
        {
            //object RaizAux = aRaiz;
            aRaiz = aSubArbolDer.Minimo();
            aSubArbolDer.Eliminar(aRaiz);
        }

        /* -------------------------------------------------------------- */
        private void EliminarNodo()
        {
            // -- Verificar si es Hoja
            if ((aSubArbolIzq == null) && (aSubArbolDer == null))
                EliminarHoja();
            // -- Verificar si es nodo sólo con hijo izq
            else if ((aSubArbolIzq != null) && (aSubArbolDer == null))
                EliminarNodoConHijoIzq();
            // -- Verificar si es nodo sólo con hijo der
            else if ((aSubArbolIzq == null) && (aSubArbolDer != null))
                EliminarNodoConHijoDer();
            // -- Nodo tiene ambos hijos
            else
                EliminarNodoConDosHijos();
        }

        /* -------------------------------------------------------------- */
        public virtual void Eliminar(object pRaiz)
        {
            if (EstaVacio())
                Console.WriteLine("ERROR. Elemento no encontrado...");
            else
            {
                // ----- Verificar si la raiz es el elemento que se desea eliminar
                if ((pRaiz.ToString()).Equals(aRaiz.ToString()))
                    EliminarNodo();
                else
                {
                    // ----- Verificar si el elemento a eliminar esta en el hijo Izq
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) < 0)
                    {
                        aSubArbolIzq?.Eliminar(pRaiz);
                    }
                    else // ----- Elemento a eliminar esta en el hijo Der
                    {
                        aSubArbolDer?.Eliminar(pRaiz);
                    }
                }
                // Eliminar hojas vacías, verificando si los hijos son hojas vacias 
                if ((aSubArbolIzq != null) && aSubArbolIzq.EstaVacio())
                    aSubArbolIzq = null;
                if ((aSubArbolDer != null) && aSubArbolDer.EstaVacio())
                    aSubArbolDer = null;
            }
        }

        /* -------------------------------------------------------------- */
        public CArbolBB SubArbol(object pRaiz)
        {
            if (EstaVacio())
                return null;
            else
                if (aRaiz.Equals(pRaiz))
                return this;
            else
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) < 0)
                return aSubArbolIzq != null ? aSubArbolIzq.SubArbol(pRaiz) : null;
            else
                return aSubArbolDer != null ? aSubArbolDer.SubArbol(pRaiz) : null;
        }

        /* -------------------------------------------------------------- */
        public CArbolBB Padre(object pRaiz)
        {
            if (EstaVacio())
                return null;
            else
                if (EsHijo(pRaiz))
                    return this;
                else
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) < 0)
                        return aSubArbolIzq != null ? aSubArbolIzq.Padre(pRaiz) : null;
                    else
                        return aSubArbolDer != null ? aSubArbolDer.Padre(pRaiz) : null;
        }
        public object? BuscarNodo(object Elemento)
        {
            CArbolBB NodoPadre = Padre(Elemento);
            //return NodoP
            if (NodoPadre == null)
                return null;
            else if (NodoPadre.Raiz.Equals(Elemento))
                return NodoPadre.Raiz;
            else if (Elemento.ToString().CompareTo(NodoPadre.Raiz.ToString()) < 0)
                return aSubArbolIzq.Raiz;
            else
                return aSubArbolDer.Raiz;
        }
        /* -------------------------------------------------------------- */
        public bool EsHijo(object pRaiz)
        {
            return (((aSubArbolIzq != null) && (aSubArbolIzq.Raiz.Equals(pRaiz))) ||
                    ((aSubArbolDer != null) && (aSubArbolDer.Raiz.Equals(pRaiz))));
        }

        /* -------------------------------------------------------------- */
        public bool EsHoja()
        {
            return (aSubArbolIzq == null) && (aSubArbolDer == null);
        }


        /* -------------------------------------------------------------- */
        public object Minimo()
        {
            if (EstaVacio())
                return null;
            else
                return SubArbolIzq == null ? aRaiz : aSubArbolIzq.Minimo();
        }

        /* -------------------------------------------------------------- */
        public object Maximo()
        {
            if (EstaVacio())
                return null;
            else
                return SubArbolDer == null ? aRaiz : aSubArbolDer.Maximo();
        }

        /* -------------------------------------------------------------- */
        public int Altura()
        {
            if (EstaVacio())
                return 0;
            else
            {
                int AlturaIzq = (aSubArbolIzq == null ? 0 : 1 + aSubArbolIzq.Altura());
                int AlturaDer = (aSubArbolDer == null ? 0 : 1 + aSubArbolDer.Altura());
                return (AlturaIzq > AlturaDer ? AlturaIzq : AlturaDer);
            }
        }

        /* -------------------------------------------------------------- */
        public void RecorrerCola(CCola Cola, CCola ColaAcumulativa)
        {
            if (!Cola.EsVacia())
            {
                // ----- Recuperar arbol
                CArbolBB ArbolAux = Cola.Primero() as CArbolBB;
                Cola.Retirar();
                // ----- Procesar raiz

                ColaAcumulativa.PonerEnCola(ArbolAux.Raiz);
                // ----- Agregar hijos a la cola, si existen
                if (ArbolAux.SubArbolIzq != null)
                    Cola.PonerEnCola(ArbolAux.SubArbolIzq);
                if (ArbolAux.SubArbolDer != null)
                    Cola.PonerEnCola(ArbolAux.SubArbolDer);
                // ----- Recorrer Cola
                RecorrerCola(Cola, ColaAcumulativa);
            }

        }

        /* -------------------------------------------------------------- */
        public CCola? GenerarColaDeElementos()
        {
            if (aRaiz != null)
            {
                CCola colaAcumulativa = CCola.Crear();
                //-----Crear Cola
                CCola Cola = new();
                // ----- Agregar Raiz a la cola
                Cola.PonerEnCola(this);
                // ----- Recorrer Cola
                RecorrerCola(Cola, colaAcumulativa);
                return colaAcumulativa;
            }
            return null;
            /* -------------------------------------------------------------- */

            #endregion Metodos
        }
        /* -------------------------------------------------------------- */
        public int NroNodos()
        {
            if (EstaVacio())
                return 0;
            else
                return 1 + (aSubArbolIzq == null ? 0 : aSubArbolIzq.NroNodos()) + (aSubArbolDer == null ? 0 : aSubArbolDer.NroNodos());
        }
        /* -------------------------------------------------------------- */
    }
}