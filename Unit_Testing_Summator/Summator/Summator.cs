using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summator
{
    public class Summator
    {
        public static int Sum(int [] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
            sum += arr[i];
            }
                return sum;
        }

        static void Main()
        {
            int result = (Summator.Sum(new int[] { 10, 20, 30 }));
        if (result == 60)
            {
                Console.WriteLine("TEST PASS");
            }
            else
            {
                Console.WriteLine("TEST FAIL");
            }
        }
    }
}
