using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CursoCSharp
{
     public class JsonFormato
    {
        public class Beer
        {
            public Beer()
            {
                Name = "Quilmes";
                Alcohol = 10.25m;
            }

            public string Name { get; set; }
            public decimal Alcohol { get; set; }

        }
    
        
        
    }
}
