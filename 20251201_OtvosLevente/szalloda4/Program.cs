using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

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



        public int ar()
        {
            //egy nap arat szamol ki
            int ii = 0;
            int szobaAr = 0;
            while (!(erkNap >= Program.napok[ii, 1] && erkNap <= Program.napok[ii, 2])) ii++;
            if (ii < 4) szobaAr = 9000;
            else if (ii < 8) szobaAr = 10000;
            else szobaAr = 8000;

            if (vendegSzam == 3) szobaAr += 2000;
            szobaAr += reggeli * 1100 * vendegSzam;

            //most pedig beszorozza a napi arat annyi nappla ahanyat maradtak
            return szobaAr * (tavNap - erkNap);



        }



    }
    internal class Program
    {
        static public ushort maxSsz = 0;
        static public ushort maxNap = 0;
        static public ushort[,] napok = new ushort[12, 3];
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


            #region 2.feladat
            int maxEjsz = adatok[0].tavNap - adatok[0].erkNap; //a file elso elemenek tartozkodasi naok szamat rakjuk alapertelmezettnek (ehhezv viszonyitunk)

            int maxEjszId = 0;
            for (int i = 1; i < adatok.Count; i++)//azert forral kell mert azt is tudnio akarjuk hogy melyik kell es ahhoz kell az index is az meg foreachnel nincsen
            {
                if (adatok[i].tavNap - adatok[i].erkNap > maxEjsz)
                {
                    maxEjszId = i;

                }


            }
            Console.WriteLine($"{adatok[maxEjszId].azonosito} + ({maxEjsz})");

            #endregion

            #region 3.feladat
            int osszes = 0;
            StreamWriter sw = new StreamWriter("bevetel.txt", false, Encoding.UTF8);
            foreach (var item in adatok)
            {
                sw.WriteLine($"{item.sorszam}:{item.ar()}");
                osszes += item.ar();
            }
            sw.Close();






            #endregion

            #region 4.feladat
            Console.Write($"legtobb: {osszes}");



            #endregion

            #region 5.feladat
            int[] db = new int[napok[11, 2]];
            foreach (var item in adatok)
            {
                for (int i = item.erkNap; i < item.tavNap; i++) db[i] += item.vendegSzam;
            }
            int haviEjsz = 0;
            int induloHonap = 0;
            for (int i = 0; i < db.Length; i++)
            {
                haviEjsz += db[i];
                if (i == napok[induloHonap, 2])
                {
                    Console.WriteLine($"{induloHonap + 1}.honap: {haviEjsz} vendégéj");
                    induloHonap++;
                    haviEjsz = 0;
                }
            }

            #endregion
            #region 6. feladat
            Console.WriteLine("kerem a nap szamat");
            int napSzam = int.Parse(Console.ReadLine());
            Console.WriteLine("kerem az ejszakak szamat");
            int ejszakaSzam = int.Parse(Console.ReadLine());
            for (int j = 1; j < 28; j++)
            {

            }
            #endregion
            Console.ReadKey();
        }
    }
}