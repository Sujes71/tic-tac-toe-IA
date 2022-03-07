using System;
using System.Collections.Generic;
using System.Text;

namespace _3EnRayaDefinitivo
{
    class Jugador
    {
        private string nombre;
        private const int valor = 1;
        private const char signo = 'X';
        public Jugador(string nombre)
        {
            this.nombre = nombre;
        }
        public string getNombre()
        {
            return nombre;
        }
        public int getValor()
        {
            return valor;
        }
        public char getSigno()
        {
            return signo;
        }
    }
}
