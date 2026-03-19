using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    

namespace radio
{
    class farkas
    {
    public int nap; 
    public int radiamator;
    public int felnott;
    public int kojok;

        public farkas(string line)
        {
            string[] darabok = line.Split(' ');   
            this.nap = int.Parse(darabok[0]);
            this.radiamator = int.Parse(darabok[1]);
            this.felnott = int.Parse(darabok[2]);
            this.kojok = int.Parse(darabok[3]);
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            StreamReader fajl = new StreamReader("veetel.txt");
            List<farkas> farkasok = new List<farkas>();
            while (!fajl.EndOfStream)
            {
                string sor = fajl.ReadLine();
                farkasok.Add(new farkas(sor));
            }

            // . Írja a képerny re, hogy melyik rádióamat r rögzítette az állományban szerepl els és 
            //melyik az utolsó üzenetet!

            Console.WriteLine($" 2. feladat: Az első rádióamatőr üzenetét a {farkasok[0].radiamator} rgzitette.");

            Console.ReadKey();
        }
    }
}
