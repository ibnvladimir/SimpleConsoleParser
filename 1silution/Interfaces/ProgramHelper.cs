using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class ProgramHelper: ProgramConverter, ICodeChecker
    {
        

        public bool CheckCodeSyntax(string source, string language)
        {
            return true;
        }
    }
}
