using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // PARA EXCEPCIONES 

namespace CursoC_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // A TRAVES DE FILE
            string BlocNotasTxtContent = File.ReadAllText(@"C:\Users\mante\Desktop\Pato.txt");
            Console.WriteLine(BlocNotasTxtContent);
            Console.ReadLine();
        }
    }
}
