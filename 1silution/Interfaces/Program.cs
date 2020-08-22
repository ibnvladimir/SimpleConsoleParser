using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] arrey = new ProgramConverter[4];
            for (var i = 0; i < 4; i++)
            {
                arrey[i] = (i % 2 == 0 ? new ProgramConverter() : new ProgramHelper());
            }

            for (var i = 0; i < 4; i++)
            {
                if (arrey[i] is ICodeChecker)
                {
                    if (arrey[i] is ProgramHelper tmp)
                    {
                        Console.WriteLine(tmp.CheckCodeSyntax("", "VB"));
                        Console.WriteLine(tmp.ConvertToCSharp(""));
                        Console.WriteLine("---------------");
                    }
                }
                else
                {
                    Console.WriteLine(arrey[i].ConvertToCSharp(""));
                    Console.WriteLine(arrey[i].ConvertToVB(""));
                    Console.WriteLine("---------------");
                }
            }
        }

        
    }
}
