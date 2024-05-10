using System.Text.Json;
using static CursoCSharp.Generics;
using static CursoCSharp.Interfaces;
using static CursoCSharp.JsonFormato;

class Program
{
    static void Main()
    {
        var dibu = new Shark[]
        {
        new Shark("tiburonsin",100),
        new Shark("martillo", 56),
        new Shark ( "Jaws", 80)
        };
        showFish(dibu);
        showAnimals(dibu); //DIBU ES I ANIMAL Y IFISH , ASIQUE PUEDE SER PASADO A AMBAS FUNCIONES

        var fishs = new IFish[]
        {
          new Siren(10),
          new Shark("tiburons",100)

       };
        //Generics

        myList<IFish> fishList = new myList<IFish>(20);
        myList<IAnimal> animalList = new myList<IAnimal>(20);
        myList<String>myListString = new myList<String>(20);
        myList<int>myListInt = new myList<int>(20);
        //RECIBE CUALQUIER TIPO DE DATO
        myListInt.Add(199);
        myListInt.Add(200);

        myListString.Add("dada");
   Console.WriteLine(myListString.GetString()); //GET STRING ME CONVIERTE TODO A STRING! SIN IMPORTAR LO QUE SEA
        //ASIQUE TENGO QUE OVERRIDE EL METODO TO STRING!

        myList<Shark> tiburones = new myList<Shark>(20);
        tiburones.Add(new Shark("tiburon", 100));
        Console.WriteLine(tiburones.GetString());



        Console.WriteLine(myListInt.GetString());



        Console.WriteLine(  myListString.GetElement(0));
        Console.WriteLine(myListInt.GetElement(15));
        Console.WriteLine(myListInt.GetElement(0));


        //JSON
        Beer cerveza = new Beer();
        string json = "{\"Name\": \"cerveza.Name\",\"Alcohol \" , \" 10.25 \"}";
        string jsonFast = JsonSerializer.Serialize(cerveza);



        var cerveza2 = JsonSerializer.Deserialize<Beer>(jsonFast);

        // si fuera array o coleecion le paso <beer[]> y lo deserializo


        //METODOS COMUNES DE LISTAS

        var listInt = new List<int>()
        {
            4,5,6,9,8
        };
            



        foreach (var item in listInt)
        {

            string ring = $"nro {item}";
            Console.WriteLine(ring);

        }

        listInt.AddRange(new List<int>() { 1, 2, 3 });



        foreach (var item in listInt)
        {

            string ring = $"nro {item}";
            Console.WriteLine(ring);

        }

        // TIPOS ANONIMOS ( read only)

        var pepe = new {
            Name = "pepe",
            Age = 20,
            jaj = DateTime.Now
        };

        var arrayPepesAnonimo = new[]
        {
        new {Name = "pepe", Age = 20},
        new {Name = "pepe", Age = 23},
        };
     foreach (var pepes in arrayPepesAnonimo) 
        {
            Console.WriteLine(pepe.Name);
        } 


     // tuplas . listas con variables distintas tipo

     (int id,string name) pepeTupla = (1, "pepe");
        var personTuple = (1, "juan"); // sin pasarle los tipos!!

        // si puedo editar sus values
        pepeTupla.name = "pepitoEditado";

        personTuple.Item1 = 2;
        var arrayTuplas = new[]
        {
            (1, "pepe"),
            (2, "juan"),
            (3, "jose")
        };
        (int  id, string name)[] arrayProps = new[]
        {
            (1, "pepe"),
            (2, "juan"),
            (3, "jose")
        };
        foreach (var item in arrayTuplas)
        {
            Console.WriteLine(item.Item2); 
        }
       
        var (_,dou,_) = GetValues(); // _ es para ignorar el valor
       
        // se guarda en automatico en dou
    }

    //FUNCION CON TUPLA
    public static (int pe,int dou,string name) GetValues()
    {
        return (1, 2,"name");
    }


    public static void showAnimals (IAnimal[] animal)
    {
        int i = 0;
        while(i< animal.Length)
        {
            Console.WriteLine(animal[i].Name);
            i++;
        }

    }
public static void showFish(IFish[] fishs)
{
    int i = 0;
    while (i < fishs.Length) // menor a la longitud del arreglo
    {
        Console.WriteLine(fishs[i].Swim());
        i++;
    }

}

};

