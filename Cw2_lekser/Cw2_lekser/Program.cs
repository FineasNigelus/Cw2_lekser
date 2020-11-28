using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw2_lekser
{
    /*
    Gramatyka<T, N, S, P>
    T = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, +, -,/, *, (,), }
    N = {S,B,L,O,N,C,R}
    S = { S}
    P:
    S → B // Białe znaki
    S → L // Liczba
    S → O // Operator - symbol działania
    S → N // Nawias
    B → ' '|' 'B // Białe znaki - spacja
    O → -|+| *|/
    N → (|)
    L → 0 | C | CR
    R → 0 | C | 0R | CR
    C → 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9
    */

    class Program
    {
        static void Main(string[] args)
        {
            string wyrazenie = "   +(2 + (2*34)";
            Lekser l = new Lekser();
            if(l.analizuj(wyrazenie))
            {
                Console.WriteLine("Rozpoznano wyrażenie");
                foreach (Token t in l.TablicaSymboli)
                {
                    Console.WriteLine("<{0},{1}>", t.nazwa, t.argument);
                }
            }
            else
            {
                int indeks;
                Console.WriteLine("Błąd analizy leksykalnej");
                Console.WriteLine("Nieznany token: {1}, na pozycji: {0}",
                indeks = l.TablicaSymboli.Count() > 0 ? l.TablicaSymboli.Last().indeks + 1 : 0,
                wyrazenie.Substring(indeks,wyrazenie.Length - indeks > 10 ? 10 : wyrazenie.Length - indeks)
                );
            }

            Console.ReadLine();
        }
    }
}
