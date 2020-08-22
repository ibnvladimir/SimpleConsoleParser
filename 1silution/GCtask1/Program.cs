using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCtask1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " ";
            while (true)
            {
                s += s;
                Console.WriteLine(s.Length);
            }
        }
    }
}
