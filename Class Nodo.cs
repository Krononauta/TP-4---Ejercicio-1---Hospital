using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4___Ejercicio_1___Hospital
{
    public class Nodo
    {
        public int Codigo;
        public string Nombre;
        public string Apellido;
        public string Direccion;
        public string Telefono;
        public Nodo Siguiente;

        public override string ToString()
        {
            return string.Format("{0} || {1} || {2} || {3} || {4}", Codigo, Nombre, Apellido, Direccion, Telefono);
        }


    }

}
