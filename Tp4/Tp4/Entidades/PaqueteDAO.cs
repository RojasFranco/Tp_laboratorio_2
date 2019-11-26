using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;


        /*
         * Clase estática que se encargará de guardar los datos de un paquete en la base de datos generada anteriormente:
         * A. De surgir cualquier error con la carga de datos, se deberá lanzar una excepción
         * tantas veces como sea necesario hasta llegar a la vista (formulario).
         * A través de un MessageBox informar lo ocurrido al usuario de forma clara
         * . De ser necesario, utilizar un evento para este fin.
         * 
         * B. El campo alumno de la base de datos deberá contener el nombre del alumno que está realizando el TP. 
 */
        static PaqueteDAO()
        {
            string strConextion = @"Server = localhost\MSSQLSERVER01; DataBase= correo-sp-2017; Trusted_Connection = true;";
            conexion = new SqlConnection(strConextion);

            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            
        }

        public static bool Insertar(Paquete p)
        {

            bool retorno;
            try
            {
                conexion.Open();
                string instruccion = "INSERT INTO Paquetes (DIRECCIONENTREGA, TRACKINGID, ALUMNO) VALUES (@pDireccion, @pTrackingId, @datoAlumno);"; //('{0}', '{1}', 'Franco Rojas');"

                comando.CommandText = instruccion;
                comando.Parameters.AddWithValue("@pDireccion", p.DireccionEntrega);
                comando.Parameters.AddWithValue("@pTrackingId", p.TrackingID);
                comando.Parameters.AddWithValue("@datoAlumno", "'Franco Rojas'");                
                comando.ExecuteNonQuery();
                retorno = true;
            }

            catch(Exception errorEnCarga)
            {
                retorno = false;
                throw errorEnCarga;
            }
            finally
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
            }
            return retorno;
        }
    }
}
