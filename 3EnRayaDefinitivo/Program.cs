
using System;

namespace _3EnRayaDefinitivo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Juego j1 = new Juego();
            j1.tableroVisual();
            j1.jugada();
            Console.ReadLine();
        }
    }
}
