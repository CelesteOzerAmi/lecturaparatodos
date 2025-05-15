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
    public static class PSubsidiary
    {
        public static bool Upload(Subsidiary s)
        {
            try
            {
                string sql = "INSERT INTO Subsidiary(id, name, city, address, phoneNumber, manager) VALUES (@id, @name, @city, @address, @number, @manager);";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = s.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value = s.Name},
                new SqlParameter("@city", SqlDbType.VarChar) {Value = s.City},
                new SqlParameter("@address", SqlDbType.VarChar) {Value = s.Address},
                new SqlParameter("@number", SqlDbType.Int) {Value = s.Number},
                new SqlParameter("@manager", SqlDbType.Int) {Value = s.Manager.Id},
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
                string sql = "DELETE FROM Subsidiary WHERE id=@id";

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

        public static bool Update(Subsidiary s)
        {
            try
            {
                string sql = "UPDATE Subsidiary SET name=@name, city=@city, address=@address, phoneNumber=@number, manager=@manager WHERE id=@id;";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = s.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value=s.Name},
                new SqlParameter("@city", SqlDbType.VarChar) {Value = s.City},
                new SqlParameter("@address", SqlDbType.VarChar) {Value = s.Address},
                new SqlParameter("@number", SqlDbType.Int) {Value = s.Number},
                new SqlParameter("@manager", SqlDbType.Int) {Value = s.Manager.Id},
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

        public static Subsidiary GetSubsidiary(int pId)
        {
            try
            {
                string sql = "SELECT * FROM Subsidiary WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pId}
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];
                Controller c = new Controller();
                Manager m = c.FindManager(Convert.ToInt32(dr["manager"]));
                Subsidiary s = new Subsidiary(Convert.ToInt32(dr["id"]), dr["name"].ToString(), dr["city"].ToString(), dr["address"].ToString(), Convert.ToInt32(dr["phoneNumber"]), m);
                return s;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Subsidiary> ListSubsidiaries()
        {
            List<Subsidiary> Subsidiary = new List<Subsidiary>();
            try
            {
                string sql = "SELECT * FROM Subsidiary";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Controller c = new Controller();
                    Manager m = c.FindManager(Convert.ToInt32(dr["manager"]));
                    Subsidiary.Add(new Subsidiary(Convert.ToInt32(dr["id"]), dr["name"].ToString(), dr["city"].ToString(), dr["address"].ToString(), Convert.ToInt32(dr["phoneNumber"]), m));
                }

                return Subsidiary;
            }
            catch (Exception e)
            {
                return Subsidiary;
            }
        }
    }
}
