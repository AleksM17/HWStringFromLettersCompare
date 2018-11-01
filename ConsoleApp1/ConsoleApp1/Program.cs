using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringFromLettersCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "attachet";
            //string[] some = { "r>i", "n>g", "i>n", "s>t", "t>r" };
            string[] some = { "e>t", "t>t", "a>t", "h>e", "c>h", "a>c", "t>a" };
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(Foo(some));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks.ToString());
            //stopwatch = new Stopwatch();
            //stopwatch.Start();
            //Console.WriteLine(StringFromLetters(some));
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.ElapsedTicks.ToString());

        }
        static string Foo(string[] str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashSet<int> table = new HashSet<int>();
            stringBuilder.Append(str[0][0]);
            stringBuilder.Append(str[0][2]);
            table.Add(0);
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    if (!table.Contains(j))
                    {
                        if (stringBuilder[0] == str[j][2])
                        {
                            stringBuilder.Insert(0, str[j][0]);
                            table.Add(j);
                        }
                        else if (stringBuilder[stringBuilder.Length - 1] == str[j][0])
                        {
                            stringBuilder.Append(str[j][2]);
                            table.Add(j);
                            break;
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }
        static string StringFromLetters(string[] arrString)
        {
            char max = ' ';
            char next = ' ';
            StringBuilder stringBuilder = new StringBuilder();
            HashSet<string> table = new HashSet<string>();
            foreach (var item in arrString)
            {
                foreach (var last in arrString)
                {
                    if (item[0] == last[2])
                    {
                        max = last[0];
                        next = last[2];
                    }
                }
            }
            stringBuilder.Append(max);
            table.Add(max + ">" + next);
            max = next;
            foreach (var item in arrString)
            {
                foreach (var last in arrString)
                {
                    if (!table.Contains(last))
                    {
                        if (last[0] == max)
                        {
                            stringBuilder.Append(last[0]);
                            table.Add(last);
                            max = last[2];
                            break;
                        }
                    }
                }
            }
            stringBuilder.Append(max);
            return stringBuilder.ToString();
        }
    }
}
