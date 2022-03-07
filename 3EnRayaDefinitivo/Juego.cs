using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _3EnRayaDefinitivo
{
    class Juego
    {
        private Jugador j1;
        private IA j2;
        private Casilla[,] c;
        private int turno;
        public Juego()
        {
            j1 = new Jugador("Jesus");
            j2 = new IA();
            c = new Casilla[3, 3];
            turno = 0;
            iniciarlizarArray();
        }
        public void iniciarlizarArray()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    c[i, j] = new Casilla();
                }
            }
        }
        public void tableroVisual()
        {
            string tv;
            Console.WriteLine("   TRES EN RAYA");
            Console.WriteLine("------------------");
            tv = "    1   2   3" + Environment.NewLine;
            tv += "  ┏━━━┳━━━┳━━━┓" + Environment.NewLine;
            tv += "A ┃ " + c[0, 0].getSigno() + " ┃ " + c[0, 1].getSigno() + " ┃ " + c[0, 2].getSigno() + " ┃" + Environment.NewLine;
            tv += "  ┣━━━╋━━━╋━━━┫" + Environment.NewLine;
            tv += "B ┃ " + c[1, 0].getSigno() + " ┃ " + c[1, 1].getSigno() + " ┃ " + c[1, 2].getSigno() + " ┃" + Environment.NewLine;
            tv += "  ┣━━━╋━━━╋━━━┫" + Environment.NewLine;
            tv += "C ┃ " + c[2, 0].getSigno() + " ┃ " + c[2, 1].getSigno() + " ┃ " + c[2, 2].getSigno() + " ┃" + Environment.NewLine;
            tv += "  ┗━━━┻━━━┻━━━┛" + Environment.NewLine;
            Console.WriteLine(tv);
        }
        public bool puedoGanarFila()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (c[i, j].getValor() == c[i, j + 1].getValor() && c[i, j].getValor() == -1 && c[i, j + 1].getValor() == -1 && c[i, j + 2].getValor() == 0 || c[i, j].getValor() == c[i, j + 2].getValor() && c[i, j].getValor() == -1 && c[i, j + 2].getValor() == -1 && c[i, j + 1].getValor() == 0 || c[i, j + 1].getValor() == c[i, j + 2].getValor() && c[i, j + 1].getValor() == -1 && c[i, j + 2].getValor() == -1 && c[i, j].getValor() == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool puedoGanarColumna()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (c[i, j].getValor() == c[i + 1, j].getValor() && c[i, j].getValor() == -1 && c[i + 1, j].getValor() == -1 && c[i + 2, j].getValor() == 0 || c[i, j].getValor() == c[i + 2, j].getValor() && c[i, j].getValor() == -1 && c[i + 2, j].getValor() == -1 && c[i + 1, j].getValor() == 0 || c[i + 1, j].getValor() == c[i + 2, j].getValor() && c[i + 1, j].getValor() == -1 && c[i + 2, j].getValor() == -1 && c[i, j].getValor() == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool puedoGanarDiagonales()
        {
            //Diagonal 1
            if (c[0, 0].getValor() == c[1, 1].getValor() && c[0, 0].getValor() == -1 && c[1, 1].getValor() == -1 && c[2, 2].getValor() == 0 || c[0, 0].getValor() == c[2, 2].getValor() && c[0, 0].getValor() == -1 & c[2, 2].getValor() == -1 && c[1, 1].getValor() == 0 || c[1, 1].getValor() == c[2, 2].getValor() && c[2, 2].getValor() == -1 & c[1, 1].getValor() == -1 && c[0, 0].getValor() == 0) return true;
            //Diagonal 2
            if (c[2, 0].getValor() == c[1, 1].getValor() && c[2, 0].getValor() == -1 && c[1, 1].getValor() == -1 && c[0, 2].getValor() == 0 || c[2, 0].getValor() == c[0, 2].getValor() && c[0, 2].getValor() == -1 && c[2, 0].getValor() == -1 && c[1, 1].getValor() == 0 || c[1, 1].getValor() == c[0, 2].getValor() && c[0, 2].getValor() == -1 && c[1, 1].getValor() == -1 && c[2, 0].getValor() == 0) return true;
            return false;
        }
        public bool puedoDefenderDiagonales()
        {
            //Diagonal 1
            if (c[0, 0].getValor() == c[1, 1].getValor() && c[0, 0].getValor() == 1 && c[1, 1].getValor() == 1 && c[2, 2].getValor() == 0 || c[0, 0].getValor() == c[2, 2].getValor() && c[0, 0].getValor() == 1 & c[2, 2].getValor() == 1 && c[1, 1].getValor() == 0 || c[1, 1].getValor() == c[2, 2].getValor() && c[2, 2].getValor() == 1 & c[1, 1].getValor() == 1 && c[0, 0].getValor() == 0) return true;
            //Diagonal 2
            if (c[2, 0].getValor() == c[1, 1].getValor() && c[2, 0].getValor() == 1 && c[1, 1].getValor() == 1 && c[0, 2].getValor() == 0 || c[2, 0].getValor() == c[0, 2].getValor() && c[0, 2].getValor() == 1 && c[2, 0].getValor() == 1 && c[1, 1].getValor() == 0 || c[1, 1].getValor() == c[0, 2].getValor() && c[0, 2].getValor() == 1 && c[1, 1].getValor() == 1 && c[2, 0].getValor() == 0) return true;
            return false;
        }
        public bool puedoDefenderFila()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (c[i, j].getValor() == c[i, j + 1].getValor() && c[i, j].getValor() == 1 && c[i, j + 1].getValor() == 1 && c[i, j + 2].getValor() == 0 || c[i, j].getValor() == c[i, j + 2].getValor() && c[i, j].getValor() == 1 && c[i, j + 2].getValor() == 1 && c[i, j + 1].getValor() == 0 || c[i, j + 1].getValor() == c[i, j + 2].getValor() && c[i, j + 1].getValor() == 1 && c[i, j + 2].getValor() == 1 && c[i, j].getValor() == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool puedoDefenderColumna()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (c[i, j].getValor() == c[i + 1, j].getValor() && c[i, j].getValor() == 1 && c[i + 1, j].getValor() == 1 && c[i + 2, j].getValor() == 0 || c[i, j].getValor() == c[i + 2, j].getValor() && c[i, j].getValor() == 1 && c[i + 2, j].getValor() == 1 && c[i + 1, j].getValor() == 0 || c[i + 1, j].getValor() == c[i + 2, j].getValor() && c[i + 1, j].getValor() == 1 && c[i + 2, j].getValor() == 1 && c[i, j].getValor() == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void calculoAccion()
        {
            bool aux = true;
            while (aux == true)
            {
                aux = true;
                Random rnd = new Random();
                int num = rnd.Next(0, 3);
                int num2 = rnd.Next(0, 3);
                if (!puedoGanarFila() && !puedoGanarColumna() && !puedoGanarDiagonales() && c[num, num2].estaVacio() && !puedoDefenderFila() && !puedoDefenderColumna() && !puedoDefenderDiagonales())
                {
                    c[num, num2].setSigno(j2.getSigno());
                    c[num, num2].setValor(j2.getValor());
                    aux = false;
                }
                else if (puedoGanarFila())
                {
                    ganarPorFila();
                    aux = false;
                }
                else if (puedoGanarColumna())
                {
                    ganarPorColumna();
                    aux = false;
                }
                else if (puedoGanarDiagonales())
                {
                    ganarPorDiagonales();
                    aux = false;
                }
                else if (puedoDefenderFila())
                {
                    defensaFila();
                    aux = false;
                }
                else if (puedoDefenderColumna())
                {
                    defenderColumna();
                    aux = false;
                }
                else if (puedoDefenderDiagonales())
                {
                    defenderDiagonales();
                    aux = false;
                }
            }
        }
        public void primeraJugada()
        {
            c[1, 1].setSigno(j2.getSigno());
            c[1, 1].setValor(j2.getValor());
        }
        public void jugada()
        {
            Random rnd = new Random();
            turno = rnd.Next(0, 2);
            string respuesta;
            while (!estaCompleto() && !victoria())
            {
                if (turno % 2 == 0)
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine("TURNO {0}: <Introduzca la coordenada>", j1.getNombre().ToUpper());
                    respuesta = Console.ReadLine().ToUpper();
                    turno++;
                }
                else
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine("TURNO {0}:", j2.getNombre());
                    respuesta = "ROBOT";
                    turno++;
                }
                switch (respuesta)
                {
                    case "A1":
                        if (c[0, 0].estaVacio())
                        {
                            c[0, 0].setSigno(j1.getSigno());
                            c[0, 0].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "A2":
                        if (c[0, 1].estaVacio())
                        {
                            c[0, 1].setSigno(j1.getSigno());
                            c[0, 1].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "A3":
                        if (c[0, 2].estaVacio())
                        {
                            c[0, 2].setSigno(j1.getSigno());
                            c[0, 2].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "B1":
                        if (c[1, 0].estaVacio())
                        {
                            c[1, 0].setSigno(j1.getSigno());
                            c[1, 0].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "B2":
                        if (c[1, 1].estaVacio())
                        {
                            c[1, 1].setSigno(j1.getSigno());
                            c[1, 1].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "B3":
                        if (c[1, 2].estaVacio())
                        {
                            c[1, 2].setSigno(j1.getSigno());
                            c[1, 2].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "C1":
                        if (c[2, 0].estaVacio())
                        {
                            c[2, 0].setSigno(j1.getSigno());
                            c[2, 0].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "C2":
                        if (c[2, 1].estaVacio())
                        {
                            c[2, 1].setSigno(j1.getSigno());
                            c[2, 1].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "C3":
                        if (c[2, 2].estaVacio())
                        {
                            c[2, 2].setSigno(j1.getSigno());
                            c[2, 2].setValor(j1.getValor());
                        }
                        else
                        {
                            turno--;
                        }
                        break;
                    case "ROBOT":
                        if (turno == 2 && c[1, 1].estaVacio())
                        {
                            primeraJugada();
                        }
                        else
                        {
                            calculoAccion();
                        }
                        break;
                    default:
                        Console.WriteLine("Introduzca un valor valido");
                        turno--;
                        break;
                }
                Console.Clear();
                tableroVisual();
                if (estaCompleto() && !victoria())
                {
                    Console.WriteLine("LA PARTIDA HA TERMINADO EN EMPATE");
                }
                else if(turno % 2 != 0 && victoria())
                {
                    Console.WriteLine("ENHORABUENA {0} HAS GANADO CAMPEON",j1.getNombre().ToUpper());
                }
                else if(turno % 2 == 0 && victoria())
                {
                    Console.WriteLine("HAS PERDIDO LOOSER");
                }
            }
        }
        public bool estaCompleto()
        {
            int num = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!c[i, j].estaVacio())
                    {
                        num++;
                        if (num == 9)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool victoria()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    //Fila
                    if ((c[i, j].getValor() == c[i, j + 1].getValor() && c[i, j + 1].getValor() == c[i, j + 2].getValor() && c[i, j].getValor() == c[i, j + 2].getValor()) && c[i, j].getValor() != 0 && c[i, j + 1].getValor() != 0 && c[i, j + 2].getValor() != 0) return true;
                    //COLUMNA
                    if ((c[j, i].getValor() == c[j + 1, i].getValor() && c[j + 1, i].getValor() == c[j + 2, i].getValor() && c[j, i].getValor() == c[j + 2, i].getValor()) && c[j, i].getValor() != 0 && c[j + 1, i].getValor() != 0 && c[j + 2, i].getValor() != 0) return true;
                }
            }
            if ((c[0, 0].getValor() == c[1, 1].getValor() && c[1, 1].getValor() == c[2, 2].getValor() && c[0, 0].getValor() == c[2, 2].getValor()) && c[0, 0].getValor() != 0 && c[1, 1].getValor() != 0 && c[2, 2].getValor() != 0) return true;
            if ((c[0, 2].getValor() == c[1, 1].getValor() && c[1, 1].getValor() == c[2, 0].getValor() && c[0, 2].getValor() == c[2, 0].getValor()) && c[0, 2].getValor() != 0 && c[1, 1].getValor() != 0 && c[2, 0].getValor() != 0) return true;
            return false;
        }
        public void ganarPorFila()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (c[i, j].getValor() == c[i, j + 1].getValor() && c[i, j].getValor() == -1 && c[i, j + 1].getValor() == -1)
                    {
                        if (c[i, j + 2].estaVacio())
                        {
                            c[i, j + 2].setSigno(j2.getSigno());
                            c[i, j + 2].setValor(j2.getValor());
                        }
                    }
                    else if (c[i, j].getValor() == c[i, j + 2].getValor() && c[i, j].getValor() == -1 && c[i, j + 2].getValor() == -1)
                    {
                        if (c[i, j + 1].estaVacio())
                        {
                            c[i, j + 1].setSigno(j2.getSigno());
                            c[i, j + 1].setValor(j2.getValor());
                        }
                    }
                    else if (c[i, j + 1].getValor() == c[i, j + 2].getValor() && c[i, j + 1].getValor() == -1 && c[i, j + 2].getValor() == -1)
                    {
                        if (c[i, j].estaVacio())
                        {
                            c[i, j].setSigno(j2.getSigno());
                            c[i, j].setValor(j2.getValor());
                        }
                    }
                }
            }
        }
        public void ganarPorColumna()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (c[j, i].getValor() == c[j + 1, i].getValor() && c[j, i].getValor() == -1 && c[j + 1, i].getValor() == -1)
                    {
                        if (c[j + 2, i].estaVacio())
                        {
                            c[j + 2, i].setSigno(j2.getSigno());
                            c[j + 2, i].setValor(j2.getValor());
                        }
                    }
                    else if (c[j, i].getValor() == c[j + 2, i].getValor() && c[j, i].getValor() == -1 && c[j + 2, i].getValor() == -1)
                    {
                        if (c[j + 1, i].estaVacio())
                        {
                            c[j + 1, i].setSigno(j2.getSigno());
                            c[j + 1, i].setValor(j2.getValor());
                        }
                    }
                    else if (c[j + 1, i].getValor() == c[j + 2, i].getValor() && c[j + 1, i].getValor() == -1 && c[j + 2, i].getValor() == -1)
                    {
                        if (c[j, i].estaVacio())
                        {
                            c[j, i].setSigno(j2.getSigno());
                            c[j, i].setValor(j2.getValor());
                        }
                    }
                }
            }
        }
        public void ganarPorDiagonales()
        {
            if (c[0, 0].getValor() == c[1, 1].getValor() && c[0, 0].getValor() == -1 && c[1, 1].getValor() == -1 && c[2,2].estaVacio())
            {
                    c[2, 2].setSigno(j2.getSigno());
                    c[2, 2].setValor(j2.getValor());
            }
            else if (c[0, 0].getValor() == c[2, 2].getValor() && c[0, 0].getValor() == -1 && c[2, 2].getValor() == -1 && c[1,1].estaVacio())
            {
                    c[1, 1].setValor(j2.getValor());
                    c[1, 1].setSigno(j2.getSigno());
            }
            else if (c[1, 1].getValor() == c[2, 2].getValor() && c[1, 1].getValor() == -1 && c[2, 2].getValor() == -1 && c[0,0].estaVacio())
            {
                    c[0, 0].setValor(j2.getValor());
                    c[0, 0].setSigno(j2.getSigno());
            }
            else if (c[0, 2].getValor() == c[1, 1].getValor() && c[0, 2].getValor() == -1 && c[1, 1].getValor() == -1 && c[2,0].estaVacio())
            {
                    c[2, 0].setValor(j2.getValor());
                    c[2, 0].setSigno(j2.getSigno());
            }
            else if (c[0, 2].getValor() == c[2, 0].getValor() && c[2, 0].getValor() == -1 && c[0, 2].getValor() == -1 && c[1,1].estaVacio())
            {
                    c[1, 1].setValor(j2.getValor());
                    c[1, 1].setSigno(j2.getSigno());
            }
            else if (c[2, 0].getValor() == c[1, 1].getValor() && c[2, 0].getValor() == -1 && c[1, 1].getValor() == -1 && c[0,2].estaVacio())
            {
                    c[0, 2].setValor(j2.getValor());
                    c[0, 2].setSigno(j2.getSigno());
            }
            else
            {
                Console.WriteLine("No puedo ganar por diagonales");
            }
        }
        public void defensaFila()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (c[i, j].getValor() == c[i, j + 1].getValor() && c[i, j].getValor() == 1 && c[i, j + 1].getValor() == 1)
                    {
                        if (c[i, j + 2].estaVacio())
                        {
                            c[i, j + 2].setSigno(j2.getSigno());
                            c[i, j + 2].setValor(j2.getValor());
                        }
                    }
                    else if (c[i, j].getValor() == c[i, j + 2].getValor() && c[i, j].getValor() == 1 && c[i, j + 2].getValor() == 1)
                    {
                        if (c[i, j + 1].estaVacio())
                        {
                            c[i, j + 1].setSigno(j2.getSigno());
                            c[i, j + 1].setValor(j2.getValor());
                        }
                    }
                    else if (c[i, j + 1].getValor() == c[i, j + 2].getValor() && c[i, j + 1].getValor() == 1 && c[i, j + 2].getValor() == 1)
                    {
                        if (c[i, j].estaVacio())
                        {
                            c[i, j].setSigno(j2.getSigno());
                            c[i, j].setValor(j2.getValor());
                        }
                    }
                }
            }
        }
        public void defenderColumna()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (c[j, i].getValor() == c[j + 1, i].getValor() && c[j, i].getValor() == 1 && c[j + 1, i].getValor() == 1)
                    {
                        if (c[j + 2, i].estaVacio())
                        {
                            c[j + 2, i].setSigno(j2.getSigno());
                            c[j + 2, i].setValor(j2.getValor());
                        }
                    }
                    else if (c[j, i].getValor() == c[j + 2, i].getValor() && c[j, i].getValor() == 1 && c[j + 2, i].getValor() == 1)
                    {
                        if (c[j + 1, i].estaVacio())
                        {
                            c[j + 1, i].setSigno(j2.getSigno());
                            c[j + 1, i].setValor(j2.getValor());
                        }
                    }
                    else if (c[j + 1, i].getValor() == c[j + 2, i].getValor() && c[j + 1, i].getValor() == 1 && c[j + 2, i].getValor() == 1)
                    {
                        if (c[j, i].estaVacio())
                        {
                            c[j, i].setSigno(j2.getSigno());
                            c[j, i].setValor(j2.getValor());
                        }
                    }
                }
            }
        }
        public void defenderDiagonales()
        {
            if (c[0, 0].getValor() == c[1, 1].getValor() && c[0, 0].getValor() == 1 && c[1, 1].getValor() == 1)
            {
                if (c[2, 2].estaVacio())
                {
                    c[2, 2].setSigno(j2.getSigno());
                    c[2, 2].setValor(j2.getValor());
                }
            }
            else if (c[0, 0].getValor() == c[2, 2].getValor() && c[0, 0].getValor() == 1 && c[2, 2].getValor() == 1)
            {
                if (c[1, 1].estaVacio())
                {
                    c[1, 1].setValor(j2.getValor());
                    c[1, 1].setSigno(j2.getSigno());
                }
            }
            else if (c[1, 1].getValor() == c[2, 2].getValor() && c[1, 1].getValor() == 1 && c[2, 2].getValor() == 1)
            {
                if (c[0, 0].estaVacio())
                {
                    c[0, 0].setValor(j2.getValor());
                    c[0, 0].setSigno(j2.getSigno());
                }
            }
            else if ((c[0, 2].getValor() == c[1, 1].getValor()) && c[0, 2].getValor() == 1 && c[1, 1].getValor() == 1)
            {
                if (c[2, 0].estaVacio())
                {
                    c[2, 0].setValor(j2.getValor());
                    c[2, 0].setSigno(j2.getSigno());
                }
            }
            else if ((c[0, 2].getValor() == c[2, 0].getValor()) && c[2, 0].getValor() == 1 && c[0, 2].getValor() == 1)
            {
                if (c[1, 1].estaVacio())
                {
                    c[1, 1].setValor(j2.getValor());
                    c[1, 1].setSigno(j2.getSigno());
                }
            }
            else if ((c[2, 0].getValor() == c[1, 1].getValor()) && c[2, 0].getValor() == 1 && c[1, 1].getValor() == 1)
            {
                if (c[0, 2].estaVacio())
                {
                    c[0, 2].setValor(j2.getValor());
                    c[0, 2].setSigno(j2.getSigno());
                }
            }
            else
            {
                Console.WriteLine("No puedo defender diagonales");
            }
        }
    }
}