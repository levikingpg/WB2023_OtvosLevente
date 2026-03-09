using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamonkeres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Írja be az ön nevét:  ");
            string nev = Console.ReadLine();
            Console.WriteLine($"Üdvözöllek {nev}!");

            Console.ReadKey();  
        }
    }
}
