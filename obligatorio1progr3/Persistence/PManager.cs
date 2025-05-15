using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using obligatorio1progr3.Domain;
using obligatorio1progr3.Persistence;

namespace obligatorio1progr3.Persistence
{
    public static class PManager
    {
        public static bool alta(Manager m)
        {
            try
            {
                string sql = "INSERT INTO Manager(id, name, phoneNumber) VALUES (@id, @name, @phoneNumber);";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = m.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value=m.Name},
                new SqlParameter("@phoneNumber", SqlDbType.VarChar) {Value=m.PhoneNumber}
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

        public static bool baja(int pId)
        {
            try
            {
                string sql = "DELETE FROM Manager WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pId}
                };

                if (Conexion.Consulta(sql, parametros))
                    return true;

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e);
                return false;
            }
        }

        public static bool modificar(Manager m)
        {
            try
            {
                string sql = "UPDATE Manager SET name=@name, phoneNumber=@phoneNumber WHERE id=@id;";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = m.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value=m.Name},
                new SqlParameter("@phoneNumber", SqlDbType.VarChar) {Value=m.PhoneNumber}
                };

                if (Conexion.Consulta(sql, parametros))
                    return true;

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e);
                return false;
            }
        }

        public static Manager conseguir(int pId)
        {
            try
            {
                string sql = "SELECT * FROM Manager WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pId}
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];

                Manager m = new Manager(Convert.ToInt32(dr["id"]), dr["name"].ToString(), Convert.ToInt32(dr["phoneNumber"]));
                return m;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Manager> listar()
        {
            List<Manager> managers = new List<Manager>();
            try
            {
                string sql = "SELECT * FROM Manager";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    managers.Add(new Manager(Convert.ToInt32(dr["id"]), dr["name"].ToString(), Convert.ToInt32(dr["phoneNumber"])));
                }

                return managers;
            }
            catch (Exception e)
            {
                return managers;
            }
        }
    }
}

