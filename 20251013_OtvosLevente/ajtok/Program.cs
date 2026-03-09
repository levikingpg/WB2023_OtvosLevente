using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ajtok
{
    class nyitasok
    {
        public int ora;
        public int perc;
        public int id;
        public bool be;
        }
    internal class Program
    {

       
        static void Main(string[] args)
        {
            List<nyitasok> lista = new List<nyitasok>();
            StreamReader sr = new StreamReader("ajto.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                nyitasok tmp = new nyitasok();
                tmp.ora = Convert.ToInt32(line.Split(' ')[0]);
                tmp.perc = Convert.ToInt32(line.Split(' ')[1]);
                tmp.id = Convert.ToInt32(line.Split(' ')[2]);
                tmp.be = Convert.ToBoolean(Convert.ToInt32(line.Split(' ')[3]));
                lista.Add(tmp);


            }
            //2. feladat

            //3. feladat
            StreamWriter sw = new StreamWriter("athaladas.txt", false, Encoding.UTF8);
            SortedSet<int> ids = new SortedSet<int>(); 
          foreach (var item in lista)
            
            foreach (var item in ids)
            {
                ids.Add(item.id);
            }
            sw.Close();
            int db = 0;
            foreach (var item1 in lista) if (item1.id == item) db++;
            Console.WriteLine($"{item} {db}");

            Console.ReadKey();
        }
    }
}
