using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using obligatorio1progr3.Domain;
using obligatorio1progr3.Persistence;

namespace obligatorio1progr3.Persistence
{
    public static class PAdult
    {
        public static string alta(Adult a)
        {
            try
            {
                string sql = "INSERT INTO Adult(id, name, mail, phoneNumber, subsidiaryId) VALUES (@id, @name, @mail, @phoneNumber, @subsidiaryId);";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = a.Id},
                    new SqlParameter("@name", SqlDbType.VarChar) {Value = a.Name},
                    new SqlParameter("@mail", SqlDbType.VarChar) {Value = a.Mail},
                    new SqlParameter("@phoneNumber", SqlDbType.BigInt) {Value = a.PhoneNumber},
                    new SqlParameter("@subsidiaryId", SqlDbType.Int) {Value = a.Subsidiary.Id}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Adult successfully added";

                return "Error adding adult";
            }
            catch (Exception e)
            {
                return $"Error adding adult: {e.Message}";
            }
        }

        public static string baja(int id)
        {
            try
            {
                string sql = "DELETE FROM Adult WHERE id = @id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = id}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Adult removed successfully";

                return "Error removing adult";
            }
            catch (Exception e)
            {
                return $"Error removing adult: {e.Message}";
            }
        }

        public static string modificar(Adult a)
        {
            try
            {
                string sql = "UPDATE Adult SET name = @name, mail = @mail, phoneNumber = @phoneNumber, subsidiaryId = @subsidiaryId WHERE id = @id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = a.Id},
                    new SqlParameter("@name", SqlDbType.VarChar) {Value = a.Name},
                    new SqlParameter("@mail", SqlDbType.VarChar) {Value = a.Mail},
                    new SqlParameter("@phoneNumber", SqlDbType.BigInt) {Value = a.PhoneNumber},
                    new SqlParameter("@subsidiaryId", SqlDbType.Int) {Value = a.Subsidiary.Id}
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Adult updated successfully";

                return "Error updating adult";
            }
            catch (Exception e)
            {
                return $"Error updating adult: {e.Message}";
            }
        }

        public static Adult conseguir(int id)
        {
            try
            {
                string sql = "SELECT * FROM Adult WHERE id = @id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Value = id}
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];

                // Supone que Subsidiary también tiene una forma de conseguir el objeto
                Subsidiary s = PSubsidiary.GetSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));

                Adult a = new Adult(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString(),
                    dr["mail"].ToString(),
                    Convert.ToInt32(dr["phoneNumber"]),
                    s
                );

                return a;
            }
            catch
            {
                return null;
            }
        }

        public static List<Adult> listar()
        {
            List<Adult> adults = new List<Adult>();

            try
            {
                string sql = "SELECT * FROM Adult";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Subsidiary s = PSubsidiary.GetSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));

                    adults.Add(new Adult(
                        Convert.ToInt32(dr["id"]),
                        dr["name"].ToString(),
                        dr["mail"].ToString(),
                        Convert.ToInt32(dr["phoneNumber"]),
                        s
                    ));
                }

                return adults;
            }
            catch
            {
                return adults;
            }
        }
    }
}
