using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class ProgramConverter: IConvertible
    {
        public string ConvertToCSharp(string s)
        {
            return "конвертирую в C#";
        }

        public string ConvertToVB(string s)
        {
            return "конвертирую в VB";
        }
    }
}
