using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Mozi
{
    class adat
    {
        public DateTime datum;
        public int sorszam;
        public int szekszam;
        public char kedvezmeny;
        public bool elovetel;
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<adat> jegyek = new List<adat>();

            int hibaszam = 0;

            try
            {
                StreamReader sr = new StreamReader("terem.txt", Encoding.UTF8);
                Console.WriteLine($"1. feladat: Beolvasás");
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] sz = sr.ReadLine().Split(';');
                        adat tmp = new adat();
                        tmp.datum = DateTime.Parse(sz[0]);
                        tmp.sorszam = int.Parse(sz[1]);
                        tmp.szekszam = int.Parse(sz[2]);
                        tmp.kedvezmeny = char.Parse(sz[3]);
                        tmp.elovetel = sz[4] == "True";
                        jegyek.Add(tmp);
                    }
                    catch (Exception e)
                    {
                        if (e.ToString().StartsWith("System.FormatException")) hibaszam++;
                    }

                }
                sr.Close();
                Console.WriteLine($"A file beolvasása sikeres, az eladott jegyek száma: {jegyek.Count} db.");
            }
            catch (Exception e)
            {
                if (e.ToString().StartsWith("System.FormatException")) Console.WriteLine("Rossz adat.");
                if (e.ToString().StartsWith("System.IO.FileNotFoundException")) Console.WriteLine("Nincs ilyen file.");
                throw;
            }

            if (hibaszam > 0)
            {
                Console.WriteLine($"A fileban {hibaszam} sor hibás.");
            }

            //------------------------------------------------------------------------------------2. feladat:------------------------------------------------------------------------------------//

            Console.WriteLine("2. feladat: Statisztikai adatok meghatározása");

            int bevetel = jegyek.Where(x => x.kedvezmeny == 'T').Count() * 2500;
            bevetel += jegyek.Where(x => x.kedvezmeny == 'D').Count() * 2200;
            bevetel += jegyek.Where(x => x.kedvezmeny == 'B').Count() * 1750;

            int bevetel2 = 0;
            SortedSet<DateTime> napok = new SortedSet<DateTime>();

            foreach (var item in jegyek)
            {
                napok.Add(item.datum);
                if (item.kedvezmeny == 'T') bevetel2 += 2500;
                else if (item.kedvezmeny == 'D') bevetel2 += 2200;
                else bevetel2 += 1750;
            }

            Console.WriteLine($"A heti teljes bevétel {bevetel} forint {bevetel2}");

            //------------------------------------------------------------------------------------2. feladat:------------------------------------------------------------------------------------//

            int[] napiBevetel = new int[napok.Count];
            int[] napiJegyeladas = new int[napok.Count];
            int ii = 0;
            foreach (var item in napok)
            {
                foreach (var item1 in jegyek)
                {
                    if (item1.datum != item) continue;
                    napiJegyeladas[ii]++;
                    if (item1.kedvezmeny == 'T') napiBevetel[ii] += 2500;
                    else if (item1.kedvezmeny == 'D') napiBevetel[ii] += 2200;
                    else napiBevetel[ii] += 1750;
                }
                ii++;
            }

            Console.WriteLine("{0, -20}{1, -30}{2}", "Nap", "Bevétel aránya", "Férőhelyek kihasználtsága");

            ii = 0;
            foreach (var item in napok)
            {
                Console.Write($"{item.ToString("dddd", new CultureInfo("hu-HU")), -20}");
                int arany = napiBevetel[ii] * 100 / bevetel;
                for (global::System.Int32 i = 0; i < arany; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine($"{(double)napiJegyeladas[ii] * 100 / (9.0 * 13.0):0.00}");
                ii++;
            }

            //------------------------------------------------------------------------------------3. feladat:------------------------------------------------------------------------------------//

            int minBev = napiBevetel[0];
            int maxBev = napiBevetel[0];

            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 1; i < napiBevetel.Length; i++)
            {
                if (napiBevetel[i] < minBev)
                {
                    minBev = napiBevetel[i];
                    minIndex = i;
                }

                if (napiBevetel[i] > maxBev)
                {
                    maxBev = napiBevetel[i];
                    maxIndex = i;
                }
            }

            DateTime[] napTomb = napok.ToArray();

            Console.WriteLine("3. feladat");
            Console.WriteLine($"A legmagasabb bevételű nap: {napTomb[maxIndex]:yyyy.MM.dd} - {maxBev} Ft");
            Console.WriteLine($"A legalacsonyabb bevételű nap: {napTomb[minIndex]:yyyy.MM.dd} - {minBev} Ft");

            Console.ReadKey();
        }
    }
}