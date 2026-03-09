using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace utepites
{
    class data
    {
        public int ora;
        public int perc;
        public int mp;
        public int ido;
        public string erkezes;

        public data(string line)
        {
            string[] sz = line.Split(' ');
            this.ora = int.Parse(sz[0]);
            this.perc = int.Parse(sz[1]);
            this.mp = int.Parse(sz[2]);
            this.ido = int.Parse(sz[3]);
            this.erkezes = sz[4];

        }
        private void ss
        {
            sumSet = hour * 3600 + 
        }

    }
    internal class Program
    {
    

        
        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines("forgalom.txt", Encoding.UTF8);
            int length = lines.Length;
            data[] datas = new data[length - 1];
            for (int i = 1; i < length; i++)
            {
                datas[i - 1] = new data(lines[i]);
            }
            Console.WriteLine(datas[0].ido);
            Console.ReadKey();
        }
    }
}
