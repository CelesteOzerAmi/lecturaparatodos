using obligatorio1progr3.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Persistence
{
    public static class PGenre
    {
        public static string Upload(Genre g)
        {
            try
            {
                string sql = "INSERT INTO Genre(id, name) VALUES (@id, @name);";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = g.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value = g.Name},
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Genre successfully added";

                return "Error adding genre";
            }
            catch (Exception e)
            {
                return $"Error adding genre {e.Message}";
            }

        }

        public static bool Delete(int pId)
        {
            try
            {
                string sql = "DELETE FROM Genre WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pId}
                };

                if (Conexion.Consulta(sql, parametros))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error removing genre", e);
                return false;
            }
        }

        public static string Update(Genre g)
        {
            try
            {
                string sql = "UPDATE Genre SET name=@name WHERE id=@id;";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = g.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value=g.Name},
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Genre updated successfully";

                return "Error updating genre";

            }
            catch (Exception e)
            {
                return $"Error updating genre {e.Message}";
            }
        }

        public static Genre GetGenre(int pId)
        {
            try
            {
                string sql = "SELECT * FROM Genre WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pId}
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];

                Genre m = new Genre(Convert.ToInt32(dr["id"]), dr["name"].ToString());
                return m;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Genre> ListGenres()
        {
            List<Genre> Genre = new List<Genre>();
            try
            {
                string sql = "SELECT * FROM Genre";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Genre.Add(new Genre(Convert.ToInt32(dr["id"]), dr["name"].ToString()));
                }

                return Genre;
            }
            catch (Exception e)
            {
                return Genre;
            }
        }
    }
}
