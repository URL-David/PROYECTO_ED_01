using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_ED_01.GenericosLibreria.Estruturas
{
    public class TablaHash<T>
    {
        private T[] Tabla = new T[50];

        public void Añadir(T Valor, int Posicion)
        {
            Tabla[Posicion] = Valor;
        }
        public T Buscar(int Posicion)
        {
            if (Tabla[Posicion] != null)
                return Tabla[Posicion];
            else
                return default(T);
        }
        public void Borrar(int Posicion)
        {
            Tabla[Posicion] = default(T);
        }
        public T[] Mostrar()
        {
            T[] AuxLista = new T[50];
            for (int i = 0; i < 50; i++)
            {
                if (Tabla[i] == null)
                    AuxLista[i] = default(T);
                else
                    AuxLista[i] = Tabla[i];
            }
            return AuxLista;
        }
    }
}
