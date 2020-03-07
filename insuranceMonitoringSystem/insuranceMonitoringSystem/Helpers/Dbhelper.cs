using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using insuranceMonitoringSystem.Constants;
using Microsoft.EntityFrameworkCore;

namespace insuranceMonitoringSystem.Helpers
{
    
    public class Dbhelper
    {
        protected static string cs = Constants.Constants.connString;
        public static DataTable GetDbData(string sql)
        {
            DataTable rm = new DataTable();
           

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlDataAdapter adpter = new SqlDataAdapter(sql, conn))
                {

                    adpter.Fill(rm);

                }
                conn.Close();

            }

            return rm;
        }

        public static void processData(string sql)
        {
            DataTable rm = new DataTable();
           
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();


                using (SqlDataAdapter adpter = new SqlDataAdapter())
                {
                    adpter.InsertCommand = new SqlCommand(sql, conn);
                    adpter.InsertCommand.ExecuteNonQuery();

                    //adpter.Fill(rm);

                }
                conn.Close();
            }


        }
    }

   
}

