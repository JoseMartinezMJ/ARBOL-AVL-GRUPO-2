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
        public Arbol_AVL Insertar (int ClaveNueva, Arbol_AVL Raiz)//Funcion que inserta las claves aleatoria a los nodos
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
            //Falta terminar la funcion 11/6/2022
             //Realiza las rotaciones simples o dobles segun el caso
            if (Alturas(Raiz.NodoIzquierdo) - Alturas(Raiz.NodoDerecho) == 2)
            {
                if (ClaveNueva < Raiz.NodoIzquierdo.Clave)
                    Raiz = RotacionIzquierdaSimple(Raiz);
                else
                    Raiz = RotacionIzquierdaDoble(Raiz);
            }
            if (Alturas(Raiz.NodoDerecho) - Alturas(Raiz.NodoIzquierdo) == 2)
            {
                if (ClaveNueva > Raiz.NodoDerecho.Clave)
                    Raiz = RotacionDerechaSimple(Raiz);
                else
                    Raiz = RotacionDerechaDoble(Raiz);
            }
            Raiz.Altura = max(Alturas(Raiz.NodoIzquierdo), Alturas(Raiz.NodoDerecho)) + 1;
            return Raiz;
        }
        //FUNCIONES PARA ROTACIONES
        //Función para obtener que rama es mayor
        private static int max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        private static int Alturas(Arbol_AVL Raiz)
        {
            return Raiz == null ? -1 : Raiz.Altura;
        }
        //Seccion de funciones de rotaciones
        //Rotacion Izquierda Simple
        private static Arbol_AVL RotacionIzquierdaSimple(Arbol_AVL k2)
        {
            Arbol_AVL k1 = k2.NodoIzquierdo;
            k2.NodoIzquierdo = k1.NodoDerecho;
            k1.NodoDerecho = k2;
            k2.Altura = max(Alturas(k2.NodoIzquierdo), Alturas(k2.NodoDerecho)) + 1;
            k1.Altura = max(Alturas(k1.NodoIzquierdo), k2.Altura) + 1;
            return k1;
        }
        //Rotacion Derecha Simple
        private static Arbol_AVL RotacionDerechaSimple(Arbol_AVL k1)
        {
            Arbol_AVL k2 = k1.NodoDerecho;
            k1.NodoDerecho = k2.NodoIzquierdo;
            k2.NodoIzquierdo = k1;
            k1.Altura = max(Alturas(k1.NodoIzquierdo), Alturas(k1.NodoDerecho)) + 1;
            k2.Altura = max(Alturas(k2.NodoDerecho), k1.Altura) + 1;
            return k2;
        }
        //Doble Rotacion Izquierda
        private static Arbol_AVL RotacionIzquierdaDoble(Arbol_AVL k3)
        {
            k3.NodoIzquierdo = RotacionDerechaSimple(k3.NodoIzquierdo);
            return RotacionIzquierdaSimple(k3);
        }
        //Doble Rotacion Derecha
        private static Arbol_AVL RotacionDerechaDoble(Arbol_AVL k1)
        {
            k1.NodoDerecho = RotacionIzquierdaSimple(k1.NodoDerecho);
            return RotacionDerechaSimple(k1);
        }
        //MODIFICACION 11/7/20222
        
    }
}
