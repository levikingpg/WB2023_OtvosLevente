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
            Console.WriteLine("Írja be az ön nevét:  ");
            nev = Console.ReadLine();
            Console.WriteLine($"Üdvözöllek {nev}!");

            Console.ReadKey();  
        }
    }
}
