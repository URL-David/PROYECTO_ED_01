using System;
using System.Collections.Generic;
using System.Text;

namespace GenericosLibreria.Estruturas
{
   public class ArbolAVLRepetidos<T> where T : IComparable
    {
        NodoLista<T> Raiz = new NodoLista<T>();
        public void Add(T Valor, Delegate delegado)
        {
            Insertar(Valor, delegado, Raiz);
            Raiz = Balancear(Raiz);
        }
        public List<T> Get(T Valor, Delegate Delegado)
        {
            return Obtener(Valor, Delegado);
        }
        public List<T> Mostrar()
        {
            List<T> ListaArbol = new List<T>();
            MostrarRaiz(Raiz, ListaArbol);
            return ListaArbol;
        }

        private void MostrarRaiz(NodoLista<T> NodoRaiz, List<T> Lista)
        {
            if (NodoRaiz.Valor != null)
            {
                MostrarRaiz(NodoRaiz.Izquierda, Lista);
                foreach (var item in NodoRaiz.Valor)
                    Lista.Add(item);
                MostrarRaiz(NodoRaiz.Derecha, Lista);
            }
        }

        private List<T> Obtener(T Valor, Delegate Delegado)
        {
            NodoLista<T> NodoPivote = Raiz;
            while (NodoPivote.Valor != null)
            {
                if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoPivote.Valor[0])) == 1)
                    if (NodoPivote.Derecha.Valor != null)
                        NodoPivote = NodoPivote.Derecha;
                    else
                        return default;

                else if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoPivote.Valor[0])) == -1)
                    if (NodoPivote.Izquierda.Valor != null)
                        NodoPivote = NodoPivote.Izquierda;
                    else
                        return default;
                else if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoPivote.Valor[0])) == 0)
                    return NodoPivote.Valor;
                else
                    return default;
            }
            return default;
        }

        private void ActualizarAltura(NodoLista<T> NodoRaiz)
        {
            NodoRaiz.AlturaIzquierda = 0;
            NodoRaiz.AlturaDerecha = 0;
            NodoRaiz.Equilibrio = 0;
            if (NodoRaiz.Izquierda.Valor != null)
            {
                ActualizarAltura(NodoRaiz.Izquierda);
                if (NodoRaiz.Izquierda.Valor != null)
                {
                    NodoRaiz.AlturaIzquierda = Math.Max(NodoRaiz.Izquierda.AlturaDerecha, NodoRaiz.Izquierda.AlturaIzquierda) + 1;
                    NodoRaiz.Equilibrio = NodoRaiz.AlturaDerecha - NodoRaiz.AlturaIzquierda;
                }
            }
            if (NodoRaiz.Derecha.Valor != null)
            {
                ActualizarAltura(NodoRaiz.Derecha);
                if (NodoRaiz.Derecha.Valor != null)
                {
                    NodoRaiz.AlturaDerecha = Math.Max(NodoRaiz.Derecha.AlturaDerecha, NodoRaiz.Derecha.AlturaIzquierda) + 1;
                    NodoRaiz.Equilibrio = NodoRaiz.AlturaDerecha - NodoRaiz.AlturaIzquierda;
                }
            }
        }

        //ROTACIONES
        private NodoLista<T> Balancear(NodoLista<T> NodoRaiz)
        {
            //Rotacion Doble a al Inzquierda(+2,-1)
            if (NodoRaiz.Equilibrio == 2 && NodoRaiz.Derecha.Equilibrio == -1)
            {
                //Rotacion Derecha, luego Rotacion Izquierda(2,-1)
                NodoLista<T> NodoSust1 = NodoRaiz.Derecha;
                NodoLista<T> NodoSust2 = NodoRaiz.Derecha.Izquierda;
                NodoSust1.Izquierda = NodoSust2.Derecha;
                NodoRaiz.Derecha = NodoSust2;
                NodoSust2.Derecha = NodoSust1;
            }
            //Rotacion Doble a al Derecha(-2,+1)
            else if (NodoRaiz.Equilibrio == -2 && NodoRaiz.Izquierda.Equilibrio == 1)
            {
                //Rotacion Izquierda, luego Rotacion Derecha
                NodoLista<T> NodoSust1 = NodoRaiz.Izquierda;
                NodoLista<T> NodoSust2 = NodoRaiz.Izquierda.Derecha;
                NodoSust1.Derecha = NodoSust2.Izquierda;
                NodoRaiz.Izquierda = NodoSust2;
                NodoSust2.Izquierda = NodoSust1;
            }
            //Rotacion Simple a la Izquierda
            if (NodoRaiz.Equilibrio == 2)
            {
                NodoLista<T> NodoAux1 = NodoRaiz.Derecha;
                NodoLista<T> NodoAux2 = NodoRaiz.Derecha.Izquierda;
                NodoRaiz.Derecha = NodoAux2;
                NodoAux1.Izquierda = NodoRaiz;
                ActualizarAltura(NodoAux1);
                NodoRaiz = NodoAux1;
            }
            //Rotacion Simple a la Derecha
            else if (NodoRaiz.Equilibrio == -2)
            {
                NodoLista<T> NodoAux1 = NodoRaiz.Izquierda;
                NodoLista<T> NodoAux2 = NodoRaiz.Izquierda.Derecha;
                NodoRaiz.Izquierda = NodoAux2;
                NodoAux1.Derecha = NodoRaiz;
                ActualizarAltura(NodoAux1);
                NodoRaiz = NodoAux1;
            }
            return NodoRaiz;
        }

        private void Insertar(T Valor, Delegate Delegado, NodoLista<T> NodoRaiz)
        {
            NodoRaiz.Equilibrio = 0;
            if (NodoRaiz.Valor == null)
            {
                NodoRaiz.Valor = new List<T> { Valor };
                NodoRaiz.Izquierda = new NodoLista<T>();
                NodoRaiz.Derecha = new NodoLista<T>();
            }
            else if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == 1)
            {
                NodoRaiz.AlturaDerecha = 0;
                Insertar(Valor, Delegado, NodoRaiz.Derecha);
                NodoRaiz.Derecha = Balancear(NodoRaiz.Derecha);
                if (NodoRaiz.Derecha.Valor != null)
                {
                    NodoRaiz.AlturaDerecha = Math.Max(NodoRaiz.Derecha.AlturaDerecha, NodoRaiz.Derecha.AlturaIzquierda) + 1;
                }
            }
            else if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == -1)
            {
                NodoRaiz.AlturaIzquierda = 0;
                Insertar(Valor, Delegado, NodoRaiz.Izquierda);
                NodoRaiz.Izquierda = Balancear(NodoRaiz.Izquierda);
                if (NodoRaiz.Izquierda.Valor != null)
                {
                    NodoRaiz.AlturaIzquierda = Math.Max(NodoRaiz.Izquierda.AlturaDerecha, NodoRaiz.Izquierda.AlturaIzquierda) + 1;
                }
            }
            else if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == 0)
            {
                NodoRaiz.Valor.Add(Valor);
            }
            NodoRaiz.Equilibrio = NodoRaiz.AlturaDerecha - NodoRaiz.AlturaIzquierda;
        }
        public void Editar(T Valor, Delegate Delegado1, Delegate Delegado2)
        {
            BuscarEditar(Raiz, Delegado1, Delegado2, Valor);
        }
        private void BuscarEditar(NodoLista<T> NodoRaiz, Delegate Delegado1, Delegate Delegado2, T Valor)
        {
            if (NodoRaiz.Valor == null)
                return;
            else if (Convert.ToInt32(Delegado1.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == 0)
                for (int i = 0; i < NodoRaiz.Valor.Count; i++)
                {
                    if (Convert.ToInt32(Delegado2.DynamicInvoke(Valor, NodoRaiz.Valor[i])) == 0)
                        NodoRaiz.Valor[i] = Valor;
                }
            else if (Convert.ToInt32(Delegado1.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == 1)
                BuscarEditar(NodoRaiz.Derecha, Delegado1, Delegado2, Valor);
            else if (Convert.ToInt32(Delegado1.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == -1)
                BuscarEditar(NodoRaiz.Izquierda, Delegado1, Delegado2, Valor);
        }
        public List<T> Filtrar(Delegate Delegado, T Valor)
        {
            List<T> ListaResultado = new List<T>();
            FiltrarRaiz(Raiz, ListaResultado, Delegado, Valor);
            return ListaResultado;
        }
        private void FiltrarRaiz(NodoLista<T> NodoRaiz, List<T> Lista, Delegate Delegado, T Valor)
        {
            if (NodoRaiz.Valor != null)
            {
                if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == 0)
                    foreach (var item in NodoRaiz.Valor)
                        Lista.Add(item);
                FiltrarRaiz(NodoRaiz.Izquierda, Lista, Delegado, Valor);
                FiltrarRaiz(NodoRaiz.Derecha, Lista, Delegado, Valor);
            }
        }

        public bool ExiteValor(T Valor, Delegate Delegado)
        {
            return RecoridoExiste(Valor, Delegado, Raiz);
        }
        //True= Existe el Valor
        //False = No Existe el Valor
        private bool RecoridoExiste(T Valor, Delegate Delegado, NodoLista<T> NodoRaiz)
        {
            if (NodoRaiz.Valor == null)
                return false;
            else if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == 1)
                return RecoridoExiste(Valor, Delegado, NodoRaiz.Derecha);
            else if (Convert.ToInt32(Delegado.DynamicInvoke(Valor, NodoRaiz.Valor[0])) == -1)
                return RecoridoExiste(Valor, Delegado, NodoRaiz.Izquierda);
            else
                return true;
        }

    }
}
