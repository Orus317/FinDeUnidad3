namespace EstructurasDeDatos
{
    public class CArbolAVL : CArbolBB
    {
        #region ***********************  Atributos   *************************
        private int aFE; // -- Factor de equilibrio, necesario para determinar si un nodo está o no balanceado
        #endregion Atributos  

        #region  ======================  Constructores  ======================= 
        /* -------------------------------------------------------------- */
        public CArbolAVL() : base()
        {
            aFE = 0;
        }

        /* -------------------------------------------------------------- */
        public CArbolAVL(Object pRaiz) : base(pRaiz)
        {
            aFE = 0;
        }

        /* -------------------------------------------------------------- */
        public CArbolAVL(CArbolAVL pSubArbolIzq, Object pRaiz, CArbolAVL pSubArbolDer)
            : base(pSubArbolIzq, pRaiz, pSubArbolDer)
        {
            aFE = 0;
        }


        /* -------------------------------------------------------------- */
        public static CArbolAVL CrearAVL()
        {
            return new CArbolAVL();
        }

        /* -------------------------------------------------------------- */
        public static CArbolAVL CrearAVL(Object pRaiz)
        {
            return new CArbolAVL(pRaiz);
        }

        /* -------------------------------------------------------------- */
        public static CArbolAVL CrearAVL(CArbolAVL pSubArbolIzq, Object pRaiz, CArbolAVL pSubArbolDer)
        {
            return new CArbolAVL(pSubArbolIzq, pRaiz, pSubArbolDer);
        }
        #endregion Constructores

        #region *********************  Propiedades  ***********************
        /* ---------------------------------------------------------- */
        public int FE
        {
            get
            {
                return aFE;
            }
            set
            {
                aFE = value;
            }
        }

        #endregion *********************  Propiedades  ***********************

        #region ====================   Metodos    ====================== 

        /* -------------------------------------------------------------- */
        /*
			private bool EstaBalanceado()
			{
				int Altura1 = (SubArbolIzq==null ? 0 :1+SubArbolIzq.Altura()); 
				int Altura2 = (SubArbolDer==null ? 0 :1+SubArbolDer.Altura()); 
				return (Math.Abs(Altura1-Altura2)<2);
			}
        */
        #region Metodos trascendentales
        /* -------------------------------------------------------------- */
        protected void RotacionSimpleIzq(bool FlagFE = true)
        {
            // La rotación se efectuara primero creando un nuevo arbol y reordenando los enlaces de los arboles
            SubArbolDer = CArbolAVL.CrearAVL(SubArbolIzq.SubArbolDer as CArbolAVL, Raiz, SubArbolDer as CArbolAVL);
            Raiz = SubArbolIzq.Raiz;
            SubArbolIzq = SubArbolIzq.SubArbolIzq;
            // -- Actualizar FE
            if (FlagFE)
            {
                FE = 0; // -- El nodo donde se realizaó la rotación, está balanceado
                (SubArbolDer as CArbolAVL).FE = 0; // -- El nodo rotado también está balanceado
            }
        }

        /* -------------------------------------------------------------- */
        protected void RotacionDobleIzq(Object Elemento)
        {
            // -- Determinar condicones para actualizar FE
            bool FlagHoja = SubArbolIzq.SubArbolDer.EsHoja();
            bool FlagIzqDerIzq = false;
            if (!FlagHoja)
                FlagIzqDerIzq = (Elemento.ToString().CompareTo(SubArbolIzq.SubArbolDer.Raiz.ToString()) < 0);
            // -- Efectuar rotaciones
            ((CArbolAVL)SubArbolIzq).RotacionSimpleDer(false);
            RotacionSimpleIzq(false);
            // -- Actualizar factor de equilibrio
            FE = 0; // -- El nodo donde se efectúa la rotación está balanceado
            if (FlagHoja)
                (SubArbolDer as CArbolAVL).FE = 0;
            else if (FlagIzqDerIzq)
            {
                (SubArbolIzq as CArbolAVL).FE = 0;
                (SubArbolDer as CArbolAVL).FE = 1;
            }
            else
            {
                (SubArbolIzq as CArbolAVL).FE = -1;
                (SubArbolDer as CArbolAVL).FE = 0;
            }
        }

        /* -------------------------------------------------------------- */
        protected void RotacionSimpleDer(bool FlagFE = true)
        {
            // La rotación se efectuara primero creando un nuevo arbol y reordenando los enlaces de los arboles
            SubArbolIzq = CArbolAVL.CrearAVL(SubArbolIzq as CArbolAVL, Raiz, SubArbolDer.SubArbolIzq as CArbolAVL);
            Raiz = SubArbolDer.Raiz;
            aFE = 0;
            SubArbolDer = SubArbolDer.SubArbolDer;
            // -- Actualizar FE
            if (FlagFE)
            {
                FE = 0; // -- El nodo donde se realizaó la rotación, está balanceado
                (SubArbolIzq as CArbolAVL).FE = 0; // -- El nodo rotado también está balanceado
            }
        }

        /* -------------------------------------------------------------- */
        protected void RotacionDobleDer(Object Elemento)
        {
            // -- Determinar condicones para actualizar FE
            bool FlagHoja = SubArbolDer.SubArbolIzq.EsHoja();
            bool FlagDerIzqDer = false;
            if (!FlagHoja)
                FlagDerIzqDer = (Elemento.ToString().CompareTo(SubArbolDer.SubArbolIzq.Raiz.ToString()) > 0);
            // -- Efectuar rotaciones
            ((CArbolAVL)SubArbolDer).RotacionSimpleIzq(false);
            RotacionSimpleDer(false);
            // -- Actualizar factor de equilibrio
            FE = 0; // -- El nodo donde se efectúa la rotación está balanceado
            if (FlagHoja)
                (SubArbolIzq as CArbolAVL).FE = 0;
            else if (FlagDerIzqDer)
            {
                (SubArbolIzq as CArbolAVL).FE = -1;
                (SubArbolDer as CArbolAVL).FE = 0;
            }
            else
            {
                (SubArbolIzq as CArbolAVL).FE = 0;
                (SubArbolDer as CArbolAVL).FE = 1;
            }
        }

        /* -------------------------------------------------------------- */
        #endregion
        public int Agregar(object Elemento)
        {
            int Ind = 0;
            if (Raiz == null)
                Raiz = Elemento;
            else
                if (Elemento.ToString().CompareTo(Raiz.ToString()) < 0)
            {   // Agregar el nuevo elemento como hijo Izq
                if (SubArbolIzq == null)
                {
                    SubArbolIzq = CArbolAVL.CrearAVL(null, Elemento, null);
                    aFE--;
                    Ind = 1;
                }
                else
                {
                    Ind = (SubArbolIzq as CArbolAVL).Agregar(Elemento);
                    if (Ind != 0)
                    {
                        aFE -= Ind;
                        // Balancear arbol si esta desbalanceado 
                        if (aFE == -2) // Si el Factor de equilibrio es -2 entonces hay desbalance
                        {
                            if (Elemento.ToString().CompareTo(SubArbolIzq.Raiz.ToString()) < 0)
                                RotacionSimpleIzq();
                            else
                                RotacionDobleIzq(Elemento);
                            Ind = 0;
                        }
                    }
                }
            }
            else
            {   // Agregar el nuevo elemento como hijo Der
                if (SubArbolDer == null)
                {
                    SubArbolDer = CArbolAVL.CrearAVL(null, Elemento, null);
                    aFE++;
                    Ind = 1;
                }
                else
                {
                    Ind = (SubArbolDer as CArbolAVL).Agregar(Elemento);
                    if (Ind != 0)
                    {
                        aFE++;
                        // Balancear arbol si esta desbalanceado 
                        if (aFE == 2)
                        {
                            if (Elemento.ToString().CompareTo(SubArbolDer.Raiz.ToString()) > 0)
                                RotacionSimpleDer();
                            else
                                RotacionDobleDer(Elemento);
                            Ind = 0;
                        }
                    }
                }
            }
            return Ind;
        }

        public void PreOrdenFE()
        {
            if (Raiz != null)
            {
                // ----- Procesar la raiz
                Console.WriteLine(Raiz.ToString() + "- " + aFE.ToString());
                // ----- Procesar hijo Izq 
                if (SubArbolIzq != null)
                    (SubArbolIzq as CArbolAVL).PreOrdenFE();
                // ----- Procesar hijo Der 
                if (SubArbolDer != null)
                    (SubArbolDer as CArbolAVL).PreOrdenFE();
            }
        }
        #endregion 
    }
}
