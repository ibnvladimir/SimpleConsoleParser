
namespace GreatestCommonFactor
{
    class GreatestCommonFactorCounter
    {
        public int FactorCounter(int a, int b)
        { 
            while (b != 0)
                b = a % (a = b);
            return a;
        }

       public int FactorCounter(int a, int b, params int[] c)
       {
           var result = FactorCounter(a, b);
           foreach (var temp in c)
           {
               result = FactorCounter(result, temp);
           }
           return result;
        }

       public  int Stein(int a, int b)
       {
           if (a == 0) return b;
           if (b == 0) return a;
           if (a == b) return a;

           bool aIsEven = (a & 1u) == 0;
           bool bIsEven = (b & 1u) == 0;

           if (aIsEven && bIsEven)
               return Stein(a >> 1, b >> 1) << 1;
           else if (aIsEven && !bIsEven)
               return Stein(a >> 1, b);
           else if (bIsEven)
               return Stein(a, b >> 1);
           else if (a > b)
               return Stein((a - b) >> 1, b);
           else
               return Stein(a, (b - a) >> 1);
       }


    }
}
