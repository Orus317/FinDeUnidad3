namespace EstructurasDeDatos
{
    public class CCola
    {
        #region *************  ATRIBUTOS    **************** 
        private object aElemento;
        private CCola aSubCola;
        #endregion ATRIBUTOS

        #region *************  CONSTRUCTORES    **************** 
        public CCola()
        {
            aElemento = null;
            aSubCola = null;
        }
        /* -------------------------------------------- */
        public CCola(object pElemento, CCola pSubCola)
        {
            aElemento = pElemento;
            aSubCola = pSubCola;
        }
        #endregion CONSTRUCTORES

        #region ***********  METODOS ESTATICOS   *************
        public static CCola Crear()
        {
            return new CCola();
        }
        /* -------------------------------------------- */
        public static CCola Crear(object pElemento, CCola pSubCola)
        {
            return new CCola(pElemento, pSubCola);
        }
        #endregion METODOS ESTATICOS
        #region ***********  PROPIEDADES   *************
        private object Elemento
        {
            get
            {
                return aElemento;
            }
            set
            {
                aElemento = value;
            }
        }
        /* --------------------------------------------- */
        private CCola SubCola
        {
            get
            {
                return aSubCola;
            }
            set
            {
                aSubCola = value;
            }
        }
        #endregion PROPIEDADES

        #region ***********  OTROS METODOS  *************     
        /* --------------------------------------------- */
        public bool EsVacia()
        {
            return ((aElemento == null) && (aSubCola == null));
        }

        /* --------------------------------------------- */
        public object Primero()
        {
            return aElemento;
        }

        /* --------------------------------------------- */
        public void PonerEnCola(object pElemento)
        {
            if (EsVacia())
            {
                aSubCola = new CCola();
                aElemento = pElemento;
            }
            else
                aSubCola.PonerEnCola(pElemento);
        }

        /* --------------------------------------------- */
        public void Retirar()
        {
            if (!EsVacia())
            {
                aElemento = aSubCola.Elemento;
                aSubCola = aSubCola.SubCola;
            }
        }
        #endregion OTROS METODOS

    }
}
