using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Laba3
{
    class Program
    {
        static void firstTask()
        {
            string path = @"C:\Users\rrafa\Desktop\Laba3\input.txt";
            List<int> C1 = new List<int>();
            List<int> C2 = new List<int>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int x = Convert.ToInt32(line);
                    if (x < 0) break;
                    else C1.Add(x);
                }
                line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    int x = Convert.ToInt32(line);
                    C2.Add(x);
                }
            }
            C1.Sort();
            foreach (int i in C1) Console.WriteLine(i);
            Console.WriteLine();
            C2.Sort();
            foreach (int i in C2) Console.WriteLine(i);
            Console.WriteLine();
            foreach (int i in C2) C1.Add(i);
            C1.Sort();
            foreach (int i in C1) Console.WriteLine(i);
        }
        static async void secondTask()
        {
            int i = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            string path = @"C:\Users\rrafa\Desktop\Laba3\input.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int x = Convert.ToInt32(line);
                    dic.Add(i++, x);
                }
            }
            Dictionary<int, int> res = new Dictionary<int, int>();
            foreach(var j in dic)
            {
                if (j.Key >= j.Value) res.Add(j.Key, j.Value);
            }
            foreach (var j in res)
            {
                string json = JsonSerializer.Serialize(j);
                Console.WriteLine(json);
            }
            using (FileStream fs = new FileStream(@"C:\Users\rrafa\Desktop\Laba3\output.json", FileMode.OpenOrCreate))
            {
                foreach (var j in res)
                {
                    await JsonSerializer.SerializeAsync(fs, j);
                }
            }
        }
        static bool posl(List<int> y, int a)
        {
            for(int i = 0; i<y.Count; i++)
            {
                if (i * y[i] == a) return true;
            }
            return false;
        }
        static void thirdTask()
        {
            string path = @"C:\Users\rrafa\Desktop\Laba3\input1.txt";
            List<int> lis = new List<int>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int x = Convert.ToInt32(line);
                    lis.Add(x);
                }
            }
            var res = from t in lis where (posl(lis, t)) select t;
            foreach (var t in res) Console.WriteLine(t);
            Console.WriteLine();
            List<int> d = new List<int>();
            foreach(var j in res)
            {
                if (j / 10 == 0) d.Add(j);
            }
            for (int i = 0; i < d.Count / 2; i++)
            {
                int c = d[i];
                d[i] = d[d.Count - i - 1];
                d[d.Count - i - 1] = c;
            }
            foreach (var j in d) Console.WriteLine(j);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            thirdTask();
        }
    }
}
