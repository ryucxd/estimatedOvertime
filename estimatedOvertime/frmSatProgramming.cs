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
    public partial class frmSatProgramming : Form
    {
        public DateTime _passedDate { get; set; }
        public frmSatProgramming(DateTime passedDate, int pickedSat) //picked sat -1 means that they went through the form to select a saturday
        {
            InitializeComponent();
            label1.Text = "Insert Over Time for ** " + passedDate.ToString("yyyy-MM-dd") + " **";
            _passedDate = passedDate;
            //here we load the dates just like the normal overtime form
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "select b.id AS [ID], b.forename + ' ' + b.surname as [Full Name], a.prior_work_day as [Prior Work Day OT],a.post_work_day as [Post Work Day OT] from dbo.staff_overtime a LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                    "WHERE [date] = '" + passedDate.ToString("yyyy-MM-dd") + "' AND b.isEngineer = -1 AND a.dept = 7 AND b.id <> 260 AND b.id <> 3 AND b.id <> 29  AND b.id <> 14  Order by forename ASC";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //use a reader to check if its null real quick
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        rdr.Close();//nothin
                    }
                    else
                    {
                        rdr.Close();
                        //we gotta nsert the date into dbo.staff here
                        sql = "SELECT distinct  [user_info].dbo.[user].id as ID  FROM [user_info].dbo.[user] LEFT JOIN  dbo.staff_overtime b on b.staff_id = [user_info].dbo.[user].id WHERE isEngineer = -1  AND [user_info].dbo.[user].id <> 3 AND[user_info].dbo.[user].id <> 29  AND[user_info].dbo.[user].id <> 14 AND b.dept = 7  ";
                            using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //MessageBox.Show(dt.Rows.Count.ToString());
                            foreach (DataRow row in dt.Rows)
                            {
                                sql = "INSERT INTO dbo.staff_overtime (staff_id,[date],prior_work_day,post_work_day,dept) VALUES (" + row["ID"].ToString() + ",'" + passedDate.ToString("yyyy-MM-dd") + "',0,0,7)";
                                using (SqlCommand cmd3 = new SqlCommand(sql, conn))
                                    cmd3.ExecuteNonQuery();
                            }
                            dt.Dispose();
                        }
                    }
                    rdr.Close();
                    cmd.Dispose();
                }
                sql = "select b.id AS [ID], b.forename + ' ' + b.surname as [Full Name], a.prior_work_day as [Prior Work Day OT],a.post_work_day as [Post Work Day OT] from dbo.staff_overtime a LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                    "WHERE [date] = '" + passedDate.ToString("yyyy-MM-dd") + "' AND b.isEngineer = -1 AND b.id <> 260 AND b.id <> 3 AND b.id <> 29 AND a.dept = 7  AND b.id <> 14  Order by forename ASC";
                using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                {
                    //use a reader to check if its null real quick
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dgOverTime.DataSource = dt2;

                    dgOverTime.Refresh();
                }
                conn.Close();
            }
            //formatting
            dgOverTime.Columns[0].Visible = false; //ID
            dgOverTime.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgOverTime.Columns[1].ReadOnly = true;
            dgOverTime.Columns[2].ReadOnly = false;
            dgOverTime.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[3].ReadOnly = false;
            dgOverTime.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dgOverTime.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgOverTime.ClearSelection();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //same as the other form again :}
            //we gon add to the table here
            string sql = "";

            //we dont trust the columns :}
            int staffIndex = 0;
            staffIndex = dgOverTime.Columns["ID"].Index;
            int priorIndex = 0;
            priorIndex = dgOverTime.Columns["Prior Work Day OT"].Index;
            int postIndex = 0;
            postIndex = dgOverTime.Columns["Post Work Day OT"].Index;



            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int i = 0; i < dgOverTime.Rows.Count; i++)
                {
                    //first we gotta check if there is data here
                    sql = "Select id from dbo.staff_overtime where date = '" + _passedDate.ToString("yyyy-MM-dd") + "' AND staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        //quick changes :)
                        decimal prior = 0, post = 0;
                        prior = Convert.ToDecimal(dgOverTime.Rows[i].Cells[priorIndex].Value); //?? Convert.ToDecimal(0);
                        post = Convert.ToDecimal(dgOverTime.Rows[i].Cells[postIndex].Value); //?? Convert.ToDecimal(0);
                        var exists = command.ExecuteScalar();
                        if (exists != null) //if its true
                        {
                            //update
                            sql = "UPDATE dbo.staff_overtime SET prior_work_day = " + prior.ToString() + ", post_work_day = " + post.ToString() + ", dept = 7 " +
                                "WHERE date = '" + _passedDate.ToString("yyyy-MM-dd") + "' AND staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + " AND dept = 7";
                        }
                        else //not true
                        {
                            //insert
                            sql = "INSERT INTO dbo.staff_overtime (staff_id,prior_work_day,post_work_day,date,dept) " +
                                "VALUES (" + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + "," + prior + "," + post + ",'" + _passedDate.ToString("yyyy-MM-dd") + "',7)";
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
                this.Close();
            }
        }
    }
}
