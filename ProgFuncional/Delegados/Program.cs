using System.Reflection;

namespace Delegados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region USO FUNCIONES
            Operation delegado = functions.Sum; // le digo que es de tipo de esta funcion
            //aca suma el delegado
            //puedo asignarle otra funcion que cumpla con el delegado
            delegado += functions.Multiplicar;
            //aca suma multiplica

            delegado += functions.Restar;

            Console.WriteLine(delegado(4, 9)); // se ejecutan todas las funcions que contiene el delegado

            Show delegadoparametro = functions.mostrar;
            ordenSup("pepe", "dkad", delegadoparametro); //le paso el delegado!
            #endregion


            #region ACTION
            Action<string> DelegateAction = functions.mostrar; // ACTION = TIPO DE DELEGADO, RECIBE  O NO PARAMETROS. ES VOID . ME PERMITE AHORRAR LA CREACION DE DELEGADOS 
            ordenSupACTION("juan", "arnaldo", functions.mostrar);
            ordenSupACTION("juan", "arnaldo2", DelegateAction); // puedo psarle directamente el delegado
            #endregion



            #region LAMBDA EXPRESSIONS

            Action<int, int, int> TripleInt = (a, b, c) => Console.WriteLine($"{a + b + c} RESULTADO ");     // de una linea no uso { }  
            Console.WriteLine("LLAMO A DELEGADO GENERICO CON LAMBDA");
            TripleInt(9, 9, 9);

            //LAMBDA SOLITA
            ordenSupACTION("lamba ", "expression", (a) => Console.WriteLine($"soy una lambda {a}"));

            #endregion

            #region FUNC 
            Func<int> NumeroRamdom = () => new Random().Next(0, 1000); //random clase de c# , devuelve un numero aleatorio , especificando en next . no negativo
            // si o si tipado, segundo ,DEVUELVE ALGO , PUEDE RECIBIR ALGO
            Func<int, bool> DevuelveInt = (a) =>
            {
                var nro = new Random().Next(0, 1000);

                if (a > nro)
                {
                    return true;
                }
                return false;

            };
            //recibe int, devuelve int 

            Console.WriteLine("******************* FUNC *********");
            Console.WriteLine(NumeroRamdom());
            if (DevuelveInt(1))
            {
                Console.WriteLine("VERADDERO ES MAYOR");

            }
            else
            {
                Console.WriteLine("falso es menor");
            }
            Console.WriteLine("****************************");


            #endregion

            #region PREDICATE

            Predicate<string> hasSpaceOrA = (p) => p.Contains(" ") || p.ToUpper().Contains('A');
            //si contiene espacio o A devuelve TRUE

            var listWordsOriginal = new List<string>()
            {
                "pepe",
                "pepe grillo",
                "pepa",
                "patito",
                "petitu" 

            };
            var listWordsModifiedwithpredicate = listWordsOriginal.FindAll(hasSpaceOrA);
            //puedo pasarle predicados a las func de LINQ
            foreach (var item in listWordsModifiedwithpredicate)
            {
                Console.WriteLine(item);
            }

                //para almacenar lo que sea false creo la expresion lambda aca , 
                //es agregar una nueva al predicado generico basicamente
            var listnew = listWordsOriginal.FindAll((a) => !hasSpaceOrA(a));
            #endregion
            Console.WriteLine("**********");
            foreach (var item in listnew)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }

        #region FUNC ORDEN SUPERIOR
        //funcion de orden superior. Recibe una funcion de primer orden del tipo que indica ese delegado
        static void ordenSup(string nombre, string apellido, Show fn) //le paso el DELEGADO, PARA QUE SI O SI REICBA UNA FUNCION QUE CUMPLA CON SU TIPO ESPECIFICADO
        {
            Console.WriteLine("hago algo inicio");
            //recibir asi me permite hacer callback, me permite ejecutar algo depsues o durante una ejecucion
            string retornar = $"soy {nombre} , apellido {apellido} ";
            fn(retornar);
            Console.WriteLine("hago algo final");

        }

        // puedo recibir delegados genericos tambien 
        static void ordenSupACTION(string nombre, string apellido, Action<string> fn)
        {
            Console.WriteLine("hago algo inicio");
            string retornar = $"soy {nombre} , apellido {apellido} ";
            fn(retornar); //este es a!

        }
        #endregion

        #region Delegados
        delegate int Operation(int value1, int value2);

        delegate void Show(string mostrar);


        #endregion Delegados
    }
}
