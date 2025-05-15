using System;
using System.Data;
using System.Data.SqlClient;

namespace obligatorio1progr3.Persistence
{
    public static class Conexion
    {
        public static string CadenaDeConexion
        {
            get
            {
                return @"Data Source=DESKTOP-D9ANF67\SQLEXPRESS;Initial Catalog=lecturaParaTodos;Integrated Security=True;";
                //return @"Data Source=localhost,1433;Initial Catalog=prueba;";
            }
        }
        public static bool Consulta(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                SqlConnection Conexión = new SqlConnection(CadenaDeConexion);
                SqlCommand comando = new SqlCommand(sql, Conexión);

                //Agregamos parametros a la consulta si existen
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros);
                }

                Conexión.Open();
                comando.ExecuteNonQuery();
                comando.Dispose();
                Conexión.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error en Conexión.Consulta, sql = " + sql, e);
            }
        }

        public static DataSet Seleccion(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
                {
                    // Creamos el comando SQL con la consulta y la conexion
                    SqlCommand comando = new SqlCommand(sql, conexion);

                    //Agregamos parametros a la consulta si existen
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    // Creamos el adaptador de datos
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    // Creamos el DataSet para almacenar los resultados
                    DataSet resultado = new DataSet();

                    // Abrimos la conexion
                    conexion.Open();

                    // Llenamos el DataSet con los resultados de la consulta
                    adaptador.Fill(resultado);

                    // Cerramos la conexion y liberamos recursos
                    conexion.Close();

                    // Devolvemos el DataSet con los resultados
                    return resultado;
                }
            }
            catch (Exception e)
            {
                // Capturamos y relanzamos cualquier excepción ocurrida durante la ejecución
                throw new Exception("Error en Conexión.Selección, sql = " + sql, e);
            }
        }
    }
}