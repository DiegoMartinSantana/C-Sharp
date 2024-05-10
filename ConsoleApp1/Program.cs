using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<beer> beers = new List<beer>
            {
                new beer { Name = "Heineken", Alcohol = 5 },
                new beer { Name = "Amstel", Alcohol = 5 },
                new beer { Name = "Grolsch", Alcohol = 5 },
                new beer { Name = "Hertog Jan", Alcohol = 3 },
                new beer { Name = "Bavaria", Alcohol = 6 },
                new beer { Name = "Brand", Alcohol = 5 },
                new beer { Name = "Jupiler", Alcohol = 3 },
                new beer { Name = "Dommelsch", Alcohol = 5 },
                new beer { Name = "Gulpener", Alcohol = 0 },
                new beer { Name = "Alfa"}
            };


            //USO LINQ SELECT
            // uso datos anonimos
            var beerLinq = from b in beers
                           select new
                           { // dato anonimo
                               name = b.Name,
                               letrasname = b.Name.Length,
                               alcohol = b.Alcohol
                             
                           };
            foreach(var beer in beerLinq)
            {
                Console.WriteLine(beer.name);

                Console.WriteLine(beer.alcohol);
                Console.WriteLine(beer.letrasname);
            }
        Console.ReadKey();
        }

    }

    public class beer
    {

        public string Name { get; set; }

        public int Alcohol { get; set; }    
    }
}
