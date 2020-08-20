using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IConvertible
    {
        string ConvertToCSharp(string s);
        string ConvertToVB(string s);
    }
}
