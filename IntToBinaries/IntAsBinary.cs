using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IntToBinaries
{
    class IntAsBinary
    {
        private uint value; 
        public IntAsBinary(uint value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            var resultString = new StringBuilder(); 
            uint value = this.value;
            
            do
            {
                if (value == 0)
                {
                    resultString.Append(0);
                }
                else if (value >= 1)
                {
                    resultString.Insert(0, value % 2);
                    value = ((value - (value % 2)) / 2);
                }
                else
                {
                    resultString.Insert(0, 1);
                }
                
            } while (value > 0); 
            
            return resultString.ToString();
        }
    }
}
