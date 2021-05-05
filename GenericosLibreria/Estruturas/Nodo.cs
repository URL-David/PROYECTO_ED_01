using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericosLibreria.Estruturas
{
    public class Nodo<T>
    {
        public Nodo<T> Izquierda { get; set; }
        public Nodo<T> Derecha { get; set; }
        public T Valor { get; set; }
        public int Posicion { get; set; }
        public int Equilibrio { get; set; }
        public int AlturaDerecha { get; set; }
        public int AlturaIzquierda { get; set; }
    }
}
