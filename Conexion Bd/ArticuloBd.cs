using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_Bd
{
    public class ArticuloBd : BdAccess
    {

        public ArticuloBd(string server,string bd) : base(server, bd)
        {

          
        }
        public void Add(ArticuloDom Art)
        {

            try
            {
                Open();
                string query = "INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,Precio) VALUES (@Codigo,@Nombre,@Descripcion,@Precio)";
                var command = new SqlCommand(query, _Connection);   
                command.Parameters.AddWithValue("@Codigo",Art.Codigo);
                command.Parameters.AddWithValue("@Nombre", Art.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", Art.Descripcion);
                command.Parameters.AddWithValue("@Precio", Art.Precio);
      
                command.ExecuteNonQuery();


            }
            catch ( Exception ex)
            {

                throw ex;
            }
            finally
            {
                Close();
            }
        }

        public List<ArticuloDom> GetAll()
        {
            var ArtList = new List<ArticuloDom>();
            try
            {
                string query = " SELECT A.ID,A.CODIGO,A.NOMBRE,A.Descripcion,A.Precio FROM ARTICULOS AS A  ORDER BY A.Codigo";
                Open();
                var command = new SqlCommand(query, _Connection);
                SqlDataReader reader = command.ExecuteReader(); // le paso que ejecute el comando de lectura
                 while (reader.Read())
                {

                    ArticuloDom Art = new ArticuloDom(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDecimal(4));
                    ArtList.Add(Art);
                }



                return ArtList;
            }
            catch (Exception ex)
            {

                throw ex;
            }finally
            {
                Close();
            }

            
        }

    }
}
