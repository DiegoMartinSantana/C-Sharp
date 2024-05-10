using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados
{
    public  class functions
    {
        public static int Sum(int value1, int value2) => value1 + value2;
        public static int Multiplicar(int value1, int value2) => value1 * value2;
        public static int Restar (int value1, int value2) => value1 - value2;

        public string Upper(string text) => text.ToUpper();
        public static void mostrar(string text)
        {
            Console.WriteLine(text);
        }


    }
}
