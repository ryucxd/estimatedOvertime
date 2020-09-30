using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace estimatedOvertime
{
    public partial class frmUserOT : Form
    {
        public frmUserOT(int passedStaffID,string startDate, string endDate)
        {
            InitializeComponent();
            //here we are going to use the staff id and the two selected dates
            //and show who has overtime and when

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT date as [Date] ,prior_work_day as [Prior Work Day],post_work_day as [Post Work Day] FROM dbo.staff_overtime a " +
                    "LEFT JOIN [user_info].dbo.[user] b ON a.staff_id = b.id WHERE staff_id = " + passedStaffID + " AND date >= '" + startDate + "' AND date <= '" + endDate + "' " +
                    " AND (prior_work_day > 0 OR post_work_day > 0) ORDER BY date asc " ;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                    conn.Close();
            }

            //now grab users name and use it for form caption etcccccccc
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT forename + ' ' + surname FROM dbo.[user] WHERE id = " + passedStaffID.ToString(),conn))
                {
                    string name = cmd.ExecuteScalar().ToString();
                    label1.Text = "Assigned over time for " + name + " between " + startDate + " ~ " + endDate + " ";
                }
                conn.Close();
            }
            //format the stuffs 
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
