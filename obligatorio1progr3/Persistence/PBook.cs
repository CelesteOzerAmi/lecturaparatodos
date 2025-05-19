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
    public static class PBook
    {
        public static bool Upload(Book b)
        {
            try
            {
                string sql = "INSERT INTO Book(id, title, author, genreId, bookYear, subsidiaryId, available) VALUES (@id, @title, @author, @genre, @year, @subsidiary, @available);";
                int avail;
                if (b.Available)
                {
                    avail = 1;
                } 
                else
                {
                    avail = 0;
                }

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = b.Id},
                new SqlParameter("@title", SqlDbType.VarChar) {Value = b.Title},
                new SqlParameter("@author", SqlDbType.VarChar) {Value = b.Author},
                new SqlParameter("@genre", SqlDbType.Int) {Value = b.Genre.Id},
                new SqlParameter("@year", SqlDbType.Int) {Value = b.Year},
                new SqlParameter("@subsidiary", SqlDbType.Int) {Value = b.Subsidiary.Id},
                new SqlParameter("@available", SqlDbType.Int) {Value = avail},
                };

                if (Conexion.Consulta(sql, parametros))
                    return true;

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.ToString());
                return false;
            }

        }

        public static bool Delete(int pId)
        {
            try
            {
                string sql = "DELETE FROM Book WHERE id=@id;";

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
                Console.WriteLine("Error", e);
                return false;
            }
        }

        public static bool Update(Book b)
        {
            try
            {
                string sql = "UPDATE Book SET title=@title, author=@author, genreId=@genre, bookYear=@year, subsidiaryId=@subsidiary, available=@available WHERE id=@id;";
                int avail = 0;
                if (b.Available)
                {
                    avail = 1;
                }

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = b.Id},
                new SqlParameter("@title", SqlDbType.VarChar) {Value=b.Title},
                new SqlParameter("@author", SqlDbType.VarChar) {Value = b.Author},
                new SqlParameter("@genre", SqlDbType.Int) {Value = b.Genre.Id},
                new SqlParameter("@year", SqlDbType.Int) {Value = b.Year},
                new SqlParameter("@subsidiary", SqlDbType.Int) {Value = b.Subsidiary.Id },
                new SqlParameter("@available", SqlDbType.Int) {Value = avail }
                };

                if (Conexion.Consulta(sql, parametros))
                    return true;

                Console.WriteLine("Error en datos ingresados");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.ToString());
                return false;
            }
        }

        public static Book GetBook(int pId)
        {
            try
            {
                string sql = "SELECT * FROM Book WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pId}
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];
                Controller c = new Controller();
                Genre g = c.FindGenre(Convert.ToInt32(dr["genreId"]));
                Subsidiary s = c.FindSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));
                bool available = false;
                if (Convert.ToInt32(dr["available"]) == 1)
                {
                    available = true;
                }
                return new Book(Convert.ToInt32(dr["id"]), dr["title"].ToString(), dr["author"].ToString(), g, Convert.ToInt32(dr["bookYear"]), s, available);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Book> ListBooks()
        {
            List<Book> Books = new List<Book>();
            try
            {
                string sql = "SELECT * FROM Book";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Controller c = new Controller();
                    Genre g = c.FindGenre(Convert.ToInt32(dr["genreId"]));
                    Subsidiary s = c.FindSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));
                    bool available = false;
                    if (Convert.ToInt32(dr["available"]) == 1)
                    {
                        available = true;
                    }
                    Books.Add(new Book(Convert.ToInt32(dr["id"]), dr["title"].ToString(), dr["author"].ToString(), g, Convert.ToInt32(dr["bookYear"]), s, available));
                }

                return Books;
            }
            catch (Exception e)
            {
                return Books;
            }
        }
        public static List<Book> GetBookBySubsidiary(int subId)
        {
            List<Book> books = new List<Book>();
            try
            {
                string sql = "SELECT * FROM Book WHERE subsidiaryId = @subId";

                SqlParameter[] parametros =
                {
            new SqlParameter("@subId", SqlDbType.Int) { Value = subId }
        };

                DataSet ds = Conexion.Seleccion(sql, parametros);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Controller c = new Controller();
                    Genre g = c.FindGenre(Convert.ToInt32(dr["genreId"]));
                    Subsidiary s = c.FindSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));
                    bool available = Convert.ToInt32(dr["available"]) == 1;

                    books.Add(new Book(
                        Convert.ToInt32(dr["id"]),
                        dr["title"].ToString(),
                        dr["author"].ToString(),
                        g,
                        Convert.ToInt32(dr["bookYear"]),
                        s,
                        available
                    ));
                }

                return books;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.ToString());
                return books;
            }
        }
    }
}
