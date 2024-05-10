using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp
{
    public class Interfaces
    {
        public class Siren : IFish
        {
            public Siren(int speed)
            {
                Speed = speed;
            }
            public int Speed { get; set; }
            public string Swim()
            {
                return $"Siren is swimming at {Speed}";
            }
        }

        public class Shark : IAnimal, IFish
        {
            public Shark(string name, int speed)
            {
                Name = name;
                Speed = speed;
            }
            public override string ToString()
            {
                return $"soy un tiburonnn :D llamado {Name} y mi velocidad es {Speed} km/h";
            }

            public string Name { get; set; }
            public int Speed { get; set; }
            public string Swim()
            {
                return $"{Name} is swimming at {Speed} km/h";
            }

        }
        public interface IAnimal
        {
            public string Name { get; set; }
        }

        public interface IFish
        {
            public int Speed { get; set; }
            public string Swim();
        }
    }
}
