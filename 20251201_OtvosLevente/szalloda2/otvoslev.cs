using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace szalloda2
{
    class data
    {
        public ushort sorszam;// 0 - 65535
        public byte szobaszam;// 0 -255
        public ushort erkNap;
        public ushort tavNap;
        public byte vendegSzam;
        public byte reggeli;
        public string azonosito;

        public data(string line)
        {
            this.azonosito = "banán";

            try
            {
                string[] sz = line.Split(' ');

                //sorszám
                ushort tmp = ushort.Parse(sz[0]);
                if (tmp > 0 && tmp <= Program.maxSsz) this.sorszam = tmp;
                else return;

                // szobaszám
                byte tmp1 = byte.Parse(sz[1]);
                if (tmp1 > 0 && tmp1 <= 27) this.szobaszam = tmp1;
                else return;

                //érkezés
                tmp = ushort.Parse(sz[2]);
                if (tmp > 0 && tmp <= Program.maxNap) this.erkNap = tmp;
                else return;

                //távozás
                tmp = ushort.Parse(sz[3]);
                if (tmp >= erkNap && tmp <= Program.maxNap) this.tavNap = tmp;
                else return;

                // vendégszám
                tmp1 = byte.Parse(sz[4]);
                if (tmp1 > 0 && tmp1 <= 3) this.vendegSzam = tmp1;
                else return;

                // reggeli
                tmp1 = byte.Parse(sz[5]);
                if (tmp1 >= 0 && tmp1 <= 1) this.reggeli = tmp1;
                else return;

                //azonosító
                azonosito = sz[6];
                return;
            }
            catch (Exception)
            {
                return;
            }
        }


    }
    internal class Program
    {
        static public ushort maxSsz = 0;
        static public ushort maxNap = 0;
        static void Main(string[] args)
        {
            string[] honapok = File.ReadAllLines("honapok.txt", Encoding.UTF8);
            string[] fileAdat = File.ReadAllLines("pitypang.txt", Encoding.UTF8);


            try
            {
                maxSsz = ushort.Parse(fileAdat[0]);
            }
            catch (Exception)
            {
                Console.WriteLine("Hiba!");
                Console.ReadKey();
                return;
            }
            // max nap
            ushort[,] napok = new ushort[12, 3];
            for (int i = 0; i < honapok.Length; i += 3)
            {
                napok[i / 3, 0] = ushort.Parse(honapok[i + 1]);
                napok[i / 3, 1] = ushort.Parse(honapok[i + 2]);
                napok[i / 3, 2] = ushort.Parse(((int)napok[i / 3, 0] + (int)napok[i / 3, 1] - 1).ToString());
                if (maxNap < napok[i / 3, 2]) maxNap = napok[i / 3, 2];
            }

            List<data> adatok = new List<data>();
            foreach (var item in fileAdat)
            {
                data tmp = new data(item);
                if (tmp.azonosito != "banán") adatok.Add(tmp);
            }

            Console.ReadKey();
        }
    }
}