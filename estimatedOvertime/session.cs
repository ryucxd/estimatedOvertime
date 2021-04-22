using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using estimatedOvertime;

namespace Estimating_Issue_Log
{
    class session
    {
        public string username { get; set; }
        public string password { get; set; }
        public string ID { get; set; }

        public int engineerManager { get; set; }
        public bool isOfficeManager { get; set; }
        public bool passwordWrong { get; set; }

        //capture login for user  THEY HAVE TO HAVE /IS ENGINEER/ ENABLED
        public void login(string _username, string _password)
        {
            username = _username;
            password = _password;
            check_login();
        }

        private void check_login()
        {
            string sql = " ";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                //first check if the password or username is correct
                sql = "SELECT COALESCE(id,0) FROM dbo.[user] WHERE username = '" + username + "' AND password = '" + password + "';";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    ID = Convert.ToString(cmd.ExecuteScalar());
                    conn.Close();
                    if (ID == "0" || string.IsNullOrEmpty(ID))
                    {
                        passwordWrong = true;
                        isOfficeManager = false;
                        return;
                    }
                }
                //now check if they are an engineer
                sql = "SELECT COALESCE(isEngineer,0) FROM dbo.[user] WHERE id = " + Convert.ToString(ID) + ";";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    int placeHolder = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    if (placeHolder == -1)
                        isOfficeManager = true;
                    else
                        isOfficeManager = false;

                }
                //pick up if they are a engineer manager too
                sql = "SELECT COALESCE(engineerManager,0) FROM dbo.[user] WHERE id = " + ID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    engineerManager = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
        }
    }
}
