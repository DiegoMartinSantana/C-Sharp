using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace ProyectForEntityFrameworkç
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"Server= localhost\SQLEXPRESS ; Database= Univ ; Integrated Security = True ;TrustServerCertificate=True"

            DbContextOptionsBuilder<UnivContext> builderOptions = new DbContextOptionsBuilder<UnivContext>();
            builderOptions.UseSqlServer(@"Server= localhost\SQLEXPRESS ; Database= Univ ; Integrated Security = True ;TrustServerCertificate=True");

            using (UnivContext context = new UnivContext(builderOptions.Options)) //inicializo el contexto aca- Y LE PASO EL OPTIONS BUILDER
            {

                bool again = true;
                int op = 0;
                do
                {
                    ShowMenu();
                    Console.WriteLine("Elija una opcion");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            Show(builderOptions);
                            break;
                        case 2:
                            AddP(builderOptions);
                            AddL(builderOptions);
                            break;

                        case 3:
                            EditP(builderOptions);  
                            break;
                        case 4:
                            DeleteP(builderOptions);
                            break;
                        default:
                            break;

                    }

                }
                while (again);



            }
            Console.ReadKey();

        }

        public static void AddP(DbContextOptionsBuilder<UnivContext> options)
        {
            Console.Clear();
            Console.WriteLine();


            using (UnivContext context = new UnivContext(options.Options))
            {
                //añado nuevo pais
                var pais = new Paise();

                pais.Nombre = "pais generico2";
                pais.Id = 956;
                context.Add(pais);
                context.SaveChanges();
           
            }

            
        }

        public static void DeleteP(DbContextOptionsBuilder<UnivContext> options)
        {
            Console.Clear();
            using(UnivContext context = new UnivContext(options.Options))
            {
                //ELIMINAR UNO

                //var pais = context.Paises.Find((short)111);
                //obtengo id a eliminar..
                //context.Paises.Remove(pais);

                //ELIMINAR MAS
                var listEliminar = new List<short> { 333, 339, 400 };

                var paises = from p in context.Paises
                             where listEliminar.Contains(p.Id  )
                             select p;


                context.Paises.RemoveRange(paises);
                context.SaveChanges();
            }

        }

        public static void EditP(DbContextOptionsBuilder<UnivContext> options)
        {


            using(UnivContext context = new UnivContext(options.Options))
            {
                //proceso obtencion id..
                short idSearch = 111;
                var Pais_Editar = context.Paises.Find(idSearch); // va a buscar x el id!

                //una vez obtengo el id edito.
                
                string name = "Pais editado";
                Pais_Editar.Nombre = name;

                context.Entry(Pais_Editar).State =EntityState.Modified;
                    //le aviso cual fue editado y que su estado fue cambiado!
                context.SaveChanges();


            }
        }


        public static void AddL(DbContextOptionsBuilder<UnivContext> options)
        {
            using (UnivContext context = new UnivContext(options.Options))
            {
                var localidad = new Localidade();


                localidad.Id = 999;
                localidad.Nombre = "LOCALIDAD GENERICA";
                localidad.Idpais = 956; //

                context.Add(localidad);
                context.SaveChanges();
            }

        } 

        public static void Show(DbContextOptionsBuilder<UnivContext> options) //recibe el contextop
        {
            Console.Clear();
            Console.WriteLine("Datos de la bd");

            using (UnivContext context = new UnivContext(options.Options))
            {


                var listLocalidades_INNERJOIN_Paises =
                    (from l in context.Localidades
                     orderby l.Nombre
                     select l).Include(l => l.IdpaisNavigation).ToList();



                foreach (var joinList in listLocalidades_INNERJOIN_Paises)
                {
                    Console.WriteLine("Ciudad : " + joinList.Nombre);
                    Console.WriteLine("Pais : " +joinList.IdpaisNavigation.Nombre);
                }

                //  var listPaises = context.Paises.ToList();
                var listPaises = context.Paises.OrderByDescending(p => p.Nombre); // a nivel metodos


                var listFiltrada = (from b in context.Paises // a nivel consulta!
                                    where b.Nombre == "Argentina"
                                    orderby b.Nombre
                                    select b).ToList();


                var listFiltradaJOIN = (from b in context.Usuarios // a nivel consulta!
                                                                   //where b.Nombre == "Argentina
                                        orderby b.NombreUsuario
                                        select b).Include(b => b.DatosPersonale).ToList();

                foreach (var item in listFiltradaJOIN)
                {
                    Console.WriteLine(item.DatosPersonale.Apellidos);
                    Console.WriteLine(item.NombreUsuario);

                }
            }




        }

        public static void ShowMenu()
        {

            Console.WriteLine("\n--------MENU------");
            Console.WriteLine("1- mostrar");
            Console.WriteLine("2- agregar");
            Console.WriteLine("3 - editar");
            Console.WriteLine("4-eliminar");
            Console.WriteLine("5- salir");

        }

    }
}
