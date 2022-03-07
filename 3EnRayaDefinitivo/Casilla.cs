using System;
using System.Collections.Generic;
using System.Text;

namespace _3EnRayaDefinitivo
{
    class Casilla
    {
        private char signo;
        private int valor;
        public Casilla()
        {
            signo = ' ';
            valor = 0;
        }
        public char getSigno()
        {
            return signo;
        }
        public int getValor()
        {
            return valor;
        }
        public void setSigno(char signo)
        {
            this.signo = signo;
        }
        public void setValor(int valor)
        {
            this.valor = valor;
        }
        public bool estaVacio()
        {
            if(valor == 0)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return string.Format("El valor es " + valor);
        }
    }
}
