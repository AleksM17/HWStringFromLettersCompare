using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine(StringFromLetters(some));
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
