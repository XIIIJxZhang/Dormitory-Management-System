using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Dormitory_Management_System.Models {
    public class Functions {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private SqlDataAdapter sda;
        private string ConStr;

        public Functions() {
            ConStr = "Data Source=XIII-2205041012\\CSC3170TEST01;Initial Catalog=CSC3170dmsDB;Integrated Security=True";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(String Query) {
            DataTable dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(String Query) {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed) {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }

        // Method to test the database connection
        public bool TestConnection() {
            try {
                if (Con.State == ConnectionState.Closed) {
                    Con.Open();
                }
                return true; // If connection opens without exceptions, it's successful
            } catch (Exception) {
                return false; // If any error occurs, connection failed
            } finally {
                Con.Close();
            }
        }
    }
}