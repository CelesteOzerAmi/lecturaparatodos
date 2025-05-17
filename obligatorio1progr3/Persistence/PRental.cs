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
    public static class PRental
    {
        public static bool Upload(Rental r)
        {
            try
            {
                string sql = "INSERT INTO Rental(id, clientId, clientType, bookId, startDate, endDate, returned) VALUES (@id, @clientId, @clientType, @bookId, @startDate, @endDate, @returned);";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = r.Id},
                new SqlParameter("@clientId", SqlDbType.VarChar) {Value = r.Client.Id},
                new SqlParameter("@clientType", SqlDbType.VarChar) {Value = r.Client.Type.Substring(0,1)},
                new SqlParameter("@bookId", SqlDbType.Int) {Value = r.Book.Id},
                new SqlParameter("@startDate", SqlDbType.Date) {Value = r.StartDate},
                new SqlParameter("@endDate", SqlDbType.Date) {Value = r.EndDate},
                new SqlParameter("@returned", SqlDbType.Bit) {Value = 0},
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
                string sql = "DELETE FROM Rental WHERE id=@id";

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

        public static bool Update(Rental r)
        {
            try
            {
                string sql = "UPDATE Rental SET clientId=@clientId, clientType=@clientType, bookId=@bookId, startDate=@startDate, endDate=@endDate, returned=@returned WHERE id=@id;";

                int returnedRental = 0;
                if (r.Returned)
                {
                    returnedRental = 1;
                }

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = r.Id},
                new SqlParameter("@clientId", SqlDbType.VarChar) {Value = r.Client.Id},
                new SqlParameter("@clientType", SqlDbType.VarChar) {Value = r.Client.Type.Substring(0,1)},
                new SqlParameter("@bookId", SqlDbType.Int) {Value = r.Book.Id},
                new SqlParameter("@startDate", SqlDbType.Date) {Value = r.StartDate},
                new SqlParameter("@endDate", SqlDbType.Date) {Value = r.EndDate},
                new SqlParameter("@returned", SqlDbType.Int) {Value = returnedRental},
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

        public static Rental GetRental(int pId)
        {
            try
            {
                string sql = "SELECT * FROM Rental WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pId}
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];
                Controller c = new Controller();
                Book b = c.GetBook(Convert.ToInt32(dr["bookId"]));
                Client cl = null;
                switch (dr["clientType"].ToString())
                {
                    case "A":
                        cl = c.FindAdult(Convert.ToInt32(dr["clientId"]));
                        break;
                    case "C":
                        cl = c.FindChild(Convert.ToInt32(dr["clientId"]));
                        break;
                    case "S":
                        cl = c.FindSenior(Convert.ToInt32(dr["clientId"]));
                        break;
                }
                
                Rental r = new Rental(Convert.ToInt32(dr["id"]), cl, cl.Type.Substring(0, 1), b, Convert.ToDateTime(dr["startDate"]), Convert.ToDateTime(dr["endDate"]), (Convert.ToInt32(dr["returned"]) == 1 ? true : false));
                return r;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Rental> ListRentals()
        {
            List<Rental> Rental = new List<Rental>();
            try
            {
                string sql = "SELECT * FROM Rental";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Controller c = new Controller();
                    Book b = c.GetBook(Convert.ToInt32(dr["bookId"]));
                    Client cl = null;
                    switch (dr["clientType"].ToString())
                    {
                        case "A":
                            cl = c.FindAdult(Convert.ToInt32(dr["clientId"]));
                            break;
                        case "C":
                            cl = c.FindChild(Convert.ToInt32(dr["clientId"]));
                            break;
                        case "S":
                            cl = c.FindSenior(Convert.ToInt32(dr["clientId"]));
                            break;
                    }

                    Rental.Add(new Rental(Convert.ToInt32(dr["id"]), cl, cl.Type.Substring(0, 1), b, Convert.ToDateTime(dr["startDate"]), Convert.ToDateTime(dr["endDate"]), (Convert.ToInt32(dr["returned"]) == 1 ? true : false)));
                }

                return Rental;
            }
            catch (Exception e)
            {
                return Rental;
            }
        }
    }
}
