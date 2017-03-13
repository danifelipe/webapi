using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comun;
using System.Data.SqlClient;
using System.Configuration;
using Comun.Entidades;
using System.Data;

namespace CrudWebApiEnsayo.Dal
{
    public class Conexion
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        public IEnumerable<Pais> consultarPais()
        {
            connection();
            List<Pais> list = new List<Pais>();
            SqlCommand com = new SqlCommand("spConsultarPais", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Pais
                    {
                        idPais = Convert.ToInt32(dr["idPais"]),
                        nombrePais = Convert.ToString(dr["nombrePais"])
                    }
                    );
            }
            return list;
        }
        public IEnumerable<Bandas> consultarBanda()
        {
            connection();
            List<Bandas> list = new List<Bandas>();
            SqlCommand com = new SqlCommand("spConsultarBandas", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Bandas
                    {
                        idBanda = Convert.ToInt32(dr["idBanda"]),
                        nombreBanda = Convert.ToString(dr["nombreBanda"]),
                        nombrePais = Convert.ToString(dr["nombrePais"])
                    }
                    );
            }
            return list;
        }
        public bool insertarBanda(Bandas banda)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("spInsertarBandas", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@idPais", banda.idPais);
                com.Parameters.AddWithValue("@nombreBanda", banda.nombreBanda);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Bandas consultarBandaid(int idBanda)
        {
            connection();
            Bandas bn = new Bandas();
            SqlCommand com = new SqlCommand("spConsultarBanda", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idBanda", idBanda);

            con.Open();
            IDataReader reader = com.ExecuteReader();
            
            while (reader.Read())
            {
                bn.idBanda = Convert.ToInt32(reader["idBanda"]);
                bn.nombreBanda = Convert.ToString(reader["nombreBanda"]);
                bn.idPais = Convert.ToInt32(reader["idPais"]);
            }
            con.Close();
            return bn;
        }
        public bool modificarBanda(Bandas banda)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("spModificarBanda", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@idBanda", banda.idBanda);
                com.Parameters.AddWithValue("@idPais", banda.idPais);
                com.Parameters.AddWithValue("@nombreBanda", banda.nombreBanda);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool eliminarBanda(int idBanda)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("spEliminarBanda", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@idBanda", idBanda);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}