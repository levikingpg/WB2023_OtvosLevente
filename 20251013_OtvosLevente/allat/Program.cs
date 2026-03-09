
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allat
{
    class kutya
    {
        public string szin;
        public bool szuka;
        public string nev;
        public string fajta;
        public double suly;
        public int jokedv; // 0 10 kozott

        public kutya(string szin, bool szuka, string nev,  double suly, string fajta)
        { 
            this.szin = szin;
            this.szuka = szuka;
            this.nev = nev;
            this.fajta = fajta;
            this.suly = suly;
            this.jokedv = 0;
        }
        public void etetes()
        {
            suly += 0.1;
            jokedv  += 1;
        }

        public void el(int nap)
        {
            suly -= 0.1 * nap;
        }
    }



    class macska
    {
        public string szin;
        public bool nosteny;
        public string nev;
        public string fajta;
        public bool oltas;
        public int jokedv; // 0 10 kozott
        public void simogatas()
        {
            jokedv++;

        }

    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            kutya kutyus1 = new kutya("barna", false, "Bodri", 2.4, "kuvasz" );
            Console.WriteLine(kutyus1.suly);
            kutyus1.etetes();
            Console.WriteLine(kutyus1.suly);

            macska[] falka = new macska[5];
            for (int i = 0; i < 5; i++)
            {
                falka[i] = new macska();
                falka[i].jokedv = i;
                falka[i].simogatas();
            }

            Console.ReadKey();
        }
    }
}
