using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using obligatorio1progr3.Domain;
using obligatorio1progr3.Persistence;

namespace obligatorio1progr3.Persistence
{
    public static class PSenior
    {
        public static string Alta(Senior s)
        {
            try
            {
                string sql = "INSERT INTO Senior(id, name, mail, phoneNumber, subsidiaryId, discount) VALUES (@id, @name, @mail, @phoneNumber, @subsidiaryId, @discount);";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = s.Id },
                    new SqlParameter("@name", SqlDbType.VarChar) { Value = s.Name },
                    new SqlParameter("@mail", SqlDbType.VarChar) { Value = s.Mail },
                    new SqlParameter("@phoneNumber", SqlDbType.Int) { Value = s.PhoneNumber },
                    new SqlParameter("@subsidiaryId", SqlDbType.Int) { Value = s.Subsidiary.Id },
                    new SqlParameter("@discount", SqlDbType.Bit) { Value = s.Discount }
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Senior successfully added";

                return "Error adding senior";
            }
            catch (Exception e)
            {
                return $"Error adding senior: {e.Message}";
            }
        }

        public static string Baja(int id)
        {
            try
            {
                string sql = "DELETE FROM Senior WHERE id = @id;";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                if (Conexion.Consulta(sql, parametros))
                    return "Senior removed successfully";

                return "Error removing senior";
            }
            catch (Exception e)
            {
                return $"Error removing senior: {e.Message}";
            }
        }

        public static bool Modificar(Senior s)
        {
            try
            {
                string sql = "UPDATE Senior SET name=@name, mail=@mail, phoneNumber=@phoneNumber, subsidiaryId=@subsidiaryId, discount=@discount WHERE id=@id;";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = s.Id },
                    new SqlParameter("@name", SqlDbType.VarChar) { Value = s.Name },
                    new SqlParameter("@mail", SqlDbType.VarChar) { Value = s.Mail },
                    new SqlParameter("@phoneNumber", SqlDbType.Int) { Value = s.PhoneNumber },
                    new SqlParameter("@subsidiaryId", SqlDbType.Int) { Value = s.Subsidiary.Id },
                    new SqlParameter("@discount", SqlDbType.Bit) { Value = s.Discount }
                };

                if (Conexion.Consulta(sql, parametros))
                    return true;

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Senior Conseguir(int id)
        {
            try
            {
                string sql = "SELECT * FROM Senior WHERE id=@id";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                DataSet ds = Conexion.Seleccion(sql, parametros);
                DataRow dr = ds.Tables[0].Rows[0];

                Subsidiary sub = PSubsidiary.GetSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));
                Senior s = new Senior(Convert.ToInt32(dr["id"]), dr["name"].ToString(), dr["mail"].ToString(), Convert.ToInt32(dr["phoneNumber"]), sub, Convert.ToBoolean(dr["discount"]));
                return s;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Senior> Listar()
        {
            List<Senior> seniors = new List<Senior>();
            try
            {
                string sql = "SELECT * FROM Senior";

                DataSet ds = Conexion.Seleccion(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Subsidiary sub = PSubsidiary.GetSubsidiary(Convert.ToInt32(dr["subsidiaryId"]));
                    seniors.Add(new Senior(Convert.ToInt32(dr["id"]), dr["name"].ToString(), dr["mail"].ToString(), Convert.ToInt32(dr["phoneNumber"]), sub, Convert.ToBoolean(dr["discount"])));
                }

                return seniors;
            }
            catch (Exception)
            {
                return seniors;
            }
        }
    }
}
