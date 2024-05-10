using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Conexion_Bd
{
    public class ArticuloDom
    {
        public ArticuloDom( int id, string codigo ,string nombre,string descripion,decimal precio)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;    
            Descripcion = descripion;   
            Precio = precio;
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
       // public Marca Marca { get; set; }
        //public Categoria Categoria { get; set; }
        //public Imagen Imagen { get; set; }
        public Decimal Precio { get; set; } //podriamos usar SqlMoney como tipo dato tambien, pero Decimal es + general
    }
}
