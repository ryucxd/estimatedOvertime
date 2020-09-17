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
    public partial class frmMain : Form
    {
        public DateTime startDate10Days { get; set; }
        public DateTime endDate10Days { get; set; }
        public double nonDoorValue { get; set; }
        public frmMain()
        {
            InitializeComponent();
            nonDoorValue = 0.3;
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id as ID, forename + ' ' + surname as [Full Name] FROM dbo.[user] WHERE isEngineer = -1 AND id <> 260 AND id <> 3 AND id <> 29 AND id <> 13 AND id <> 14AND id <> 241 ", conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgStaff.DataSource = dt;
                    conn.Close();
                }
                //if (dgStaff.Columns.Contains("Monday-Thursday") == true)
                //{
                //    dgStaff.Columns.Remove("Monday-Thursday");
                //}
                //if (dgStaff.Columns.Contains("Friday") == true)
                //{
                //    dgStaff.Columns.Remove("Friday");
                //}
                ////now we need to grab each day that people are off
                //dgStaff.Columns.Add("Monday-Thursday", "Monday-Thursday");
                //dgStaff.Columns.Add("Friday", "Friday");
                //using (SqlConnection conn2 = new SqlConnection(CONNECT.ConnectionString))
                //{
                //    foreach (DataGridViewRow row in dgStaff.Rows)
                //    {
                //        //mon -thurs
                //        sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) <>'Friday' THEN 1 ELSE 0 END),0) as [monday-thursday]" +
                //            " FROM dbo.absent_holidays WHERE date_absent > '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent < CAST(DATEADD(day,8,'" + dteEnd.Value.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
                //        using (SqlCommand cmd = new SqlCommand(sql, conn2))
                //        {
                //            conn2.Open();
                //            int mon_thurs = Convert.ToInt32(cmd.ExecuteScalar());
                //            conn2.Close();
                //            row.Cells[2].Value = mon_thurs;
                //        }
                //        //friday
                //        sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) = 'Friday' THEN 1 ELSE 0 END),0) as [monday-thursday]" +
                //           " FROM dbo.absent_holidays WHERE date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= CAST(DATEADD(day,8,'" + dteEnd.Value.ToString("yyyy-MM-dd") + "') as date) AND staff_id =  " + row.Cells[0].Value.ToString();
                //        using (SqlCommand cmd = new SqlCommand(sql, conn2))
                //        {
                //            conn2.Open();
                //            int fri = Convert.ToInt32(cmd.ExecuteScalar());
                //            conn2.Close();
                //            row.Cells[3].Value = fri;
                //        }
                //    }
                //}

                //dumb
                dgStaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgStaff.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //wipe dgv

            if (dgDays.Columns.Contains("Date") == true)
            {
                dgDays.Columns.Remove("Date");
            }
            if (dgDays.Columns.Contains("Doors") == true)
            {
                dgDays.Columns.Remove("Doors");
            }
            if (dgDays.Columns.Contains("Non Doors") == true)
            {
                dgDays.Columns.Remove("Non Doors");
            }
            if (dgDays.Columns.Contains("Work Hours") == true)
            {
                dgDays.Columns.Remove("Work Hours");
            }
            if (dgDays.Columns.Contains("OT Needed") == true)
            {
                dgDays.Columns.Remove("OT Needed");
            }

            dgDays.Columns.Add("Date", "Date");
            //lets try and keep this very clean :)

            //first up is going to be working out the dats (adding 10 days) for the start and finish date
            DateTime startDate;
            DateTime endDate;

            //work out the 10 working day difference here before adding it to the string using func_work_days_plus
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                sql = "SELECT dbo.func_work_days_plus('" + dteStart.Value.ToString("yyyy-MM-dd") + "', 10)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    startDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    startDate10Days = Convert.ToDateTime(cmd.ExecuteScalar());
                    conn.Close();
                }
                sql = "SELECT dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyy-MM-dd") + "', 10)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    endDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    endDate10Days = Convert.ToDateTime(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            //so from here now we need to add each day into the datagridview
            //best way i can see of doing this is to make a bootleg dbo.func_work_days_plus where i just factor everything into a loop and insert each date
            double countDays = (startDate - endDate).TotalDays;
            if (countDays < 0)
                countDays = countDays * -1;

            countDays = countDays + 1;
            //start the loop and get the **temp** date var
            DateTime tempDate = startDate;
            int validation = 0;
            //we also want to have the connection string around the loop so its cleaner to look @
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                for (double i = 0; i < countDays; i++)
                {
                    validation = 0; // 0 = add date           -1 = skip date
                    //first up is to check if its a holiday
                    sql = "SELECT id FROM dbo.holidays WHERE holiday = '" + tempDate.ToString("yyyy-MM-dd") + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        var getdata = cmd.ExecuteScalar(); //for checking if it returns anything
                        if (getdata != null)
                            validation = -1;
                        else
                            validation = 0;
                        conn.Close();
                    }
                    //next up is checking if it is a weekend
                    if (tempDate.DayOfWeek == DayOfWeek.Saturday || tempDate.DayOfWeek == DayOfWeek.Sunday)
                        validation = -1;

                    //now we check if validation has been triggered
                    if (validation == -1)
                    {
                        tempDate = tempDate.AddDays(1);
                        continue;
                    }

                    //ok if we are here then the date is fine and we can add it and move on
                    var index = dgDays.Rows.Add();
                    dgDays.Rows[index].Cells["date"].Value = tempDate.ToString("yyyy-MM-dd");
                    tempDate = tempDate.AddDays(1);
                }
                dgDays.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                //gonna add a column for lates :}

                var late = dgDays.Rows.Add();
                dgDays.Rows[late].Cells["date"].Value = "LATES";

                //search has done what it needs to but we need a litttttle more
                //gonna use another private void 
                overTime();
            }
        }

        private void overTime()
        {
            //from here  we start off by adding a column


            dgDays.Columns.Add("Doors", "Doors");
            dgDays.Columns.Add("Non Doors", "Non Doors");

            //loop each day 
            //here we want to get the doors marked for THAT day -- comp date or whatever is used in th eother main string
            //from there we need to work out availability for THAT day  
            string sql = "";
            //loop
            //connnection string outside loop
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int i = 0; i < dgDays.Rows.Count - 1; i++)
                {
                    sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                     "AND (c.double_y_n IS NOT  NULL) AND (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                     "a.date_completion >= '" + dgDays.Rows[i].Cells[0].Value.ToString() + "' AND a.date_completion <= '" + dgDays.Rows[i].Cells[0].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dgDays.Rows[i].Cells[1].Value = Convert.ToString(cmd.ExecuteScalar());
                    }

                    //non doors here xoxo
                    sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                     "AND (c.double_y_n is  NULL) AND  (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                     "a.date_completion >= '" + dgDays.Rows[i].Cells[0].Value.ToString() + "' AND a.date_completion <= '" + dgDays.Rows[i].Cells[0].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dgDays.Rows[i].Cells[2].Value = Convert.ToString(cmd.ExecuteScalar());
                    }
                }
                //and then add the lates ¬
                sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                         "AND (c.double_y_n IS NOT  NULL) AND (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                         "a.date_completion < '" + startDate10Days.ToString("yyyy-MM-dd") + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[1].Value = Convert.ToString(cmd.ExecuteScalar());
                }
                //non door lates
                sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                         "AND (c.double_y_n is  NULL) AND (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                         "a.date_completion < '" + startDate10Days.ToString("yyyy-MM-dd") + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[2].Value = Convert.ToString(cmd.ExecuteScalar());
                }
                conn.Close();
            }

            //now we trigger the next pvoid for working out how much time we have 
            workHours();
        }

        private void workHours()
        {
            dgDays.Columns.Add("Work Hours", "Work Hours");
            string sql = "";
            //same concept as above
            int hours = 0;
            int remove = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                hours = 0;

                for (int i = 0; i < dgDays.Rows.Count - 1; i++)
                {
                    hours = 0;
                    remove = 0;
                    //need to go back 10 days
                    DateTime tempDate = Convert.ToDateTime(dgDays.Rows[i].Cells[0].Value);
                    using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',9)", conn))
                        tempDate = Convert.ToDateTime(cmd.ExecuteScalar());
                   // MessageBox.Show(tempDate.ToString("yyyy-MM-dd"));
                    for (int x = 0; x < dgStaff.Rows.Count; x++)
                    {
                        //work out if its a friday
                        if (tempDate.DayOfWeek == DayOfWeek.Friday)
                        {
                            sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) = 'Friday' THEN 7 ELSE 0 END),0) as [monday-thursday]" +
                                     " FROM dbo.absent_holidays WHERE date_absent = '" + tempDate.ToString("yyyy-MM-dd") + "' AND staff_id =  " + dgStaff.Rows[x].Cells[0].Value.ToString();
                            hours = hours + 7;
                        }
                        else //mon - thurs
                        {
                            sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) <>'Friday' THEN 8 ELSE 0 END),0) as [monday-thursday]" +
                                     " FROM dbo.absent_holidays WHERE date_absent = '" + tempDate.ToString("yyyy-MM-dd") + "' AND  staff_id =  " + dgStaff.Rows[x].Cells[0].Value.ToString();
                            hours = hours + 8;
                        }

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            remove = remove + Convert.ToInt32(cmd.ExecuteScalar());
                        }

                    }

                    hours = hours - remove;
                    dgDays.Rows[i].Cells[3].Value = hours.ToString();

                }
                conn.Close();
            }
            overTimeNeeded();
        }

        private void overTimeNeeded()
        {
            //here we add another column and work out how much OT is actually needed :}
            dgDays.Columns.Add("OT Needed", "OT Needed");
            //loop through each row and add door + non door together
            double totalDoors = 0;
            double totalWorkHours = 0;
            double actualTotalDoors = 0;
            for (int i = 0; i < dgDays.Rows.Count -1;i++)
            {
                totalWorkHours = totalWorkHours + Convert.ToDouble(dgDays.Rows[i].Cells[3].Value);
                totalDoors = Convert.ToDouble(dgDays.Rows[i].Cells[1].Value) + (nonDoorValue * Convert.ToDouble(dgDays.Rows[i].Cells[2].Value));
                if (totalDoors <= Convert.ToDouble(dgDays.Rows[i].Cells[3].Value))
                {
                    actualTotalDoors = actualTotalDoors + totalDoors;
                    dgDays.Rows[i].Cells[4].Value = "0";
                    continue;
                }
               actualTotalDoors = actualTotalDoors + totalDoors;
                //this needs to be the X amount of ot not the whole number of doors
                double otNeeded = 0;
                otNeeded = totalDoors - Convert.ToDouble(dgDays.Rows[i].Cells[3].Value);
                dgDays.Rows[i].Cells[4].Value = Convert.ToString(otNeeded);
            }

            //actualTotalDoors = actualTotalDoors + Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[1].Value);
            //actualTotalDoors = actualTotalDoors + (nonDoorValue * Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[2].Value));
            //maybe sum the total rows here and if ther is enough "free time" for the lates then dont include it in the OT
            if (actualTotalDoors < totalWorkHours)
            {
                actualTotalDoors = actualTotalDoors + Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[1].Value) + (nonDoorValue * (Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[2].Value)));
                //if we still have MORE work hours than total doors then we can not add any OT to lates
                if (actualTotalDoors < totalWorkHours)
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[4].Value = "0";
                else
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[4].Value = Convert.ToString(Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[1].Value) + (nonDoorValue * (Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[2].Value))));
            }


            /*maybe here we can do the maths for converting decimal into hours and minutes
            
            so for example 2.3 = 
            2.3hr = 2hr + 0.3hr
            0.3hr×60min1hr = 18min
            18min= 18min+0min
            0min×60s1min = 0s
            Combining: 02:18:00


            should be easy to just nab everything RIGHT of the decimal and re add it

            fuck it we're doing it now 8D
            */

            double left = 0, right = 0;
            for (int i = 0; i < dgDays.Rows.Count; i++)
            {
                //only working with the ot needed column so thats 4
                left = Math.Truncate(Convert.ToDouble(dgDays.Rows[i].Cells[4].Value));
                right = Math.Round(Convert.ToDouble(dgDays.Rows[i].Cells[4].Value) - left, 1);
                if (left != 0 && right != 0)
                {
                    //timr for some sick maths
                    right = right * 60;
                    
                    dgDays.Rows[i].Cells[4].Value = left.ToString() + "." + right.ToString();
                }
            }

            format();
        }







        private void format()
        {
            dgDays.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            
        }

    }
}
