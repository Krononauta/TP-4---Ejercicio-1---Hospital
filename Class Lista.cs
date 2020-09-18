using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4___Ejercicio_1___Hospital
{
    class Class_Lista
    {

        public Nodo NodoInicial = null;

        public void AgregarAlPrincipio(string nombre, string apellido, string direcion, string telefono)
        {
            Nodo nodo = new Nodo();
            nodo.Codigo = ProximoNumero();
            nodo.Nombre = nombre;
            nodo.Apellido = apellido;
            nodo.Direccion = direcion;
            nodo.Telefono = telefono;

            if (NodoInicial == null)
                NodoInicial = nodo;
            else
            {
                //si hay elementos en la lista, tenemos que agregarlo entre el inicial y el siguiente

                Nodo aux = NodoInicial;
                NodoInicial = nodo;
                NodoInicial.Siguiente = aux;

            }

        }

        public void AgregarAlFinal(string nombre, string apellido, string direcion, string telefono)
        {
            Nodo nodo = new Nodo();
            nodo.Codigo = ProximoNumero();
            nodo.Nombre = nombre;
            nodo.Apellido = apellido;
            nodo.Direccion = direcion;
            nodo.Telefono = telefono;

            //necesito buscar el último para agregarlo al final
            Nodo ultimo = BuscarUltimo(NodoInicial);
            ultimo.Siguiente = nodo;
        }

        public void ActualizarNodo(int codigo, string nombre, string apellido, string direcion, string telefono)
        {
            Nodo nodo = new Nodo();
            /* nodo.Codigo = ProximoNumero();*/
            nodo = BuscarNodo(NodoInicial, codigo);
            nodo.Nombre = nombre;
            nodo.Apellido = apellido;
            nodo.Direccion = direcion;
            nodo.Telefono = telefono;
            /*

            if (NodoInicial == null)
                NodoInicial = nodo;
            else
            {
                //si hay elementos en la lista, tenemos que agregarlo entre el inicial y el siguiente
                Nodo aux = NodoInicial;
                NodoInicial = nodo;
                NodoInicial.Siguiente = aux;
            }*/
        }

        private Nodo BuscarNodo(Nodo nodo, int numero)
        {
            if (nodo.Siguiente != null && nodo.Codigo == numero)
                return nodo;
            if (nodo.Siguiente != null)
                return BuscarNodo(nodo.Siguiente, numero);
            return null; //es el ultimo..
        }

        private int BuscarMaximo(Nodo nodo, int codigo)
        {
            int max = nodo.Codigo > codigo ? nodo.Codigo : codigo;
            if (nodo.Siguiente != null) //no es el ultimo
            {
                return BuscarMaximo(nodo.Siguiente, max);
            }
            else
            {
                return max;
            }


        }

        private int ProximoNumero()
        {
            if (NodoInicial == null) return 1;
            int max = BuscarMaximo(NodoInicial, NodoInicial.Codigo);

            //busco el maximo y le sumo uno

            return max + 1;

        }
        private Nodo BuscarUltimo(Nodo nodo)
        {
            //la lista este vacia
            if (nodo == null) return null;

            //que no sea el ultimo
            if (nodo.Siguiente != null)
                return BuscarUltimo(nodo.Siguiente);
            else
                return nodo;

        }


        public void QuitarPrimero()
        {
            //par aquitar el primero, necesito usar una variable temporal
            //la lista este vacia
            if (NodoInicial != null)
            {
                NodoInicial = NodoInicial.Siguiente;
            }
        }

        public void QuitarUltimo()
        {
            //necesitamos buscar el anteultimo
            Nodo anteultimo = BuscarAnteultimo(NodoInicial);


            if (anteultimo != null)
                anteultimo.Siguiente = null;
            else
                NodoInicial = null;

        }

        private Nodo BuscarAnteultimo(Nodo nodo)
        {
            if (nodo == null) return null; //lista vacia



            if (nodo.Siguiente == null) return null; //hay un solo elemento

            if (nodo.Siguiente.Siguiente != null)
                return BuscarAnteultimo(nodo.Siguiente);
            else
                return nodo;

        }


        private Nodo BuscarAnterior(Nodo nodo, int numero)
        {


            if (nodo.Siguiente != null && nodo.Siguiente.Codigo == numero)
                return nodo;
            if (nodo.Siguiente != null)
                return BuscarAnterior(nodo.Siguiente, numero);
            return null; //es el ultimo...


        }



        public void QuitarPosicion(int numero)
        {
            if (NodoInicial != null)
            {
                //si el primero es el que se quiere borrar
                if (NodoInicial.Codigo == numero)
                {
                    QuitarPrimero();
                }
                else
                {
                    // si el ultimo es elq ue se quiere borrar
                    Nodo ultimo = BuscarUltimo(NodoInicial);
                    if (ultimo != null && ultimo.Codigo == numero)
                        QuitarUltimo();
                    else
                    { //si se quiere borrar un nodo intermedio
                        Nodo nodoAnteriorAlElegido = BuscarAnterior(NodoInicial, numero);
                        if (nodoAnteriorAlElegido != null)
                            nodoAnteriorAlElegido.Siguiente = nodoAnteriorAlElegido.Siguiente.Siguiente;
                    }
                }
            }


        }

     
    }
}
