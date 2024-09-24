using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommeGaa
{
    internal class Method
    {
        public static string GetStringUser() //Tager bare input fra bruger og gør teksten til lowercase. Forhindrer errors med store og små bogstaver.
        {
            return Console.ReadLine().ToLower();
        }

        /* Metode der centrerer en string text i konsolvinduet. For at bruge metoden skrives der Method.Center("tekst her");
        Hvor Method er navnet på klassen og Center er navnet på metoden./**/
        public static void Center(string text)
        {
            int windowWidth = Console.WindowWidth;

            int padding = (windowWidth - text.Length) / 2;

            Console.WriteLine(text.PadLeft(padding + text.Length));
        }

        public static void WaitTime(string a) // Metode der tager et string og tilføjer et punktum 3 gange i streg så det ligner at den loader.
        {
            string b = ".";
            Console.WriteLine(a);
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(a+b);
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(a+b+b);
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(a+b+b+b);
            Thread.Sleep(500);
        }
    }
}
