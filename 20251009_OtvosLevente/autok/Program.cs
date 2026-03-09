using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace autok
{
    class data
    {
        public string licencePlate;
        public int hour;
        public int minute;
        public int speed;

        public data(string line)
        {
            string[] sz = line.Split('\t');

            this.licencePlate = sz[0];
            this.hour = int.Parse(sz[1]);
            this.minute = int.Parse(sz[2]); 
            this.speed = int.Parse(sz[3]);
        }
    }
    internal class Program
    {
        static int length;
        static data [] datas;

        static void Datastorage()
        {

            string[] fileData = File.ReadAllLines("jeladas.txt", Encoding.UTF8);

            length = fileData.Length;
             datas = new data[length];

            for (int i = 0; i < length; i++)
            {
                datas[i] = new data(fileData[i]);
            }
        }

        static void Main(string[] args)
        {
        

            Datastorage();
            // irja ki hany db jeladas tortent

            Console.WriteLine($"{length} db jeladás történt");
       

            // irja ki hogy hany gepkocsi ment át a szakaszon

            HashSet<string> listOfLicencePlate = new HashSet<string>();
            foreach (var item in datas)
            {
                listOfLicencePlate.Add(item.licencePlate);
                
            }
            Console.WriteLine($"{listOfLicencePlate.Count}db gépkocsi haladt ét a szakaszon");

            // leggyorsabb autó rendszáma
            int maxSpeed = 0;
            string leggyorsabb = "";
            foreach (var item in datas)
            {
                if (item.speed > maxSpeed)
                {
                    maxSpeed = item.speed;
                    leggyorsabb = item.licencePlate;
                }
            }
            Console.WriteLine($"A leggyorsabb autó rendszáma: {leggyorsabb}");
            Console.ReadKey();
        }

    }
}
