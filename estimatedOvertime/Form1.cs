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

        public int doors { get; set; }
        public int hours { get; set; }
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
            string sql = "";
            //okay so the first direction i want to head in is getting nextweek back on button click
            //and maybedump it into a dgv or something
            DateTime today = DateTime.Today;
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime monday = today.AddDays(daysUntilMonday);
            int daysUntilFriday = ((int)DayOfWeek.Friday - (int)today.DayOfWeek + 7) % 7;
            DateTime friday = today.AddDays(daysUntilFriday);

            //work out the 10 working day difference here before adding it to the string using func_work_days_plus

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT dbo.func_work_days_plus('" + dteStart.Value.ToShortDateString() + "', 10)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                }
            }

            sql = "select COUNT(ID) from dbo.door where date_completion > CAST(DATEADD(day,10,'" + dteStart.Value.ToString("yyyy-MM-dd") + "')as date) AND date_completion < CAST(DATEADD(day,10,'" + dteEnd.Value.ToString("yyyy-MM-dd") + "') as date )";
            //MessageBox.Show(sql);
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    lblDoors.Text = "Number of doors between " + dteStart.Value.ToShortDateString() + " and friday = " + dteEnd.Value.ToShortDateString() + " = " + Convert.ToString(cmd.ExecuteScalar());
                    doors = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }


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
                        " FROM dbo.absent_holidays WHERE date_absent > '" + monday.ToString("yyyy-MM-dd") + "' AND date_absent < CAST(DATEADD(day,8,'" + friday.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        int mon_thurs = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                        row.Cells[2].Value = mon_thurs;
                    }
                    //friday
                    sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) = 'Friday' THEN 1 ELSE 0 END),0) as [monday-thursday]" +
                       " FROM dbo.absent_holidays WHERE date_absent > '" + monday.ToString("yyyy-MM-dd") + "' AND date_absent < CAST(DATEADD(day,8,'" + friday.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
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
                
                lblHours.Text = "Total hours for the week (no overtime) = " + hours.ToString();

            }
        }
    }
}
