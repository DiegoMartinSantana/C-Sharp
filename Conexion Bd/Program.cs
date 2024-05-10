using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Conexion_Bd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ArtAccess = new ArticuloBd(@".\SQLEXPRESS", "CATALOGO_P3_DB");
                foreach(var item in ArtAccess.GetAll())
                {
                    Console.WriteLine($"Id: {item.Id} Codigo: {item.Codigo} Nombre: {item.Nombre} Descripcion: {item.Descripcion} Precio: {item.Precio}");
               // ArtAccess.Add(new ArticuloDom(0, "A0001", "Articulo 1", "Descripcion 1", 100));
                }
                Console.ReadKey();


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            

        }
    }
}
