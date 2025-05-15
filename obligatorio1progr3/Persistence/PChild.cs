using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using obligatorio1progr3.Domain;
using obligatorio1progr3.Persistence;

namespace obligatorio1progr3.Persistence
{
    public static class PChild
    {
        public static string alta(Child c)
        {
            try
            {
                string sql = "INSERT INTO Child(id, name, mail, phoneNumber, subsidiaryId, authorized) VALUES (@id, @name, @mail, @phoneNumber, @subsidiaryId, @authorized);";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = c.Id},
                    new SqlParameter("@name", SqlDbType.VarChar) {Value = c.Name},
                    new SqlParameter("@mail", SqlDbType.VarChar) {Value = c.Mail},
                    new SqlParameter("@phoneNumber", SqlDbType.BigInt) {Value = c.PhoneNumber},
                    new SqlParameter("@subsidiaryId", SqlDbType.Int) {Value = c.Subsidiary.Id},
                    new SqlParameter("@authorized", SqlDbType.Bit) {Value = c.Authorized}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Child successfully added";

                return "Error adding child";
            }
            catch (Exception e)
            {
                return $"Error adding child: {e.Message}";
            }
        }

        public static string baja(int id)
        {
            try
            {
                string sql = "DELETE FROM Child WHERE id = @id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = id}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Child removed successfully";

                return "Error removing child";
            }
            catch (Exception e)
            {
                return $"Error removing child: {e.Message}";
            }
        }

        public static string modificar(Child c)
        {
            try
            {
                string sql = "UPDATE Child SET name = @name, mail = @mail, phoneNumber = @phoneNumber, subsidiaryId = @subsidiaryId, authorized = @authorized WHERE id = @id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = c.Id},
                    new SqlParameter("@name", SqlDbType.VarChar) {Value = c.Name},
                    new SqlParameter("@mail", SqlDbType.VarChar) {Value = c.Mail},
                    new SqlParameter("@phoneNumber", SqlDbType.BigInt) {Value = c.PhoneNumber},
                    new SqlParameter("@subsidiaryId", SqlDbType.Int) {Value = c.Subsidiary.Id},
                    new SqlParameter("@authorized", SqlDbType.Bit) {Value = c.Authorized}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Child updated successfully";

                return "Error updating child";
            }
            catch (Exception e)
            {
                return $"Error updating child: {e.Message}";
            }
        }

        public static Child conseguir(int id)
        {
            try
            {
                string sql = "SELECT * FROM Child WHERE id = @id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = id}
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];

                Subsidiary s = PSubsidiary.GetSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));

                Child c = new Child(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString(),
                    dr["mail"].ToString(),
                    Convert.ToInt32(dr["phoneNumber"]),
                    s,
                    Convert.ToBoolean(dr["authorized"])
                );

                return c;
            }
            catch
            {
                return null;
            }
        }

        public static List<Child> listar()
        {
            List<Child> children = new List<Child>();

            try
            {
                string sql = "SELECT * FROM Child";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Subsidiary s = PSubsidiary.GetSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));

                    children.Add(new Child(
                        Convert.ToInt32(dr["id"]),
                        dr["name"].ToString(),
                        dr["mail"].ToString(),
                        Convert.ToInt32(dr["phoneNumber"]),
                        s,
                        Convert.ToBoolean(dr["authorized"])
                    ));
                }

                return children;
            }
            catch
            {
                return children;
            }
        }
    }
}
