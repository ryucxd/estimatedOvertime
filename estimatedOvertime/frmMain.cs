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
using Outlook = Microsoft.Office.Interop.Outlook;

namespace estimatedOvertime
{
    public partial class frmMain : Form
    {
        public DateTime startDate7Days { get; set; }
        public DateTime endDate7Days { get; set; }
        public DateTime testTTTTT { get; set; }

        /////////////////////// variables copied from newovertime layout
         public DateTime monday { get; set; }
        public DateTime sunday { get; set; }
        public int prompt { get; set; }
        ///////////////////////
        public double nonDoorValue { get; set; }

        //dgv indexs 
        public int programmingDateIndex { get; set; }
        public int completionDateIndex { get; set; }
        public int doorsIndex { get; set; }
        public int nonDoorsIndex { get; set; }
        public int workHoursIndex { get; set; }
        public int otNeededIndex { get; set; }
        public int otAddedIndex { get; set; }
        public int forecastIndex { get; set; }

        //these props are for label manipulation
        public decimal _hoursSpare { get; set; }
        public decimal _overTimeNeeded { get; set; }
        public decimal _doors { get; set; }
        public decimal _nonDoors { get; set; }
        //-///////////////////////////////////////////
        public int forecastPressed { get; set; }
        public int forecastOverride { get; set; }

        //blinking method vars
        public bool _hoursBlinkGreen { get; set; }
        public bool _otBlinkGreen { get; set; }
        public bool _otBlinkRed { get; set; }
        public bool _hoursBlinkRed { get; set; }

        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            nonDoorValue = 0.3;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id as ID, forename + ' ' + surname as [Full Name] FROM dbo.[user] WHERE isEngineer = -1 AND id <> 260 AND id <> 3 AND id <> 29 AND id <> 13 AND id <> 14AND id <> 241 AND id <> 321", conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgStaff.DataSource = dt;
                    conn.Close();
                }
                dgStaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgStaff.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                foreach (DataGridViewColumn col in dgStaff.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (forecastOverride == -1)
                    forecastOverride = 0;
                else
                    forecastPressed = 0;

                btnForecast.Enabled = true;
                for (int i = 0; i < dgStaff.Rows.Count; i++)
                    dgStaff.Rows[i].DefaultCellStyle.BackColor = Color.Empty;

                //if end is < start then stop
                if (dteStart.Value > dteEnd.Value)
                {
                    MessageBox.Show("The START date cannot be higher than the END date");
                    return;
                }
                btnEmail.Enabled = true;
                btnAddTempDoors.Enabled = true;

                //wipe dgv    
                if (dgDays.Columns.Contains("Programming Date") == true)
                {
                    dgDays.Columns.Remove("Programming Date");
                }
                if (dgDays.Columns.Contains("Spare Hours") == true)
                { 
                    dgDays.Columns.Remove("Spare Hours");
                }
                if (dgDays.Columns.Contains("Completion Date") == true)
                {
                    dgDays.Columns.Remove("Completion Date");
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
                if (dgDays.Columns.Contains("Added OT") == true)
                {
                    dgDays.Columns.Remove("Added OT");
                }
                if (dgSat.Columns.Contains("Date") == true)
                {
                    dgSat.Columns.Remove("Date");
                }
                if (dgSat.Columns.Contains("Added OT") == true)
                {
                    dgSat.Columns.Remove("Added OT");
                }




                dgDays.Columns.Add("Programming Date", "Programming Date");
                dgDays.Columns.Add("Completion Date", "Completion Date");
                columnIndex();
                //starting this section over again because trying to amend the last one just left me with a million and one errors 

                DateTime startDate = Convert.ToDateTime(dteStart.Value.ToString());
                DateTime endDate = Convert.ToDateTime(dteEnd.Value.ToString());

                //go through each day between these  ^
                double countDays = (startDate - endDate).Days;
                if (countDays < 0)
                    countDays = countDays * -1;
                DateTime tempDate = startDate;
                string sql = "";
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    for (int i = 0; i < countDays + 1; i++)
                    {
                        //here we check if the current day we are on is a holiday or a weekend 
                        //check if its a holiday
                        int validation = 0;
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
                        //next we check if its a weekend
                        if (tempDate.DayOfWeek == DayOfWeek.Saturday || tempDate.DayOfWeek == DayOfWeek.Sunday)
                            validation = -1;

                        if (validation == -1)
                        {
                            tempDate = tempDate.AddDays(1);
                            continue;
                        }

                        //if we made it this far then the days are fine so we can add it
                        var index = dgDays.Rows.Add();
                        dgDays.Rows[index].Cells["Programming Date"].Value = tempDate.ToString("yyyy-MM-dd"); //341 is the upper limit for this for some reason???
                        tempDate = tempDate.AddDays(1);

                    }

                    //now we have the base days we can go ahead with adding the comp days
                    tempDate = startDate;
                    sql = "SELECT dbo.func_work_days_plus('" + tempDate.ToString("yyyy-MM-dd") + "', 7)"; //here we add 7 days
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        tempDate = Convert.ToDateTime(cmd.ExecuteScalar());
                        conn.Close();
                    }
                    foreach (DataGridViewRow row in dgDays.Rows)
                    {//this can fall almost exactly the same as the above, minus the ending where we do not add a new row
                        int validation = -1;
                        while (validation == -1)
                        {
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
                            //next we check if its a weekend
                            if (tempDate.DayOfWeek == DayOfWeek.Saturday || tempDate.DayOfWeek == DayOfWeek.Sunday)
                                validation = -1;

                            if (validation == -1)
                                tempDate = tempDate.AddDays(1);
                            else
                                validation = 0;
                        }

                        //if we made it this far then the days are fine so we can add it
                        row.Cells["Completion Date"].Value = tempDate.ToString("yyyy-MM-dd"); //341 is the upper limit for this for some reason???
                        tempDate = tempDate.AddDays(1);
                    }


                }


                //gonna add a column for lates :}

                var late = dgDays.Rows.Add();
                dgDays.Rows[late].Cells["Programming Date"].Value = "LATES";

                //search has done what it needs to but we need a litttttle more
                //gonna use another private void 

                overTime();
            }
            else //else its the other dept so we just use this to filter days for other dept overtime
            {
                //first step is get monday + sunday between the date clicked 
                DateTime temp = dteStart.Value;
              
                if (temp.DayOfWeek == DayOfWeek.Monday)
                    monday = temp;
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        temp = temp.AddDays(-1);
                        if (temp.DayOfWeek == DayOfWeek.Monday)
                            i = 8;
                    }
                    monday = temp;
                  
                }
                sunday = monday.AddDays(6);
                lblOTDATE.Text = "Overtime for week of " + monday.ToString("dd-MM-yyyy");
                loadDGVProgramming();
                loadDGVOther();
                formatOther();
                insertData();




                //below code has been retired because geraints wants the [new overtime layout] here instead  - 11/12/2020
                /////////////////////////////////
                ////THE BELOW STRING IS FOR 
                ////string sql = "";
                //DataTable dt = new DataTable();
                //dt.Columns.Add("Date");
                //dt.Columns.Add("Day of Week");
                //dt.Columns.Add("Over Time");
                ////DataRow row2 = dt.NewRow();
                ////dt.Rows.Add(row2);
                //double countDays = (dteStart.Value - dteEnd.Value).Days;
                //if (countDays < 0)
                //    countDays = countDays * -1;
                //DateTime tempDate = dteStart.Value;
                //for (int i = 0; i < countDays + 2; i++)
                //{
                //    DataRow row = dt.NewRow();
                //    dt.Rows.Add(row);
                //    dt.Rows[i][0] = tempDate.ToString("yyyy-MM-dd");
                //    tempDate = tempDate.AddDays(1);
                //}

                //string sql = "";

                //using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                //{
                //    conn.Open();
                //    //idk about 
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        DateTime tempVar = Convert.ToDateTime(dt.Rows[i][0].ToString());
                //        sql = "select sum(COALESCE(prior_work_day,0) + COALESCE(post_work_day,0)) as [OT], DATENAME(dw,'" + tempVar.ToString("yyyy-MM-dd") + "') FROM dbo.staff_overtime WHERE date = '" + tempVar.ToString("yyyy-MM-dd") + "' AND dept <> 7";
                //        using (SqlCommand cmd = new SqlCommand(sql, conn))
                //        {
                //            dt.Rows[i][2] = Convert.ToString(cmd.ExecuteScalar());
                //            if (dt.Rows[i][2].ToString() == "")
                //                dt.Rows[i][2] = "0";
                //        }
                //        sql = "select DATENAME(dw,'" + tempVar.ToString("yyyy-MM-dd") + "')";
                //        using (SqlCommand cmd = new SqlCommand(sql, conn))
                //        {
                //            dt.Rows[i][1] = Convert.ToString(cmd.ExecuteScalar());
                //        }
                //    }
                //    conn.Close();
                //    dgvOtherDept.DataSource = dt;
                //    foreach (DataGridViewRow row in dgvOtherDept.Rows)
                //    {
                //        if (Convert.ToInt32(row.Cells[2].Value) > 0)
                //            row.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                //    }
                //}
            }
        }

        private void overTime()
        {
            //from here  we start off by adding a column


            dgDays.Columns.Add("Doors", "Doors");
            dgDays.Columns.Add("Non Doors", "Non Doors");

            //get index of X columns
            columnIndex();



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
                     "a.date_punch >= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "' AND a.date_punch <= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dgDays.Rows[i].Cells[doorsIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                    }

                    //non doors here xoxo
                    sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                     "AND (c.double_y_n is  NULL) AND  (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                     "a.date_punch >= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "' AND a.date_punch <= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dgDays.Rows[i].Cells[nonDoorsIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                    }
                }
                //and then add the lates ¬
                sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                         "AND (c.double_y_n IS NOT  NULL) AND (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                         "a.date_punch < '" + dteStart.Value.ToString("yyyy-MM-dd") + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[doorsIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                }
                //non door lates
                sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                         "AND (c.double_y_n is  NULL) AND (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                         "a.date_punch < '" + dteStart.Value.ToString("yyyy-MM-dd") + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[nonDoorsIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            if (txtTempDoors.Text.Length > 0)
            {
                int daysCount = 0;
                decimal tempDoors = 0;
                daysCount = dgDays.Rows.Count - 1; //-1 for the lates row
                tempDoors = Convert.ToInt32(txtTempDoors.Text);
                //txtbox number / total days
                tempDoors = tempDoors / daysCount;
                tempDoors = Math.Round(tempDoors);

                for (int i = 0; i < dgDays.Rows.Count - 1; i++)
                    dgDays.Rows[i].Cells[doorsIndex].Value = Convert.ToInt32(dgDays.Rows[i].Cells[doorsIndex].Value) + Convert.ToInt32(tempDoors);
            }
            //now we trigger the next pvoid for working out how much time we have 
            workHours();
        }

        private void workHours()
        {
            dgDays.Columns.Add("Work Hours", "Work Hours");
            columnIndex();
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
                    //need to go back 7 days  //NO WE DONT
                    DateTime tempDate = Convert.ToDateTime(dgDays.Rows[i].Cells[programmingDateIndex].Value);
                    //using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',6)", conn)) //herehere
                    //    tempDate = Convert.ToDateTime(cmd.ExecuteScalar());
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
                            //colour
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            {
                                dgStaff.Rows[x].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                                continue;
                            }



                        }

                    }

                    hours = hours - remove;
                    //hours = hours - provisonalRemove;
                    dgDays.Rows[i].Cells[workHoursIndex].Value = hours.ToString();
                }
                conn.Close();
            }
            //before going into OT needed we gotta check for provisional dates
            provisionalAbsences();
            //here maybe?
            //find out if todays date matches a date in the dgv? (incase they went back a week i guess?
            DateTime todayTime = DateTime.Now; //this will be just the time
            DateTime todayDate = DateTime.Today;

            for (int i = 0; i < dgDays.Rows.Count - 1; i++) // -1 to skip the lates cell at the end 
            {
                if (Convert.ToDateTime(dgDays.Rows[i].Cells[programmingDateIndex].Value) == todayDate)
                {
                    //if we get here then we can just proc the void that handles the current day mechanic and move on
                    removeTodaysHours();
                }
            }

            overTimeNeeded();
        }

        private void removeTodaysHours()
        {
            //first step i guess is to mark the start and end date
            DateTime workStart = Convert.ToDateTime("07:30:00");
            DateTime workEnd;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
                workEnd = Convert.ToDateTime("15:00:00");
            else
                workEnd = Convert.ToDateTime("16:00:00");

            DateTime todayTime = DateTime.Now;
            DateTime hoursLeft = DateTime.Now;
            if (todayTime < workEnd)
            {

                TimeSpan timeSpan = DateTime.Parse(Convert.ToString(workEnd)).Subtract(DateTime.Parse(Convert.ToString(todayTime)));
                hoursLeft = Convert.ToDateTime(timeSpan.ToString());
                hoursLeft = RoundToHour(hoursLeft);
                //hoursLeft now shows how many 'doors' are left
                //* this by the number of men in the dept and this is the new  value???
            }



            string sql = "";
            int staffCount = 0;
            for (int x = 0; x < dgStaff.Rows.Count; x++)
            {
                //work out if its a friday
                if (todayTime.DayOfWeek == DayOfWeek.Friday)
                {
                    sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) = 'Friday' THEN 7 ELSE 0 END),0) as [monday-thursday]" +
                             " FROM dbo.absent_holidays WHERE date_absent = '" + todayTime.ToString("yyyy-MM-dd") + "' AND staff_id =  " + dgStaff.Rows[x].Cells[0].Value.ToString();
                }
                else //mon - thurs
                {
                    sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) <>'Friday' THEN 8 ELSE 0 END),0) as [monday-thursday]" +
                             " FROM dbo.absent_holidays WHERE date_absent = '" + todayTime.ToString("yyyy-MM-dd") + "' AND  staff_id =  " + dgStaff.Rows[x].Cells[0].Value.ToString();
                }

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        int getData = Convert.ToInt32(cmd.ExecuteScalar());
                        if (getData == 0) //if its null they are in so we can add to poerson count
                            staffCount = staffCount + 1;

                        //its either 8/7 or its 0 (0 is current and 8-7 is absent
                    }

                    //we also need to check if any of them are out during provisional leave and this is going to be a nightmare to work out 
                    sql = "Select * from dbo.staff_provisional_absences";
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                    }

                    //loop through the dt /
                    foreach (DataRow row in dt.Rows)
                    {
                        //get the staff id
                        int staff_id = Convert.ToInt32(row["staff_id"].ToString());
                        //now we check this agaisnt the boys
                        for (int i = 0; i < dgStaff.Rows.Count; i++)
                        {
                            if (staff_id == Convert.ToInt32(dgStaff.Rows[i].Cells[0].Value))
                            {
                                //there is a match now we grab the start and end check to see if today falls under it 
                                DateTime startDate = Convert.ToDateTime(row["date_start"].ToString());
                                DateTime endDate = Convert.ToDateTime(row["date_end"].ToString());
                                double countDays = (startDate - endDate).Days;
                                if (countDays < 0)
                                    countDays = countDays * -1;
                                for (int counter = 0; counter < countDays; counter++)
                                {
                                    //if (day)
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            //find the dgv although it should be #0
            foreach (DataGridViewRow row in dgDays.Rows)
            {
                if (row.Cells[programmingDateIndex].Value.ToString() == todayTime.ToString("yyyy-MM-dd"))
                {
                    if (todayTime < workEnd)
                        row.Cells[workHoursIndex].Value = Convert.ToString(Convert.ToInt32(hoursLeft.Hour) * staffCount);
                    break;
                }
            }
        }

        static DateTime RoundToHour(DateTime dt) //i dont understand how this works but it just does nice
        {
            long ticks = dt.Ticks + 18000000000;
            return new DateTime(ticks - ticks % 36000000000, dt.Kind); //this rounds up only when its 30mins
        }

        private void provisionalAbsences()
        {
            string sql = "";

            //go though each day in the table
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int i = 0; i < dgDays.Rows.Count - 1; i++)
                {
                    int remove = 0;
                    int hoursCount = Convert.ToInt32(dgDays.Rows[i].Cells[workHoursIndex].Value);
                    DateTime dgvDate = Convert.ToDateTime(dgDays.Rows[i].Cells[programmingDateIndex].Value); //this rows date (although at this point it is completion date so we gotta convert it back in time to get the actual date
                    //convert the date back
                    //using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + dgvDate.ToString("yyyy-MM-dd") + "',6)", conn)) //herehere
                    //    dgvDate = Convert.ToDateTime(cmd.ExecuteScalar());

                    //loop through each user and see if they have a provisonal date that matches up to the dgvdate
                    for (int x = 0; x < dgStaff.Rows.Count; x++)
                    {
                        DateTime provisionalStartDate;
                        DateTime provisionalEndDate;
                        //get users provisional dates and such
                        sql = "SELECT date_start FROM dbo.staff_provisional_absences WHERE staff_id = " + dgStaff.Rows[x].Cells[0].Value.ToString();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            provisionalStartDate = Convert.ToDateTime(cmd.ExecuteScalar());
                        sql = "SELECT date_end FROM dbo.staff_provisional_absences WHERE staff_id = " + dgStaff.Rows[x].Cells[0].Value.ToString();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            provisionalEndDate = Convert.ToDateTime(cmd.ExecuteScalar());

                        //count the days between the start and end date of provisional days
                        double countDays = (provisionalStartDate - provisionalEndDate).Days;
                        if (countDays < 0)
                            countDays = countDays * -1;

                        DateTime tempDate = provisionalStartDate;
                        //loop through all of the days 
                        for (int z = 0; z < countDays + 1; z++)
                        {
                            if (tempDate == dgvDate)
                            {
                                //check if temp is a friday
                                if (tempDate.DayOfWeek == DayOfWeek.Friday)
                                    remove = remove + 7;
                                else
                                    remove = remove + 8;
                                dgStaff.Rows[x].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                            }
                            tempDate = tempDate.AddDays(1);
                        }

                    }
                    //its now looped through every staff and if theres a day we need to remove it from workhours
                    hoursCount = hoursCount - remove;
                    dgDays.Rows[i].Cells[workHoursIndex].Value = hoursCount;

                }
                conn.Close();
            }
        }

        private void overTimeNeeded()
        {
            //here we add another column and work out how much OT is actually needed :}
            dgDays.Columns.Add("OT Needed", "OT Needed");
            columnIndex();
            //loop through each row and add door + non door together
            double totalDoors = 0;
            double totalWorkHours = 0;
            double actualTotalDoors = 0;
            for (int i = 0; i < dgDays.Rows.Count - 1; i++)
            {
                totalWorkHours = totalWorkHours + Convert.ToDouble(dgDays.Rows[i].Cells[workHoursIndex].Value);
                totalDoors = Convert.ToDouble(dgDays.Rows[i].Cells[doorsIndex].Value) + (nonDoorValue * Convert.ToDouble(dgDays.Rows[i].Cells[nonDoorsIndex].Value));
                if (totalDoors <= Convert.ToDouble(dgDays.Rows[i].Cells[workHoursIndex].Value))
                {
                    actualTotalDoors = actualTotalDoors + totalDoors;
                    dgDays.Rows[i].Cells[otNeededIndex].Value = "0";
                    continue;
                }
                actualTotalDoors = actualTotalDoors + totalDoors;
                //this needs to be the X amount of ot not the whole number of doors
                double otNeeded = 0;
                otNeeded = totalDoors - Convert.ToDouble(dgDays.Rows[i].Cells[workHoursIndex].Value);
                dgDays.Rows[i].Cells[otNeededIndex].Value = Convert.ToString(otNeeded);
            }

            //actualTotalDoors = actualTotalDoors + Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[1].Value);
            //actualTotalDoors = actualTotalDoors + (nonDoorValue * Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[2].Value));
            //maybe sum the total rows here and if ther is enough "free time" for the lates then dont include it in the OT
            if (actualTotalDoors < totalWorkHours)
            {
                actualTotalDoors = actualTotalDoors + Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[doorsIndex].Value) + (nonDoorValue * (Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[nonDoorsIndex].Value)));
                //if we still have MORE work hours than total doors then we can not add any OT to lates
                if (actualTotalDoors < totalWorkHours)
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[otNeededIndex].Value = "0";
                else
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[otNeededIndex].Value = Convert.ToString(Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[doorsIndex].Value) + (nonDoorValue * (Convert.ToDouble(dgDays.Rows[dgDays.Rows.Count - 1].Cells[nonDoorsIndex].Value))));
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
                left = Math.Truncate(Convert.ToDouble(dgDays.Rows[i].Cells[otNeededIndex].Value));
                right = Math.Round(Convert.ToDouble(dgDays.Rows[i].Cells[otNeededIndex].Value) - left, 1);
                if (right != 0)
                {
                    //timr for some sick maths
                    right = right * 60;

                    dgDays.Rows[i].Cells[otNeededIndex].Value = left.ToString() + "." + right.ToString();
                }
            }

            //check overtime table and see if they have any OT etc
            addedOT();
        }


        private void addedOT()
        {

            dgDays.Columns.Add("Added OT", "Added OT");
            columnIndex();
            //table = staff overtime
            string sql = "";


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                for (int i = 0; i < dgDays.Rows.Count - 1; i++)
                {
                    //get the actual work day
                    DateTime tempDate = Convert.ToDateTime(dgDays.Rows[i].Cells[programmingDateIndex].Value);
                    //using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',6)", conn))
                    //    tempDate = Convert.ToDateTime(cmd.ExecuteScalar());

                    sql = "SELECT SUM(COALESCE(prior_work_day,0) + COALESCE(post_work_day,0)) as [total OT] FROM dbo.staff_overtime WHERE date = '" + tempDate.ToString("yyyy-MM-dd") + "' AND dept = 7";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        var get_data = cmd.ExecuteScalar();
                        if (get_data != null)
                            dgDays.Rows[i].Cells[otAddedIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                        else
                            dgDays.Rows[i].Cells[otAddedIndex].Value = "";

                    }
                }
                conn.Close();
            }
            //i think this is a suitable place to start inserting whos doing OT this week (or between two dates)

            //look for dates X and Y in dbo.staff_overtime and then grab each person and sum the total overtime etc

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                sql = " Select max(a.staff_id) as staff_id ,MAX(b.forename + ' ' + b.surname) as [Full Name],sum(a.prior_work_day + a.post_work_day) as [Over Time] From dbo.staff_overtime a  LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                    "WHERE(prior_work_day > 0 OR post_work_day > 0) and  date >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' AND dept = 7 " +
                    "group by staff_id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgOverTime.DataSource = dt;
                    conn.Close();
                }
            }

            dgOverTime.Columns[0].Visible = false;

            format();
        }


        private void format()
        {



            dgDays.Columns[programmingDateIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[completionDateIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgDays.Columns[doorsIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgDays.Columns[nonDoorsIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[workHoursIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[otNeededIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDays.Columns[otAddedIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgDays.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgDays.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgDays.ClearSelection();
            dgStaff.ClearSelection();
            colours();

            foreach (DataGridViewColumn col in dgDays.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn col in dgStaff.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn col in dgOverTime.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            //here??
            if (forecastPressed == -1)
            {
                forecastOverride = 0;
                btnForecast.PerformClick();
            }
        }

        private void dgDays_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDays.Rows[e.RowIndex].Cells[programmingDateIndex].Value.ToString() == "LATES")
            {
                //open a form here to show what doors are late
                frmLates frmL = new frmLates(startDate7Days);
                frmL.ShowDialog();
                return;
            }
            //ask the user if they want to add a saturday into this or not
            //DialogResult result = MessageBox.Show("Would you like to add overtime on saturday?", "Over Time", MessageBoxButtons.YesNo);
            //if (result == DialogResult.No)
            //{
            //first of all if its the LATES row then do nothing 8D

            //MessageBox.Show(e.RowIndex.ToString());
            //open the insert form  and pass the date over
            //might need to pass more than that but for now thats what we are rolling with


            DateTime tempDate = Convert.ToDateTime(dgDays.Rows[e.RowIndex].Cells[programmingDateIndex].Value);
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                conn.Close();
            }
            //                       commenting this out while testing the new form
            /////////////////////////////////////////////////////////////////////////////////////
            //frmOverTmeInput frm = new frmOverTmeInput(Convert.ToDateTime(tempDate));
            //frm.ShowDialog();
            /////////////////////////////////////////////////////////////////////////////////////

            frmOverTimeNew frm = new frmOverTimeNew(tempDate);
            frm.ShowDialog();

            //}
            //else //yes was pressed
            //{
            //    //look for multiple saturdays here
            //    DateTime tempDate = dteStart.Value;
            //    double countDays = (dteStart.Value - dteEnd.Value).TotalDays;
            //    if (countDays < 0)
            //        countDays = countDays * -1;
            //    int multiSat = 0;
            //    for (int i = 0; i < countDays; i++)
            //    {
            //        if (tempDate.DayOfWeek == DayOfWeek.Saturday)//we need to get the user to select which saturday they want 
            //        { //mark if there is more than one sat
            //            multiSat = -1;
            //        }
            //        tempDate = tempDate.AddDays(1);
            //    }

            //    if (multiSat == -1)//we need to get the user to select which saturday they want 
            //    {
            //        frmPickSat frm2 = new frmPickSat(dteStart.Value, dteEnd.Value);
            //        frm2.ShowDialog();
            //    }
            //    else                       //else we just go as normal (nearest SAT to the final date
            //    {
            //        //get the final date here
            //        tempDate = dteEnd.Value;
            //        for (int i = 0; i < 7; i++)
            //        {
            //            if (tempDate.DayOfWeek == DayOfWeek.Saturday)
            //            {
            //                i = 99;
            //                continue;
            //            }


            //            tempDate = tempDate.AddDays(1);
            //        }
            //        frmSatProgramming frm = new frmSatProgramming(tempDate, 0);
            //        frm.ShowDialog();
            //    }
            //}

            forecastOverride = -1;
            btnSearch.PerformClick();

        }

        private void addSaturday() //and sunday too :}
        {
            if (dgSat.Columns.Contains("Date") == true)
            {
                dgSat.Columns.Remove("Date");
            }
            dgSat.Columns.Add("Date", "Date");
            //work out of there are any dates before the end date that are saturdays
            double countDays = (dteStart.Value - dteEnd.Value).Days;
            if (countDays < 0)
                countDays = countDays * -1;

            DateTime tempDate = dteStart.Value;
            for (int i = 0; i < countDays; i++)
            {
                if (tempDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    var sat = dgSat.Rows.Add();
                    dgSat.Rows[sat].Cells["Date"].Value = tempDate.ToString("yyyy-MM-dd");
                }
                tempDate = tempDate.AddDays(1);
            }
            //now that we have added the saturdays we have to find the closest saturday to the END date 
            //for example end user picks mon-fri but wants to add overtime in on the saturday
            tempDate = dteEnd.Value;
            for (int i = 0; i < 7; i++)
            {
                if (tempDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    var sat = dgSat.Rows.Add();
                    dgSat.Rows[sat].Cells["Date"].Value = tempDate.ToString("yyyy-MM-dd");
                }
                if (tempDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    var sun = dgSat.Rows.Add();
                    dgSat.Rows[sun].Cells["Date"].Value = tempDate.ToString("yyyy-MM-dd");
                    i = 99;
                }
                tempDate = tempDate.AddDays(1);
            }
            //after adding the dates we now need to check for OT
            if (dgSat.Columns.Contains("Added OT") == true)
            {
                dgSat.Columns.Remove("Added OT");
            }
            dgSat.Columns.Add("Added OT", "Added OT");

            //loop through this like the other section
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                for (int i = 0; i < dgSat.Rows.Count; i++)
                {
                    //get the actual work day
                    tempDate = Convert.ToDateTime(dgSat.Rows[i].Cells[0].Value);

                    sql = "SELECT SUM(COALESCE(prior_work_day,0) + COALESCE(post_work_day,0)) as [total OT] FROM dbo.staff_overtime WHERE date = '" + tempDate.ToString("yyyy-MM-dd") + "' AND dept = 7 AND staff_id <> 14";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        var get_data = cmd.ExecuteScalar();
                        if (get_data != null)
                            dgSat.Rows[i].Cells[1].Value = Convert.ToString(cmd.ExecuteScalar());
                        else
                            dgSat.Rows[i].Cells[0].Value = "";

                    }
                }
                conn.Close();
                dgSat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgSat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgSat.ClearSelection();
            }

        }

        private void colours() //and also labels
        {
            fixDates();

            //before we going doing anything funky we need to populate the saturday dgv
            addSaturday();
            columnIndex();

            decimal OTNeeded = 0;
            decimal OTAssigned = 0;
            decimal hoursFree = 0;
            decimal doors = 0;

            for (int i = 0; i < dgDays.Rows.Count; i++)
            {
                doors = doors + Convert.ToInt32(dgDays.Rows[i].Cells[doorsIndex].Value);
                //if theres no need for ot then use green
                if (Convert.ToDouble(dgDays.Rows[i].Cells[otNeededIndex].Value) == 0)
                    dgDays.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                else if (Convert.ToDouble(dgDays.Rows[i].Cells[otNeededIndex].Value) > 0)
                    dgDays.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;


                //if there is OT needed mark the row
                if (dgDays.Rows[i].Cells[otAddedIndex].Value != null)
                {
                    if (dgDays.Rows[i].Cells[otAddedIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgDays.Rows[i].Cells[otAddedIndex].Value) > 0)
                            dgDays.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                    }
                }
                //count for variables
                OTNeeded = OTNeeded + Convert.ToDecimal(dgDays.Rows[i].Cells[otNeededIndex].Value ?? 0);
                //
                if (dgDays.Rows[i].Cells[otAddedIndex].Value != null)
                {
                    if (String.IsNullOrWhiteSpace(dgDays.Rows[i].Cells[otAddedIndex].Value.ToString()) == false)
                    {
                        if (dgDays.Rows[i].Cells[otAddedIndex].Value.ToString() != "")
                            OTAssigned = OTAssigned + Convert.ToDecimal(dgDays.Rows[i].Cells[otAddedIndex].Value ?? 0);
                    }
                }
            }
            //also check dgsat for added ot
            for (int i = 0; i < dgSat.Rows.Count; i++)
            {
                if (dgSat.Rows[i].Cells[1].Value != null)
                {
                    if (String.IsNullOrWhiteSpace(dgSat.Rows[i].Cells[1].Value.ToString()) == false)
                    {
                        if (dgSat.Rows[i].Cells[1].Value.ToString() != "")
                            OTAssigned = OTAssigned + Convert.ToDecimal(dgSat.Rows[i].Cells[1].Value ?? 0);
                    }
                }
            }

            if (OTAssigned > 0)
                lblOTAssigned.Text = OTAssigned.ToString() + " Hours Over Time Assigned";
            else
                lblOTAssigned.Text = " No Over Time Assigned";


            //some better maths on these two labels 



            //work our how many free hours there are
            for (int i = 0; i < dgDays.Rows.Count - 1; i++)
            {
                hoursFree = hoursFree + Convert.ToDecimal(dgDays.Rows[i].Cells[workHoursIndex].Value);
            }


            hoursFree = (hoursFree - doors);
            _overTimeNeeded = OTNeeded;
            _hoursSpare = hoursFree;


            lblFreeHours.Visible = true;


            //maths for these labels...
            //count the total workhours vs doors so we have an accurate number 
            //this is pretty important
            //because currently this just prettymuch does not work 

            //im gonna redo the whole thing here rather than make use of the loops we already have above 

            _hoursSpare = 0;
            _doors = 0;
            _nonDoors = 0;
            _overTimeNeeded = 0;
            for (int i = 0; i < dgDays.Rows.Count; i++)  //need to handle the 'lates' so that it only adds the doors because the rest of the cells are null
            { //idk about this one chief
                if (dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() == "LATES")
                {
                    //only add to doors
                    _doors = _doors + Convert.ToDecimal(dgDays.Rows[i].Cells[doorsIndex].Value);
                }
                else
                {
                    decimal overtimeAddedTemp = 0;  // the old one was doing something funky with overtime, when it was null it was skipping _nondoors thus making it out by 0.3 etc
                    if (dgDays.Rows[i].Cells[otAddedIndex].Value.ToString() != "")
                        overtimeAddedTemp = overtimeAddedTemp + Convert.ToDecimal(dgDays.Rows[i].Cells[otAddedIndex].Value);
                    _hoursSpare = _hoursSpare + (Convert.ToDecimal(dgDays.Rows[i].Cells[workHoursIndex].Value) + overtimeAddedTemp);
                    _doors = _doors + Convert.ToDecimal(dgDays.Rows[i].Cells[doorsIndex].Value);
                    _nonDoors = _nonDoors + Convert.ToDecimal(dgDays.Rows[i].Cells[nonDoorsIndex].Value);
                    _overTimeNeeded = _overTimeNeeded + Convert.ToDecimal(dgDays.Rows[i].Cells[otNeededIndex].Value);
                }
            }


            //add lates here


            //to work out how many hours we actually have spare we need to do hours - doors
            _nonDoors = _nonDoors * Convert.ToDecimal(0.3);
            _doors = _doors + _nonDoors;
            decimal tempHoursSpare = _hoursSpare;
            _hoursSpare = _hoursSpare - _doors;


            //while we are here we need to make these flash etcccccc
            if (_hoursSpare <= 0)
                lblFreeHours.Text = "No Spare Hours Available";
            else
            {
                lblFreeHours.Text = _hoursSpare + " Spare Hours Available";
                _hoursBlinkGreen = true;
                _otBlinkRed = false;
                hoursBlinkGreen();
                lblTotalOTNeeded.Text = "No Overtime Needed";
            }


            if (_hoursSpare <= 0) // < 0 after the calculation means we will have more doors than hours :<
            {
                _doors = _doors - tempHoursSpare; //this will give the number of doors we need to complete through OT
                lblTotalOTNeeded.Text = _doors.ToString() + " Over Time Hours Needed";
                _otBlinkRed = true;
                _hoursBlinkGreen = false;
                OTBlinkRed();
            }
        }

        //test
        private async void hoursBlinkGreen()
        {
            if (_hoursBlinkGreen == true)
            {
                while (true)
                {
                    if (_hoursBlinkGreen == false)
                    {
                        lblFreeHours.BackColor = Color.Empty;
                        return;
                    }
                    await Task.Delay(500);
                    lblFreeHours.BackColor = lblFreeHours.BackColor == Color.DarkSeaGreen ? Color.Empty : Color.DarkSeaGreen;
                }
            }
        }
        private async void OTBlinkRed()
        {
            if (_otBlinkRed == true)
            {
                while (true)
                {
                    if (_otBlinkRed == false)
                    {
                        lblTotalOTNeeded.BackColor = Color.Empty;
                        return;
                    }
                    await Task.Delay(500);
                    lblTotalOTNeeded.BackColor = lblTotalOTNeeded.BackColor == Color.PaleVioletRed ? Color.Empty : Color.PaleVioletRed;
                }
            }
        }


        private void fixDates()
        {
            //here we are going to go over the dates selected and add them 
            //need to go back 7 days
            //using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //{
            //    conn.Open();
            //    // MessageBox.Show(tempDate.ToString("yyyy-MM-dd"));
            //    for (int i = 0; i < dgDays.Rows.Count - 1; i++)
            //    {
            //        DateTime tempDate = Convert.ToDateTime(dgDays.Rows[i].Cells[programmingDateIndex].Value);
            //        using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',6)", conn)) //herehere
            //            tempDate = Convert.ToDateTime(cmd.ExecuteScalar());

            //        dgDays.Rows[i].Cells[programmingDateIndex].Value = tempDate.ToString("yyyy-MM-dd");

            //    }
            //    conn.Close();
            //}

        } //commented out 



        private void dgOverTime_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {


            //upload the days dgv to a table and email that bad boy
            //staff_overtime_temp

            //if it doesnt exist then make it
            System.IO.Directory.CreateDirectory(@"C:\temp\");

            //full screen it



            //now here we are going to take a screenshot and open it in outlook
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                Graphics gs = Graphics.FromImage(bit);
                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);
                bit.Save(@"C:\temp\temp.jpg");
            }
            catch
            {
            }

            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\temp.jpg"; // Change path as needed
            var attachments = mailItem.Attachments;
            var attachment = attachments.Add(imageSrc);
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
            mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);
            // Set body format to HTML
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            string msgHTMLBody = "<html><head></head><body>Hello,<br><br><br><br><img align=\"baseline\" border=\"1\" hspace=\"0\" src=\"cid:myident\" width=\"\" 600=\"\" hold=\" /> \"></img><br><br>Regards,<br></body></html>";
            mailItem.HTMLBody = msgHTMLBody;
            mailItem.Display(true);


            //everything below here is the old email
            //it used to dump everything into a temptable and email it off this way 
            ////------------------------------------------------------------------------------------------------------------
            //using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //{
            //    conn.Open();
            //    //first we need to wipe the table for the previous data
            //    string sql = "DELETE FROM dbo.staff_overtime_temp";
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //        cmd.ExecuteNonQuery();

            //    //now we insert
            //    for (int i = 0; i < dgDays.Rows.Count; i++)
            //    {
            //        double otNeeded = 0;
            //        if (String.IsNullOrEmpty(dgDays.Rows[i].Cells[otNeededIndex].Value.ToString()))
            //            otNeeded = 0.0;
            //        else
            //            otNeeded = Convert.ToDouble(dgDays.Rows[i].Cells[otNeededIndex].Value);

            //        int workHours = 0;
            //        if (dgDays.Rows[i].Cells[workHoursIndex].Value?.ToString() == null)
            //            workHours = 0;
            //        else
            //            workHours = Convert.ToInt32(dgDays.Rows[i].Cells[workHoursIndex].Value);


            //        sql = "INSERT INTO dbo.staff_overtime_temp (date,doors,nonDoors,workHours,otNeeded) VALUES (" +
            //        "'" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "'," + //date
            //        "" + dgDays.Rows[i].Cells[doorsIndex].Value.ToString() + "," + //doors
            //        "" + dgDays.Rows[i].Cells[nonDoorsIndex].Value.ToString() + "," +//nonDoors
            //        "" + workHours + "," +//workHours
            //        "" + otNeeded.ToString() + ")"; //otNeeded

            //        using (SqlCommand cmd = new SqlCommand(sql, conn))
            //            cmd.ExecuteNonQuery();

            //    }
            //    //usp_email_programming_OT
            //    //here we fire the procedure 
            //    using (SqlCommand cmd = new SqlCommand("usp_email_programming_OT", conn)
            //    { CommandType = System.Data.CommandType.StoredProcedure })
            //    {
            //        cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = dteStart.Value.ToString("yyyy-MM-dd");
            //        cmd.Parameters.Add("@endDate", SqlDbType.VarChar).Value = dteEnd.Value.ToString("yyyy-MM-dd");
            //        cmd.ExecuteNonQuery();
            //    }

            //    conn.Close();
            //    MessageBox.Show("Email Sent", "!", MessageBoxButtons.OK);
            //    btnEmail.Enabled = false;
            //}
            ////------------------------------------------------------------------------------------------------------------
        }

        private void dgSat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmSatProgramming frm = new frmSatProgramming(Convert.ToDateTime(dgSat.Rows[e.RowIndex].Cells[0].Value), 0);
            frm.ShowDialog();
            forecastOverride = -1;
            btnSearch.PerformClick();
        }

        private void columnIndex()
        {
            //go through each column (if exists and update the index for them
            if (dgDays.Columns.Contains("Programming Date") == true)
                programmingDateIndex = dgDays.Columns["Programming Date"].Index;

            if (dgDays.Columns.Contains("Completion Date") == true)
                completionDateIndex = dgDays.Columns["Completion Date"].Index;

            if (dgDays.Columns.Contains("Doors") == true)
                doorsIndex = dgDays.Columns["Doors"].Index;

            if (dgDays.Columns.Contains("Non Doors") == true)
                nonDoorsIndex = dgDays.Columns["Non Doors"].Index;

            if (dgDays.Columns.Contains("Work Hours") == true)
                workHoursIndex = dgDays.Columns["Work Hours"].Index;

            if (dgDays.Columns.Contains("OT Needed") == true)
                otNeededIndex = dgDays.Columns["OT Needed"].Index;

            if (dgDays.Columns.Contains("Added OT") == true)
                otAddedIndex = dgDays.Columns["Added OT"].Index;

            if (dgDays.Columns.Contains("Spare Hours") == true)
                forecastIndex = dgDays.Columns["Spare Hours"].Index;

        }

        private void btnAddTempDoors_Click(object sender, EventArgs e)
        {
            //all the workings out for this are in overtime();
            forecastOverride = -1;
            btnSearch.PerformClick();
        }

        private void txtTempDoors_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void txtTempDoors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddTempDoors.PerformClick();
        }

        private void dgOverTime_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //clicking this will open THAT persons OT between the selected dates;
            int staff_id = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand("Select id FROM dbo.[user] WHERE forename + ' ' + surname = '" + dgOverTime.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn))
                {
                    conn.Open();
                    staff_id = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            frmUserOT frm = new frmUserOT(staff_id, dteStart.Value.ToString("yyyy-MM-dd"), dteEnd.Value.ToString("yyyy-MM-dd"));
            frm.ShowDialog();
            forecastOverride = -1;
            btnSearch.PerformClick();
        }

        private void dgStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //needs to open a form to display all the absents etc
            frmUserAbsent frmUA = new frmUserAbsent(Convert.ToInt32(dgStaff.Rows[e.RowIndex].Cells[0].Value), dteStart.Value.ToString("yyyy-MM-dd"), dteEnd.Value.ToString("yyyy-MM-dd"));
            frmUA.ShowDialog();
            forecastOverride = -1;
            btnSearch.PerformClick();

        }

        private void btnForecast_Click(object sender, EventArgs e)
        {
            forecastPressed = -1;
            //okay so for this button to fire the start date MUST BE todays date 8D although i think i could do it another way but w/e
            //first step will be adding the column to the dgv
            if (dgDays.Columns.Contains("Spare Hours") == true)
            {
                dgDays.Columns.Remove("Spare Hours");
            }

            dgDays.Columns.Add("Spare Hours", "Spare Hours");

            columnIndex();

            //doesnt matter where this is cause we're going to hide it :}

            //next step is to go through each row and count all the work hours and minus the doors off them so we get a postivie or negative number 
            //if its a negative number then we mark it as OT is needed
            decimal forecast = 0;
            decimal OT = 0;
            for (int i = 0; i < dgDays.Rows.Count - 1; i++)
            {                                                           //this is (HOURS + OT ADDED) - (DOORS + (NON-DOORS * 0.3))
                OT = 0;
                if (dgDays.Rows[i].Cells[otAddedIndex].Value != null)
                {
                    if (dgDays.Rows[i].Cells[otAddedIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgDays.Rows[i].Cells[otAddedIndex].Value) > 0)
                            OT = Convert.ToDecimal(dgDays.Rows[i].Cells[otAddedIndex].Value);
                    }
                }
                forecast = forecast + ((Convert.ToDecimal(dgDays.Rows[i].Cells[workHoursIndex].Value) + OT) - (Convert.ToDecimal(dgDays.Rows[i].Cells[doorsIndex].Value) + (Convert.ToDecimal(dgDays.Rows[i].Cells[nonDoorsIndex].Value) * Convert.ToDecimal(0.3))));
                dgDays.Rows[i].Cells[forecastIndex].Value = forecast;
            }


            //now we go for some colouring :}
            for (int i = 0; i < dgDays.Rows.Count - 1; i++)
            {
                if (Convert.ToDecimal(dgDays.Rows[i].Cells[forecastIndex].Value) >= 0)
                    dgDays.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                else
                    dgDays.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;

                if (dgDays.Rows[i].Cells[otAddedIndex].Value != null)
                {
                    if (dgDays.Rows[i].Cells[otAddedIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgDays.Rows[i].Cells[otAddedIndex].Value) > 0)
                            dgDays.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                    }
                }


            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                btnEmail.Enabled = false;
                btnAddTempDoors.Enabled = false;
                txtTempDoors.Enabled = false;
            }
            else
            {
                if (dgDays.Rows.Count > 0)
                {
                    btnEmail.Enabled = true;
                    btnAddTempDoors.Enabled = true;
                    txtTempDoors.Enabled = true;
                }
            }

            //check if the two dates are searchable
            if (dteStart.Value < dteEnd.Value)
            {
                btnSearch.PerformClick(); //shouldnt need anything more than this :}
            }
        }

        private void dgvOtherDept_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //open form here that lets you enter overtime
            frmOtherDeptOT frm = new frmOtherDeptOT(Convert.ToDateTime(dgvOtherDept.Rows[e.RowIndex].Cells[0].Value));
            frm.ShowDialog();
            btnSearch.PerformClick();
            dgvOtherDept.ClearSelection();
        }

        // new overtime voids
        ///////////////////////////////////////////////////////////////////////////
        private void loadDGVProgramming()
        {
            DateTime temp = monday;
            //MessageBox.Show("monday = " + monday.ToShortDateString());
            //MessageBox.Show("sunday = " + sunday.ToShortDateString());
            //start filling grid now i guess

            DataTable dt = new DataTable();

            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            DataRow row2 = dt.NewRow();
            dt.Rows.Add(row2);

            //dt.Columns.Add("MyRow");
            int zzz = 0;
            string blank = " ";
            dt.Columns.Add(blank);
            for (int i = 0; i < 14; i++)
            {
                blank = blank + " ";
                if (zzz == 0)
                {
                    dt.Columns.Add(temp.DayOfWeek.ToString(), typeof(String));
                    zzz = -1;
                }
                else
                {
                    dt.Columns.Add(blank, typeof(String));
                    temp = temp.AddDays(1);
                    zzz = 0;
                }
            }
            zzz = 0;
            temp = monday;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                if (zzz == 0)
                {
                    dt.Rows[0][i] = temp.ToString("dd-MM-yyyy");                                                //("yyyy-MM-dd");
                    dt.Rows[1][i] = "Morning";
                    zzz = -1;
                }
                else
                {
                    dt.Rows[0][i] = " ";
                    dt.Rows[1][i] = "Afternoon";
                    temp = temp.AddDays(1);
                    zzz = 0;
                }
            }

            string sql = "select id, forename + ' ' + surname as [name] FROM [user_info].dbo.[user] WHERE isEngineer = -1 AND id <> 260 AND id <> 3 AND id<> 29  AND id <> 14 AND id <> 321";
            DataTable boys = new DataTable();
            int count = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(boys);
                    count = Convert.ToInt32(boys.Rows.Count);
                }

                for (int i = 1; i < count + 1; i++) //loop through each  person (going to need an overtime selection in user;
                {
                    //loop for each user
                    DataRow row3 = dt.NewRow();
                    dt.Rows.Add(row3);
                    string staff = "0";
                    staff = boys.Rows[i - 1][0].ToString();
                    string name = boys.Rows[i - 1][1].ToString();
                    //  dgOverTime.DataSource = dt;
                    temp = monday;
                    for (int y = 1; y < dt.Columns.Count; y++)
                    { //will add user ID after
                        sql = "select a.prior_work_day as [Prior Work Day OT],a.post_work_day as [Post Work Day OT],b.id AS[ID]  from dbo.staff_overtime a LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                                 "WHERE [date] >= '" + temp.ToString("yyyy-MM-dd") + "' AND  [date] <= '" + temp.ToString("yyyy-MM-dd") + "' AND b.id = " + staff + " AND dept = 7  Order by date ASC"; //going by a single staff means we can just search their ID
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable data = new DataTable();
                            da.Fill(data);
                            //add this person into the 
                            if (data.Rows.Count == 0) //if its null just stamp 0 here rather than updating
                            {
                                dt.Rows[i + 1][0] = name; //add one because i starts on the monrning/afternoon line
                                dt.Rows[i + 1][y] = "0";
                                dt.Rows[i + 1][y + 1] = "0";
                            }
                            else
                            {
                                dt.Rows[i + 1][0] = name; //adds name both times but its only because the line here is 100% (was broke above)
                                dt.Rows[i + 1][y] = data.Rows[0][0].ToString();
                                dt.Rows[i + 1][y + 1] = data.Rows[0][1].ToString();
                            }
                            y = y + 1;
                        }
                        temp = temp.AddDays(1);   //add a day to the temp date for the sql string
                    }

                }

                dt.Columns.Add(blank + " ");


                dataGridView1.DataSource = dt;

                for (int i = 0; i < count; i++)
                {
                    string staff_id = boys.Rows[i][0].ToString();
                    dt.Rows[i + 2][dt.Columns.Count - 1] = staff_id;
                }
                conn.Close();
            }
        }

        private void loadDGVOther() //this is copy paste from main code (any changes other than sql stuff needs to be applied here too)
        {
            DateTime temp = monday;

            //start filling grid now i guess

            DataTable dt = new DataTable();

            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            DataRow row2 = dt.NewRow();
            dt.Rows.Add(row2);

            //dt.Columns.Add("MyRow");
            int zzz = 0;
            string blank = " ";
            dt.Columns.Add(blank);
            for (int i = 0; i < 14; i++)
            {
                blank = blank + " ";
                if (zzz == 0)
                {
                    dt.Columns.Add(temp.DayOfWeek.ToString(), typeof(String));
                    zzz = -1;
                }
                else
                {
                    dt.Columns.Add(blank, typeof(String));
                    temp = temp.AddDays(1);
                    zzz = 0;
                }
            }
            zzz = 0;
            temp = monday;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                if (zzz == 0)
                {
                    dt.Rows[0][i] = temp.ToString("dd-MM-yyyy");                                                //("yyyy-MM-dd");
                    dt.Rows[1][i] = "Morning";
                    zzz = -1;
                }
                else
                {
                    dt.Rows[0][i] = " ";
                    dt.Rows[1][i] = "Afternoon";
                    temp = temp.AddDays(1);
                    zzz = 0;
                }
            }

            //string sql = "select id, forename + ' ' + surname as [name] FROM [user_info].dbo.[user] WHERE isEngineer = -1 AND id <> 260 AND id <> 3 AND id<> 29  AND id <> 14 ";
            string sql = "select id,forename +' ' + surname as [Name],[grouping] from[user_info].dbo.[user] where[grouping] is not null and(slimline is null or slimline = 0) and[current] = 1 AND[grouping] <> 15 AND[grouping] <> 25 AND[grouping] <> 10 AND id<> 314 " +
                    "AND id<> 226 AND id<> 4 AND id<> 27 AND id<> 28 order by [user_info].dbo.[user].[grouping] asc, forename asc";
            DataTable boys = new DataTable();
            int count = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(boys);
                    count = Convert.ToInt32(boys.Rows.Count);
                }

                for (int i = 1; i < count + 1; i++) //loop through each  person (going to need an overtime selection in user;
                {
                    //loop for each user
                    DataRow row3 = dt.NewRow();
                    dt.Rows.Add(row3);
                    string staff = "0";
                    staff = boys.Rows[i - 1][0].ToString();
                    string name = boys.Rows[i - 1][1].ToString();
                    //  dgOverTime.DataSource = dt;
                    temp = monday;
                    for (int y = 1; y < dt.Columns.Count; y++)
                    { //will add user ID after
                        sql = "select a.prior_work_day as [Prior Work Day OT],a.post_work_day as [Post Work Day OT],b.id AS[ID]  from dbo.staff_overtime a LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                                 "WHERE [date] >= '" + temp.ToString("yyyy-MM-dd") + "' AND  [date] <= '" + temp.ToString("yyyy-MM-dd") + "' AND b.id = " + staff + " AND dept <> 7  Order by date ASC"; //going by a single staff means we can just search their ID
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable data = new DataTable();
                            da.Fill(data);
                            //add this person into the 
                            if (data.Rows.Count == 0) //if its null just stamp 0 here rather than updating
                            {
                                dt.Rows[i + 1][0] = name; //add one because it starts on the monrning/afternoon line
                                dt.Rows[i + 1][y] = "0";
                                dt.Rows[i + 1][y + 1] = "0";
                            }
                            else
                            {
                                dt.Rows[i + 1][0] = name; //adds name both times but its only because the line here is 100% (was broke above)
                                dt.Rows[i + 1][y] = data.Rows[0][0].ToString();
                                dt.Rows[i + 1][y + 1] = data.Rows[0][1].ToString();
                            }
                            y = y + 1;
                        }
                        temp = temp.AddDays(1);   //add a day to the temp date for the sql string
                    }

                }

                dt.Columns.Add(blank + " ");


                dgOther.DataSource = dt;

                for (int i = 0; i < count; i++)
                {
                    string staff_id = boys.Rows[i][0].ToString();
                    dt.Rows[i + 2][dt.Columns.Count - 1] = staff_id;
                }
                conn.Close();
            }
        }

        private void formatOther()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[15].Visible = false;

            dgOther.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgOther.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOther.Columns[15].Visible = false;
        }

        private void insertData()
        {
            DateTime temp = monday;
            //update programming ot first
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int row = 2; row < dataGridView1.Rows.Count; row++)  //DOWN THE GRID
                {
                    temp = monday;
                    string staff_id = dataGridView1.Rows[row].Cells[dataGridView1.Columns.Count - 1].Value.ToString();
                    for (int column = 1; column < dataGridView1.Columns.Count - 1; column++) //ACROSS THE GRID            -1 because the final column is just the staff IDs
                    {

                        //check if there is data for this date/person  in deptartment 7 (programming)
                        string sql = "SELECT id FROM dbo.staff_overtime  WHERE [staff_id] = " + staff_id + " AND  [date] = '" + temp.ToString("yyyy-MM-dd") + "' AND [dept] = 7";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            var getData = cmd.ExecuteScalar();
                            if (getData != null)
                            {
                                temp = temp.AddDays(1);
                                column = column + 1;
                                continue; //theres an entry so we can move on
                            }
                            else
                            {
                                sql = "INSERT INTO dbo.staff_overtime (staff_id,date,dept,[prior_work_day]  ,[post_work_day]) VALUES (" + staff_id + ",'" + temp.ToString("yyyy-MM-dd") + "',7,0,0)";
                                using (SqlCommand cmdInsert = new SqlCommand(sql, conn))
                                    cmdInsert.ExecuteNonQuery();
                            }
                        }


                        // using (SqlCommand cmd = new SqlCommand(sql, conn))
                        //  cmd.ExecuteNonQuery();

                        temp = temp.AddDays(1); //move across one day
                        column = column + 1; //add an extra one to skip the afterrnoon
                    }
                }

                //now do the same but for the other dept (again its the same but we need to cater for the varying dept

                for (int row = 2; row < dgOther.Rows.Count; row++)  //DOWN THE GRID
                {
                    temp = monday;
                    string staff_id = dgOther.Rows[row].Cells[dgOther.Columns.Count - 1].Value.ToString();
                    string dept = "";
                    switch (staff_id)
                    {
                        case "13": //gez
                            dept = "8";
                            break;
                        case "14"://kai
                            dept = "8"; //kai conflicts with mainscreen as a programmer so im putting him as office 
                            break;
                        case "241"://Tim
                            dept = "30";
                            break;
                        case "260"://me me me me me
                            dept = "8"; //office is the closest thing for me i guess
                            break;
                        default:
                            dept = "27"; //default the estimating boys 
                            break;
                    }
                    for (int column = 1; column < dgOther.Columns.Count - 1; column++) //ACROSS THE GRID            -1 because the final column is just the staff IDs
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        //check if there is data for this date/person  in deptartment 7 (programming)
                        string sql = "SELECT id FROM dbo.staff_overtime  WHERE [staff_id] = " + staff_id + " AND [date] = '" + temp.ToString("yyyy-MM-dd") + "' AND [dept] = " + dept;
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            var getData = cmd.ExecuteScalar();
                            if (getData != null)
                            {
                                temp = temp.AddDays(1);
                                column = column + 1;
                                continue; //theres an entry so we can move on
                            }
                            else
                            {
                                sql = "INSERT INTO dbo.staff_overtime (staff_id,date,dept,[prior_work_day]  ,[post_work_day]) VALUES (" + staff_id + ",'" + temp.ToString("yyyy-MM-dd") + "'," + dept + ",0,0)";
                                using (SqlCommand cmdInsert = new SqlCommand(sql, conn))
                                    cmdInsert.ExecuteNonQuery();
                            }

                            temp = temp.AddDays(1); //move across one day
                            column = column + 1; //add an extra one to skip the afterrnoon
                        }
                    }
                    conn.Close();
                    
                }
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            prompt = 0;
            DateTime temp = monday;
            //update programming ot first
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int row = 2; row < dataGridView1.Rows.Count; row++)  //DOWN THE GRID
                {
                    temp = monday;
                    string staff_id = dataGridView1.Rows[row].Cells[dataGridView1.Columns.Count - 1].Value.ToString();
                    for (int column = 1; column < dataGridView1.Columns.Count - 1; column++) //ACROSS THE GRID            -1 because the final column is just the staff IDs
                    {
                        //get the morning and afternoon
                        double morning = Convert.ToDouble(dataGridView1.Rows[row].Cells[column].Value.ToString());
                        double afternoon = Convert.ToDouble(dataGridView1.Rows[row].Cells[column + 1].Value.ToString());  //add one to the column because its across one spot
                        string sql = "UPDATE dbo.staff_overtime SET [prior_work_day]  =  " + morning.ToString() + ", [post_work_day] = " + afternoon.ToString() + " WHERE [staff_id] = " + staff_id + " AND  [date] = '" + temp.ToString("yyyy-MM-dd") + "' AND [dept] = 7";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();

                        temp = temp.AddDays(1); //move across one day
                        column = column + 1; //add an extra one to skip the afterrnoon
                    }
                }
                //then go through the other dept dgv 
                //largely the same except for the sql statement and dgv names
                for (int row = 2; row < dgOther.Rows.Count; row++)  //DOWN THE GRID
                {
                    temp = monday;
                    string staff_id = dgOther.Rows[row].Cells[dgOther.Columns.Count - 1].Value.ToString();
                    string dept = "";
                    switch (staff_id)
                    {
                        case "13": //gez
                            dept = "8";
                            break;
                        case "14"://kai
                            dept = "8"; //kai conflicts with mainscreen as a programmer so im putting him as office 
                            break;
                        case "241"://Tim
                            dept = "30";
                            break;
                        case "260"://me me me me me
                            dept = "8"; //office is the closest thing for me i guess
                            break;
                        default:
                            dept = "27"; //default the estimating boys 
                            break;
                    }
                    for (int column = 1; column < dgOther.Columns.Count - 1; column++) //ACROSS THE GRID            -1 because the final column is just the staff IDs
                    {
                        //get the morning and afternoon
                        double morning = Convert.ToDouble(dgOther.Rows[row].Cells[column].Value.ToString());
                        double afternoon = Convert.ToDouble(dgOther.Rows[row].Cells[column + 1].Value.ToString());  //add one to the column because its across one spot
                        string sql = "UPDATE dbo.staff_overtime SET [prior_work_day]  =  " + morning.ToString() + ", [post_work_day] = " + afternoon.ToString() + " WHERE [staff_id] = " + staff_id + " AND  [date] = '" + temp.ToString("yyyy-MM-dd") + "' AND [dept] = " + dept; //dept to make sure people in multiple dept dont overlap


                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();

                        temp = temp.AddDays(1); //move across one day
                        column = column + 1; //add an extra one to skip the afterrnoon
                    }
                }
                conn.Close();
                MessageBox.Show("Overtime has been saved!", "Overtime", MessageBoxButtons.OK);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //check if there are unsaved changes 
                if (tabControl1.SelectedIndex == 1)
                {
                    btnCommit.Focus();
                    if (prompt == -1)
                    {
                        DialogResult result2 = MessageBox.Show("Would you like to save the overtime before exiting?", "Unsaved changes!", MessageBoxButtons.YesNo);
                        if (result2 == DialogResult.Yes)
                        {
                            btnCommit.PerformClick();
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            prompt = -1;
        }

        private void dgOther_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            prompt = -1;
        }
    }
}
