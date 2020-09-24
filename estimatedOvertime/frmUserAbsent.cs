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
    public partial class frmUserAbsent : Form
    {
        public int _staff_id { get; set; }
        public string _start { get; set; }
        public string _end { get; set; }
        public frmUserAbsent(int staff_id,string start,string end)
        {
            InitializeComponent();
            _staff_id = staff_id;
            _start = start;
            _end = end;
            //grab the users uhhhhhhh dates of absent
            string sql = "select date_absent AS[Date],CASE WHEN absent_type = 2 then 'FULL DAY' WHEN absent_type = 3 then 'HALF DAY' WHEN absent_type = 8 then 'FULL DAY' WHEN absent_type = 9 then 'UNPAID' WHEN absent_type = 5 then 'ABSENT' END AS[Type]" +
                                " from dbo.absent_holidays WHERE staff_id = " + staff_id + " AND date_absent >= '" + start + "' AND date_absent <= '" + end + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                //now we also need to grab potential temp days off
                //and put them into a seperate grid
                sql = "SELECT date_start as [Provisional Start Date], date_end as [Provisional End Date] FROM dbo.staff_provisional_absences WHERE staff_id = " + staff_id;
                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgTemp.DataSource = dt;
                }
                    conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT forename + ' ' + surname FROM dbo.[user] WHERE id = " + staff_id.ToString(), conn))
                {
                    string name = cmd.ExecuteScalar().ToString();
                    label1.Text =  name + "'s Absences between  " + start + " ~ " + end + " ";
                }
                conn.Close();
            }
            //format the stuffs 
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            

        }

        private void btnAddDates_Click(object sender, EventArgs e)
        {
            //dbo.staff_provisional_absences
            frmTempAbsentDates frmTAD = new frmTempAbsentDates(_staff_id);
            frmTAD.ShowDialog();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT date_start as [Provisional Start Date], date_end as [Provisional End Date] FROM dbo.staff_provisional_absences WHERE staff_id = " + _staff_id;
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgTemp.DataSource = dt;
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "DELETE FROM dbo.staff_provisional_absences WHERE staff_id = " + _staff_id;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                 sql = "SELECT date_start as [Provisional Start Date], date_end as [Provisional End Date] FROM dbo.staff_provisional_absences WHERE staff_id = " + _staff_id;
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgTemp.DataSource = dt;
                }

                conn.Close();
            }
        }
    }
}
