using System;
using System.Collections.Generic;
using System.Text;

namespace GenericosLibreria.Estruturas
{
    public class NodoLista<T>
    {
        public NodoLista<T> Izquierda { get; set; }
        public NodoLista<T> Derecha { get; set; }
        public List<T> Valor { get; set; }
        public int AlturaDerecha { get; set; }
        public int AlturaIzquierda { get; set; }
        public int Equilibrio { get; set; }
    }
}
