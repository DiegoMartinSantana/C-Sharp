using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_Bd
{
    public abstract class BdAccess
    {
        private string _Conexion;
        protected SqlConnection _Connection; // protected para poder ser usado en hijos

        public BdAccess(string server, string bd) // si requiere usuario y contraseña, agregarlos como parametros
        {
            _Conexion = $"Data Source ={server} ; Initial Catalog = {bd}; trusted_connection=true";

        }
        public void Open()
        {
            _Connection = new SqlConnection(_Conexion);

            _Connection.Open();
        }       
        public void Close()
        {
            if(_Connection.State == System.Data.ConnectionState.Open && _Connection != null)
            _Connection.Close();
        }   


    }
}
