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
using complaintProgramInput;

namespace estimatedOvertime
{
    public partial class Form1 : Form
    {

        public int totalDoors { get; set; }
        public int totalHours { get; set; }
        public Form1()
        {
            InitializeComponent();

            //grab each programmer  and throw them in a dgv

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id, forename + ' ' + surname as fullName FROM dbo.[user] WHERE isEngineer = -1 AND id <> 260 AND id <> 3 AND id <> 29 AND id <> 13 AND id <> 14AND id <> 241 ", conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //if overtime was clicked we need to wipe that for readability
            if (dataGridView2.DataSource != null)
            {
                dataGridView2.DataSource = null;
                dataGridView2.Columns.Clear();
                lblOTHours.Visible = false;
                lblOTTitle.Visible = false;
                lblOT.Visible = false;
            }

            //make the labels visible
            lblDoors.Visible = true;
            lblHours.Visible = true;
            lblTitle.Visible = true;
            lblOTdoors.Visible = true;

         

          

            string sql = "";
            //okay so the first direction i want to head in is getting nextweek back on button click
            //and maybedump it into a dgv or something
            //two strings for the dates (with 10 working days added to them)
            DateTime startDate;
            DateTime endDate;

            //work out the 10 working day difference here before adding it to the string using func_work_days_plus

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                sql = "SELECT dbo.func_work_days_plus('" + dteStart.Value.ToString("yyyy-MM-dd") + "', 10)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    startDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    conn.Close();
                }
                sql = "SELECT dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyy-MM-dd") + "', 10)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    endDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE(b.programed_by_id IS NULL) AND(a.status_id = 1 OR a.status_id = 2) " +
                     "AND(c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND(a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND(a.door_type_id <> 113) AND(a.order_number <> 'Bridge Street Cut Downs') AND " +
                     "a.date_completion >= '" + startDate.ToString("yyyy-MM-dd") + "' AND a.date_completion <= '" + endDate.ToString("yyyy-MM-dd") + "' ";
            //MessageBox.Show(sql);
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    totalDoors = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
                //gonna look at adding the lates here too
                int lates = 0;
                sql = "SELECT COUNT(a.id) AS [Number of Doors] FROM dbo.door AS a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id " +
                    "WHERE(b.programed_by_id IS NULL) AND(a.status_id = 1 OR a.status_id = 2) AND(c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND(a.date_completion IS NOT NULL) AND(a.door_type_id <> 48)" +
                    " AND(a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND date_completion < '" + startDate.ToString("yyyy-MM-dd") + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    totalDoors = totalDoors + Convert.ToInt32(cmd.ExecuteScalar());
                    lates = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    
                }

                lblDoors.Text = "Number of doors between " + startDate.ToShortDateString() + " and  " + endDate.ToShortDateString() + " = " + totalDoors + " (number of lates " + lates.ToString() + ")";

                //thats the BASE of the doors sorted (doesnt include onholds etc)


                if (dataGridView1.Columns.Contains("Monday-Thursday") == true)
                    {
                        dataGridView1.Columns.Remove("Monday-Thursday");
                    }
                if (dataGridView1.Columns.Contains("Friday") == true)
                {
                    dataGridView1.Columns.Remove("Friday");
                }
                //now we need to grab each day that people are off
                dataGridView1.Columns.Add("Monday-Thursday", "Monday-Thursday");
                dataGridView1.Columns.Add("Friday", "Friday");
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //mon -thurs
                    sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) <>'Friday' THEN 1 ELSE 0 END),0) as [monday-thursday]" +
                        " FROM dbo.absent_holidays WHERE date_absent > '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent < CAST(DATEADD(day,8,'" + dteEnd.Value.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        int mon_thurs = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                        row.Cells[2].Value = mon_thurs;
                    }
                    //friday
                    sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) = 'Friday' THEN 1 ELSE 0 END),0) as [monday-thursday]" +
                       " FROM dbo.absent_holidays WHERE date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= CAST(DATEADD(day,8,'" + dteEnd.Value.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        int fri = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                        row.Cells[3].Value = fri;
                    }
                }

                //now we have everyones days off 8D
                //we need to work how how many hours can be done a week!
                //in future we also need to check for bank hols etc unless its covered in the absent table


                //usp_calc_estimated_OT 
                //^^ this counts every day and adds hours based on how many working days are between each date
                int hours = 0;
                using (SqlConnection con = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_calc_estimated_OT", conn)
                    { CommandType = System.Data.CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = dteStart.Value.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@endDate", SqlDbType.VarChar).Value = dteEnd.Value.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@if", SqlDbType.VarChar).Value = 0;
                        conn.Open();
                        hours = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                }
                //because this is going to be the same answer everytime 
                //we can just * the first result by the number of people in deptartments
                hours = hours * Convert.ToInt32(dataGridView1.Rows.Count);

                //before we go into the loop we need to work out how many working days are between X + Y
                int remove_hours = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //now we are going to remove X amount from hours based on the days they have off
                    remove_hours = (Convert.ToInt32(row.Cells[2].Value) * 8) + (Convert.ToInt32(row.Cells[3].Value) * 7);
                    hours = hours - remove_hours;
                }
                
                lblHours.Text = "Total hours between the two selected dates (no overtime) = " + hours.ToString();
                totalHours = hours;
                if (totalDoors < totalHours)
                {
                    //no overtime is needed 8D
                    btnAvoidOT.Enabled = false;
                    lblNoOverTimeNeeded.Visible = true;
                    btnCalculate.Enabled = false;
                }
                else
                {
                    btnAvoidOT.Enabled = true;
                    btnCalculate.Enabled = true;
                    lblNoOverTimeNeeded.Visible = false;
                }
            }
            int otDoors = totalHours - totalDoors;
            if (otDoors < 0)
                otDoors = otDoors * -1;

            if (totalDoors > totalHours)
                lblOTdoors.Text = "Doors for additonal staff to complete = " + Convert.ToString(otDoors);
            else
                lblOTdoors.Visible = false;
        }

        private void btnAvoidOT_Click(object sender, EventArgs e)
        {
            //this button needs to add tim/kai/gez (or whatever) and divide up the time left for the doors so that overtime can be avoided
            //for now im just going to add all 3

            //make labels active
            dataGridView2.Visible = true;
         //   lblOT.Visible = true;
            lblOTdoors.Visible = true;
          //  lblOTHours.Visible = true;
            //lblOTTitle.Visible = true;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id, forename + ' ' + surname as fullName FROM dbo.[user] WHERE   id = 13 OR id = 14 OR id = 241 ", conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    conn.Close();
                }
            }

            //now they're in we gotta work out how many hours they can do (days off)
            string sql = "";
            int hoursDivided = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                if (dataGridView2.Columns.Contains("Monday-Thursday") == true)
                {
                    dataGridView2.Columns.Remove("Monday-Thursday");
                }
                if (dataGridView2.Columns.Contains("Friday") == true)
                {
                    dataGridView2.Columns.Remove("Friday");
                }
                //now we need to grab each day that people are off
                dataGridView2.Columns.Add("Monday-Thursday", "Monday-Thursday");
                dataGridView2.Columns.Add("Friday", "Friday");
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    //mon -thurs
                    sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) <>'Friday' THEN 1 ELSE 0 END),0) as [monday-thursday]" +
                        " FROM dbo.absent_holidays WHERE date_absent > '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent < CAST(DATEADD(day,8,'" + dteEnd.Value.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        int mon_thurs = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                        row.Cells[2].Value = mon_thurs;
                    }
                    //friday
                    sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) = 'Friday' THEN 1 ELSE 0 END),0) as [monday-thursday]" +
                       " FROM dbo.absent_holidays WHERE date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= CAST(DATEADD(day,8,'" + dteEnd.Value.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        int fri = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                        row.Cells[3].Value = fri;
                    }
                }

                //now we have the days off we can move forward with working our how many doors these guys can handle (at 0.5 doors an hour)

                //usp_calc_estimated_OT 
                //^^ this counts every day and adds hours based on how many working days are between each date
                int hours = 0;
                using (SqlConnection con = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_calc_estimated_OT", conn)
                    { CommandType = System.Data.CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = dteStart.Value.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@endDate", SqlDbType.VarChar).Value = dteEnd.Value.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@if", SqlDbType.VarChar).Value = 1;
                        conn.Open();
                        hours = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                }
                hours = hours * Convert.ToInt32(dataGridView1.Rows.Count);
                int remove_hours = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    //now we are going to remove X amount from hours based on the days they have off
                    remove_hours = (Convert.ToInt32(row.Cells[2].Value) * 4) + (Convert.ToInt32(row.Cells[3].Value) *3);
                    hours = hours - remove_hours;
                } 

                lblOTHours.Text = "Total Doors capable of extra staff:  " + hours.ToString();
                //
               
            }


            int otDoors = totalHours - totalDoors;
            if (otDoors < 0)
                otDoors = otDoors * -1;

            hoursDivided = (otDoors * 2) / 3;
            lblOTdoors.Text = "Doors for additonal staff to complete = " + Convert.ToString(otDoors);
            //MessageBox.Show(hoursDivided.ToString() + " hours each to avoid overtime!");
            lblOT.Text = hoursDivided.ToString() + " hours each to avoid overtime!";
            lblOT.Visible = true;

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //need to work our how many hours we need to split the boys above to get the number of overtime between them

            //we will use lbltitle for this

            double test = totalDoors - totalHours;
            test = Math.Round((test / 3),1);
            lblNoOverTimeNeeded.Text = test.ToString() + " Hours each needed for overtime.";
            lblNoOverTimeNeeded.Visible = true;
        }




    }
}
