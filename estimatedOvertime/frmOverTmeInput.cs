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
    public partial class frmOverTmeInput : Form
    {
        public DateTime passedDate { get; set; }
        public frmOverTmeInput(DateTime selectedDate)
        {
            InitializeComponent();
            label1.Text = "Insert Over Time for ** " + selectedDate.ToString("yyyy-MM-dd") + " **";
            passedDate = selectedDate;
            //here we will just  add the same boys as the startup to mainfrm
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "select b.id AS [ID], b.forename + ' ' + b.surname as [Full Name], a.prior_work_day as [Prior Work Day OT],a.post_work_day as [Post Work Day OT] from dbo.staff_overtime a LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                    "WHERE [date] = '" + passedDate.ToString("yyyy-MM-dd") + "' AND b.isEngineer = -1 AND b.id <> 260 AND b.id <> 3 AND b.id <> 29  AND b.id <> 14 AND a.dept = 7  Order by forename ASC";
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
                        sql = "SELECT id as ID  FROM [user_info].dbo.[user] WHERE isEngineer = -1 AND id <> 260 AND id <> 3 AND id <> 29  AND id <> 14  Order by forename ASC ";
                        using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //MessageBox.Show(dt.Rows.Count.ToString());
                            foreach(DataRow row in dt.Rows)
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
                    "WHERE [date] = '" + passedDate.ToString("yyyy-MM-dd") + "' AND b.isEngineer = -1 AND a.dept = 7 AND b.id <> 260 AND b.id <> 3 AND b.id <> 29  AND b.id <> 14  Order by forename ASC";
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
            //now we need to add a column to enter ot


            //int staffIndex = 0;
            //staffIndex = dgOverTime.Columns["ID"].Index;
            //int priorIndex = 0;
            //priorIndex = dgOverTime.Columns["Prior Work Day OT"].Index;
            //int postIndex = 0;
            //postIndex = dgOverTime.Columns["Post Work Day OT"].Index;


            //here we are going to grab post and priot OT if it exists OTHERWISE we gonna null it boy
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //for (int i = 0; i  < dgOverTime.Rows.Count - 1;i++)
                //{
                //    //prior
                //    sql = "select prior_work_day from dbo.staff_overtime WHERE staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value + " AND date = '" + passedDate.ToString("yyyy-MM-dd") + "'";
                //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                //    {
                //        string temp = Convert.ToString(cmd.ExecuteScalar());
                //        if (temp == null)
                //            temp = "0";
                //        dgOverTime.Rows[i].Cells[priorIndex].Value = "6 " + temp.ToString();
                //        dgOverTime.EndEdit();
                //        dgOverTime.NotifyCurrentCellDirty(true);
                //        dgOverTime.EndEdit();
                //        dgOverTime.NotifyCurrentCellDirty(false);
                //    }
                //    //post
                //    sql = "select post_work_day from dbo.staff_overtime WHERE staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value + " AND date = '" + passedDate.ToString("yyyy-MM-dd") + "'"; 
                //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                //    {
                //        string temp = Convert.ToString(cmd.ExecuteScalar());
                //        if (temp == null)
                //            temp = "0";
                //        dgOverTime.Rows[i].Cells[postIndex].Value = "" + temp.ToString();
                //        dgOverTime.EndEdit();
                //        dgOverTime.NotifyCurrentCellDirty(true);
                //        dgOverTime.EndEdit();
                //        dgOverTime.NotifyCurrentCellDirty(false);
                //    }

                //}
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

        private void dgOverTime_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(OT_KeyPress);
            if (dgOverTime.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(OT_KeyPress);
                }
            }
        }

        private void OT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
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
                for (int i = 0; i < dgOverTime.Rows.Count;i++)
                {
                    //first we gotta check if there is data here
                    sql = "Select id from dbo.staff_overtime where date = '" + passedDate.ToString("yyyy-MM-dd")  + "' AND staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + " AND dept = 7";
                    using (SqlCommand command = new SqlCommand(sql,conn))
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
                                "WHERE date = '" + passedDate.ToString("yyyy-MM-dd") + "' AND staff_id = " + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + "AND dept = 7" ;
                        }
                        else //not true
                        {
                            //insert
                            sql = "INSERT INTO dbo.staff_overtime (staff_id,prior_work_day,post_work_day,date,dept) " +
                                "VALUES (" + dgOverTime.Rows[i].Cells[staffIndex].Value.ToString() + "," + prior + "," + post + ",'" + passedDate.ToString("yyyy-MM-dd") + "',7)";
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
