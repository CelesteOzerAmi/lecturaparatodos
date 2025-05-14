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
        public static string alta(Manager m)
        {
            try
            {
                string sql = "INSERT INTO managers(id, name, phoneNumber) VALUES (@id, @name, @phoneNumber);";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = m.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value=m.Name},
                new SqlParameter("@phoneNumber", SqlDbType.VarChar) {Value=m.PhoneNumber}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Manager successfully added";

                return "Error removing manager";
            }
            catch (Exception e)
            {
                return $"Error removing manager {e.Message}";
            }

        }
        public static string baja(int pCi)
        {
            try
            {
                string sql = "DELETE FROM managers WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pCi}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Manager removed successfully";

                return "Error removing manager";
            }
            catch (Exception e)
            {
                return $"Error removing manager {e.Message}";
            }
        }
        public static string modificar(Manager m)
        {
            try
            {
                string sql = "UPDATE managers SET name=@name, phoneNumber=@phoneNumber WHERE id=@id;";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = m.Id},
                new SqlParameter("@name", SqlDbType.VarChar) {Value=m.Name},
                new SqlParameter("@phoneNumber", SqlDbType.VarChar) {Value=m.PhoneNumber}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Manager removed successfully";

                return "Error removing manager";

            }
            catch (Exception e)
            {
                return $"Error removing manager {e.Message}";
            }

        }
        public static Manager conseguir(int pCi)
        {
            try
            {
                string sql = "SELECT * FROM managers WHERE id=@id";

                SqlParameter[] parametros =
                {
                new SqlParameter("@id", SqlDbType.Int) {Value = pCi}
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

