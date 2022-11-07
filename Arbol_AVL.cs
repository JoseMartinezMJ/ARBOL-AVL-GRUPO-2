using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_AVL
{
    public class Arbol_AVL
    {
        //VARIABLES DE LA CLASE ARBOL_AVL
        public int Clave;//Variable que almacena la clave principal aleatoria del arbol.
        public int Altura;//Variable que almacena la altura del arbol.

        //NODOS DE LA CLASE ARBOL_AVL
        public Arbol_AVL NodoPadre;//Variable de tipo objeto que almacena el nodo padre del arbol.
        public Arbol_AVL NodoIzquierdo;//Variable de tipo objeto que almacena el nodo hijoIzquierdo del arbol.
        public Arbol_AVL NodoDerecho;//Variable de tipo objeto que almacena el nodo hijoDerecho del arbol.

        //CONSTRUCTORES DE LA CLASE ARBOL_AVL
        public Arbol_AVL()
        {
            //Contructor vacio.
        }
        public Arbol_AVL(int ClaveNueva, Arbol_AVL Padre, Arbol_AVL Izquiero, Arbol_AVL Derecho)//Contructor que da valores a los objetos
        {
            Clave = ClaveNueva;
            NodoPadre = Padre;
            NodoIzquierdo = Izquiero;
            NodoDerecho = Derecho;
            Altura = 0;
        }

        //FUNCIONES DE LA CLASE ARBOL_AVL
        public Arbol_AVL Insertar (int ClaveNueva, Arbol_AVL Raiz)
        {
            if (Raiz == null)
            {
                Raiz = new Arbol_AVL(ClaveNueva, null, null, null);//Crea un nuevo nodo o un espacio de memoria cada vez que se utiliza la funcion de insertar.
            }
            else if (ClaveNueva < Raiz.Clave)
            {
                Raiz.NodoIzquierdo = Insertar(ClaveNueva, Raiz.NodoIzquierdo);//Crea o inserta un nodo a la izquierda.
            }
            else if (ClaveNueva > Raiz.Clave)
            {
                Raiz.NodoDerecho = Insertar(ClaveNueva,Raiz.NodoDerecho);//Crea o inserta un nodo a la derecha.
            }
            else
            {
                MessageBox.Show("Valor Existente en el Arbol", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
