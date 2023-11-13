namespace Entidades.Modelos
{
    public delegate bool DelegadoBuscador<T>(T objeto);
    /// <summary>
    /// Clase que representa una lista enlazada de nodos
    /// </summary>
    public class ListaEnlazada<T> where T : class
    {
        private Nodo<T>? primerNodo;

        public int CantidadDeElementos
        {
            get { return GetCantidadElementos(); }
        }

        private int UltimoIndice
        {
            get
            {
                return CantidadDeElementos - 1;
            }
        }

        public T? this[int index]
        {
            get
            {
                Nodo<T>? nodo = ObtenerNodo(index);

                if (nodo is null)
                {
                    throw new IndexOutOfRangeException("Indice fuera de rango");
                }

                return nodo.Elemento;
            }
        }

        private int GetCantidadElementos()
        {
            Nodo<T>? nodo = this.primerNodo;
            int cantidad = 0;
            while (nodo is not null)
            {
                cantidad++;
                nodo = nodo.SiguienteNodo;
            }

            return cantidad;
        }

        /// <summary>
        /// Devuelve el nodo en la posicion indicada
        /// </summary>
        /// <param name="index"></param>
        /// <returns>El nodo en la posicion indicada o null</returns>
        private Nodo<T>? ObtenerNodo(int index)
        {
            //? Si el indice es menor a 0 o mayor a la cantidad de elementos, devuelve null
            if (index <= -1 || index > CantidadDeElementos)
            {
                return null; 
            }

            Nodo<T>? nodo = primerNodo;
            if (index == 0)
            {
                return nodo;
            }

            int i = 1;
            nodo = nodo.SiguienteNodo;

            // Recorre la lista hasta encontrar el nodo en la posicion indicada
            while (nodo is not null && i != index)
            {
                i++;
                nodo = nodo.SiguienteNodo;
            }

            return nodo;
        }

        /// <summary>
        /// Agrega un elemento al final de la lista
        /// </summary>
        public void AgregarElemento(T elemento)
        {
            Nodo<T>? nuevoNodo = new();
            nuevoNodo.Elemento = elemento;

            if (primerNodo is not null)
            {
                Nodo<T>? ultimoNodo = ObtenerNodo(UltimoIndice);
                ultimoNodo.SiguienteNodo = nuevoNodo;
            }
            else
            {
                primerNodo = nuevoNodo;
            }
        }

        /// <summary>
        /// Busca un elemento en la lista
        /// </summary>
        public T? Buscar(DelegadoBuscador<T> buscador)
        {
            Nodo<T>? nodo = primerNodo;

            while (nodo is not null)
            {
                if (buscador(nodo.Elemento))
                {
                    return nodo.Elemento;
                }

                nodo = nodo.SiguienteNodo;
            }

            return default;
        }

        public int IndiceDe(DelegadoBuscador<T> buscador)
        {
            Nodo<T>? nodo = primerNodo;
            int index = -1;
            int posicion = 0;

            while (nodo is not null)
            {
                if (buscador(nodo.Elemento))
                {
                    index = posicion;
                    return index;
                }

                posicion++;
                nodo = nodo.SiguienteNodo;
            }

            return index;
        }
    }
}