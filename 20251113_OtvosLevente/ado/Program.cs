using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Diagnostics;

namespace ado︃
{


    class epitmeny
    {
        public string adoszam;
        public string utca;
        public string hsz;
        public string sav;
        public int terulet;
        // public int szAdo;
        //public int fAdo = 0;

        public epitmeny(string line, int A, int B, int C)
        {
            string[] sz = line.Split(' ');
            this.adoszam = sz[0];
            this.utca = sz[1];
            this.hsz = sz[2];
            this.sav = sz[3];
            this.terulet = int.Parse(sz[4]);
        }
        /*
         switch (sav)
         {
             case "A":
                 this.szAdo = terulet * A;
                 break;
             case "B":
                 this.szAdo = terulet * B;
                 break;
             default:
                 this.szAdo = terulet * C;
                 break;
         }

         if (szAdo >= 10000) fAdo = szAdo;
        */

        public int ado()
        {
            int tmp = 0;
            switch (sav)
            {
                case "A":
                    tmp = terulet * Program.A;
                    break;
                case "B":
                    tmp = terulet * Program.B;
                    break;
                default:
                    tmp = terulet * Program.C;
                    break;
            }
            if (tmp >= 10000) return tmp;
            return 0;
        }


    }

    internal class Program
    {
        public static int A, B, C;
        static int ado(string sav, int terulet)
        {
            int tmp = 0;
            switch (sav)
            {
                case "A":
                    tmp = terulet * Program.A;
                    break;
                case "B":
                    tmp = terulet * Program.B;
                    break;
                default:
                    tmp = terulet * Program.C;
                    break;
            }
            if (tmp >= 10000) return tmp;
            return 0;
        }
        static void Main(string[] args)
        {
            //beolvas
            StreamReader sr = new StreamReader("utca.txt", Encoding.UTF8);
            string[] adok = sr.ReadLine().Split(' ');
            A = int.Parse(adok[0]);
            B = int.Parse(adok[1]);
            C = int.Parse(adok[2]);
            List<epitmeny> telkek = new List<epitmeny>();
            while (!sr.EndOfStream)
            {
                telkek.Add(new epitmeny(sr.ReadLine(), A, B, C));
            }
            sr.Close();
            //2. feladat
            Console.WriteLine($"2. feladatban {telkek.Count()} elem szerepel");

            //3. feladat
            bool flag = false;
            Console.Write($"3. feladat. Egy tulajdonos adoszama: ");
            string adoszam = Console.ReadLine();

            foreach (var item in telkek)
            {
                if (item.adoszam == adoszam)
                {
                    flag = true;
                    Console.WriteLine($"{item.utca} utca {item.hsz}");
                }
            }
            if (!flag) Console.WriteLine("Nem szerepel az allomanyban");

            //4. es feladat
            Console.WriteLine(telkek[0].ado());
            Console.WriteLine(ado(telkek[0].sav, telkek[0].terulet));


            // 5. feladat
            int Adb = 0, Bdb = 0, Cdb = 0;
            int Aosszeg = 0, Bosszeg = 0, Cosszeg = 0;
            SortedSet<string> utcak = new SortedSet<string>();


            foreach (var item in telkek)
            {
                utcak.Add(item.utca);
                switch (item.sav)
                {
                    case "A":
                        Adb++;
                        Aosszeg += item.ado();
                        break;

                    case "B":
                        Bdb++;
                        Bosszeg += item.ado();
                        break;

                    default:
                        Cdb++;
                        Cosszeg += item.ado();
                        break;
                }

            }
            Console.WriteLine($"a savba {Adb} telek esik {Aosszeg}Ft");
            Console.WriteLine($"a savba {Bdb} telek esik {Bosszeg}Ft");
            Console.WriteLine($"a savba {Cdb} telek esik {Cosszeg}Ft");

            //6fel
            foreach (var item in utcak)
            {
                string utcasav = "";
                foreach (var item1 in telkek)

                {
                    if (item == item1.utca && utcasav == "") utcasav = item1.sav;
                    
                }
                Console.ReadKey();
            }
            // 7 fel
            StreamWriter sw = StreamWriter("fizetendo.txt", false, Encoding.UTF8);
            foreach (var item in adoszam)
            {
            }
            int adoOsszeg = 0;

            foreach (var item1 in telkek)

            {
                if (item == item1.utca && utcasav == "") utcasav = item1.sav;



        }
    }
}

