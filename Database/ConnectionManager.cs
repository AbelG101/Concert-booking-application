using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject.Database
{
    public class ConnectionManager
    {
        private static string conString;
        private static SqlConnection con;
        private static SqlDataReader rdr;
        private static SqlCommand cmd;
        private static DataTable table;
        private static int rowsAffected;
        public static SqlConnection GetConnection()
        {
            conString = ConfigurationManager.ConnectionStrings["concertDB"].ConnectionString;
            return new SqlConnection(conString);
        }

        public static DataTable GetData(string query, List<SqlParameter> parameters)
        {
            using (con = GetConnection())
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    foreach ( SqlParameter parameter in parameters )
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    rdr = cmd.ExecuteReader();
                    table = new DataTable();
                    table.Load(rdr);
                } catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cmd.Parameters.Clear();
                return table;
            }
        }

        public static DataTable GetData(string query)
        {
            using (con = GetConnection())
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    rdr = cmd.ExecuteReader();
                    table = new DataTable();
                    table.Load(rdr);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return table;
            }
        }

        public static int UpdateDatabase(string query, List<SqlParameter> parameters)
        {
            try
            {
                using (con = GetConnection())
                {
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            } catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Parameters.Clear();
            return rowsAffected;
        }

        public static int UpdateDatabase(string query)
        {
            using (con = GetConnection())
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return rowsAffected;
            }
        }
    }
}
