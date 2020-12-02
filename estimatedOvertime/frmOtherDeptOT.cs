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
    public partial class frmOtherDeptOT : Form
    {
        public DateTime passedDate { get; set; }
        public int validation { get; set; }
        public frmOtherDeptOT(DateTime selectedDate)
        {
            InitializeComponent();
            label1.Text = "Insert Over Time for ** " + selectedDate.ToString("yyyy-MM-dd") + " **";
            passedDate = selectedDate;
            validation = -1;

            //load the names
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "select forename + ' ' + surname as [Name], id ,[grouping] from [user_info].dbo.[user] where [grouping] is not null and (slimline is null or slimline = 0) and [current] = 1 AND[grouping] <> 15 AND[grouping] <> 25 AND[grouping] <> 10 AND id<> 314 " +
                    "AND id<> 226 AND id<> 4 AND id<> 27 AND id<> 28 order by [user_info].dbo.[user].[grouping] asc, forename asc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }

                //add the other column
                dt.Columns.Add("Prior Work Day");
                dt.Columns.Add("Post Work Day");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    sql = "select SUM(COALESCE(prior_work_day,0)) [Prior Shift Start] FROM dbo.staff_overtime WHERE date = '" + passedDate.ToString("yyyy-MM-dd") + "' AND staff_id = " + dt.Rows[i][1].ToString() + " AND dept <> 7";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dt.Rows[i][3] = Convert.ToString(cmd.ExecuteScalar());
                        if (dt.Rows[i][3].ToString() == "")
                            dt.Rows[i][3] = "0";
                    }
                    sql = "select SUM(COALESCE(post_work_day,0)) [Post Shift Start] FROM dbo.staff_overtime WHERE date = '" + passedDate.ToString("yyyy-MM-dd") + "' AND staff_id = " + dt.Rows[i][1].ToString() + " AND dept <> 7";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dt.Rows[i][4] = Convert.ToString(cmd.ExecuteScalar());
                        if (dt.Rows[i][4].ToString() == "")
                            dt.Rows[i][4] = "0";
                    }
                }


                conn.Close();
                dgOverTime.DataSource = dt;
                dgOverTime.Columns[1].Visible = false;//ID
                dgOverTime.Columns[2].Visible = false;//grouping
                dgOverTime.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgOverTime.Columns[0].ReadOnly = true;
                dgOverTime.Columns[3].ReadOnly = false;
                dgOverTime.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgOverTime.Columns[4].ReadOnly = false;
                dgOverTime.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            validation = -1;
            this.Close();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //go through each one 
            int staffIndex = 0;
            staffIndex = dgOverTime.Columns["ID"].Index;
            int priorIndex = 0;
            priorIndex = dgOverTime.Columns["Prior Work Day"].Index;
            int postIndex = 0;
            postIndex = dgOverTime.Columns["Post Work Day"].Index;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "";
                for (int i = 0; i < dgOverTime.Rows.Count; i++)
                {
                    //sort out grouping/dept
                    int staffID = Convert.ToInt32(dgOverTime.Rows[i].Cells[1].Value);
                    int dept = 0;
                    switch (staffID)
                    {
                        case 13: //gez
                            dept = 8;
                            break;
                        case 14://kai
                            dept = 8; //kai conflicts with mainscreen as a programmer so im putting him as office 
                            break;
                        case 241://Tim
                            dept = 30;
                            break;
                        case 260://me me me me me
                            dept = 8; //office is the closest thing for me i guess
                            break;
                        default:
                            dept = 27; //default the estimating boys 
                            break;
                    }

                    //first we gotta check if there is data here
                    sql = "Select id from dbo.staff_overtime where date = '" + passedDate.ToString("yyyy-MM-dd") + "' AND staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + " AND dept = " + dept.ToString();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        //quick changes :}
                        decimal prior = 0, post = 0;
                        prior = Convert.ToDecimal(dgOverTime.Rows[i].Cells[priorIndex].Value); //?? Convert.ToDecimal(0);
                        post = Convert.ToDecimal(dgOverTime.Rows[i].Cells[postIndex].Value); //?? Convert.ToDecimal(0);
                        var exists = command.ExecuteScalar();
                        if (exists != null) //if its true
                        {
                            //update

                            sql = "UPDATE dbo.staff_overtime SET prior_work_day = " + prior.ToString() + ", post_work_day = " + post.ToString() + ", dept = " + dept +
                                " WHERE date = '" + passedDate.ToString("yyyy-MM-dd") + "' AND staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + "AND dept = " + dept + "";
                        }
                        else //not true
                        {
                            //insert
                            sql = "INSERT INTO dbo.staff_overtime (staff_id,prior_work_day,post_work_day,date,dept) " +
                                "VALUES (" + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + "," + prior + "," + post + ",'" + passedDate.ToString("yyyy-MM-dd") + "'," + dept + ")";
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
                validation = -1;
                this.Close();                
            }

        }

        private void dgOverTime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmOtherDeptOT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (validation == 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save the Over Time you have entered?", "!!!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    btnCommit.PerformClick();
                }
            }
        }

        private void dgOverTime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgOverTime_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            validation = 0;
        }
    }
}
