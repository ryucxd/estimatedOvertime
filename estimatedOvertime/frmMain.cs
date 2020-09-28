﻿using System;
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
    public partial class frmMain : Form
    {
        public DateTime startDate7Days { get; set; }
        public DateTime endDate7Days { get; set; }
        public double nonDoorValue { get; set; }

        //dgv indexs 
        public int programmingDateIndex { get; set; }
        public int completionDateIndex { get; set; }
        public int doorsIndex { get; set; }
        public int nonDoorsIndex { get; set; }
        public int workHoursIndex { get; set; }
        public int otNeededIndex { get; set; }
        public int otAddedIndex { get; set; }


        //these props are for label manipulation
        public decimal _hoursSpare { get; set; }
        public decimal _overTimeNeeded { get; set; }
        public decimal MyProperty { get; set; }
        public frmMain()
        {
            InitializeComponent();
            nonDoorValue = 0.3;
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
                dgStaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgStaff.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                foreach (DataGridViewColumn col in dgStaff.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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
            //lets try and keep this very clean :)

            //first up is going to be working out the dats (adding 7 days) for the start and finish date
            DateTime startDate;
            DateTime endDate;

            //work out the 7 working day difference here before adding it to the string using func_work_days_plus
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                sql = "SELECT dbo.func_work_days_plus('" + dteStart.Value.ToString("yyyy-MM-dd") + "', 7)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    startDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    startDate7Days = Convert.ToDateTime(cmd.ExecuteScalar());
                    conn.Close();
                }
                sql = "SELECT dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyy-MM-dd") + "', 7)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    endDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    endDate7Days = Convert.ToDateTime(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            //so from here now we need to add each day into the datagridview
            //best way i can see of doing this is to make a bootleg dbo.func_work_days_plus where i just factor everything into a loop and insert each date
            double countDays = (startDate - endDate).Days;
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
                    dgDays.Rows[index].Cells["Programming Date"].Value = tempDate.ToString("yyyy-MM-dd");
                    dgDays.Rows[index].Cells["Completion Date"].Value = tempDate.ToString("yyyy-MM-dd");
                    tempDate = tempDate.AddDays(1);
                }
                dgDays.Columns[programmingDateIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgDays.Columns[completionDateIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                //gonna add a column for lates :}

                var late = dgDays.Rows.Add();
                dgDays.Rows[late].Cells["Programming Date"].Value = "LATES";

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
                     "a.date_completion >= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "' AND a.date_completion <= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dgDays.Rows[i].Cells[doorsIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                    }

                    //non doors here xoxo
                    sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                     "AND (c.double_y_n is  NULL) AND  (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                     "a.date_completion >= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "' AND a.date_completion <= '" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        dgDays.Rows[i].Cells[nonDoorsIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                    }
                }
                //and then add the lates ¬
                sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                         "AND (c.double_y_n IS NOT  NULL) AND (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                         "a.date_completion < '" + startDate7Days.ToString("yyyy-MM-dd") + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    dgDays.Rows[dgDays.Rows.Count - 1].Cells[doorsIndex].Value = Convert.ToString(cmd.ExecuteScalar());
                }
                //non door lates
                sql = "select COUNT(a.ID) from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id WHERE (b.programed_by_id IS NULL) AND (a.status_id = 1 OR a.status_id = 2) " +
                         "AND (c.double_y_n is  NULL) AND (c.slimline_y_n IS NULL OR c.slimline_y_n = 0) AND (a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND (a.door_type_id <> 113) AND (a.order_number <> 'Bridge Street Cut Downs') AND " +
                         "a.date_completion < '" + startDate7Days.ToString("yyyy-MM-dd") + "'";
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
                    int provisonalRemove = 0;
                    //need to go back 7 days
                    DateTime tempDate = Convert.ToDateTime(dgDays.Rows[i].Cells[programmingDateIndex].Value);
                    using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',6)", conn)) //herehere
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
                            //colour
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                                dgStaff.Rows[x].DefaultCellStyle.BackColor = Color.PaleVioletRed;

                            //its either 8/7 or its 0 (0 is current and 8-7 is absent



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
            overTimeNeeded();
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
                    using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + dgvDate.ToString("yyyy-MM-dd") + "',6)", conn)) //herehere
                        dgvDate = Convert.ToDateTime(cmd.ExecuteScalar());

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
                    using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',6)", conn))
                        tempDate = Convert.ToDateTime(cmd.ExecuteScalar());

                    sql = "SELECT SUM(COALESCE(prior_work_day,0) + COALESCE(post_work_day,0)) as [total OT] FROM dbo.staff_overtime WHERE date = '" + tempDate.ToString("yyyy-MM-dd") + "'";

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
                    "WHERE(prior_work_day > 0 OR post_work_day > 0) and  date >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
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
            frmOverTmeInput frm = new frmOverTmeInput(Convert.ToDateTime(tempDate));
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

                    sql = "SELECT SUM(COALESCE(prior_work_day,0) + COALESCE(post_work_day,0)) as [total OT] FROM dbo.staff_overtime WHERE date = '" + tempDate.ToString("yyyy-MM-dd") + "'";

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
            if (hoursFree > 0)
            {
                if (OTNeeded > 0)
                {
                    if ((OTNeeded - hoursFree) < 0)
                    {
                        lblTotalOTNeeded.Text = (OTNeeded - hoursFree).ToString() + " Over Time Needed";
                        lblFreeHours.Text = "No Spare Hours";
                    }
                    else
                    {
                        lblTotalOTNeeded.Text = "No Over Time Needed";
                        lblFreeHours.Text = (hoursFree - OTNeeded).ToString() + " Spare Hours";
                    }
                }
                else
                {
                    lblTotalOTNeeded.Text = "No Over Time Needed";
                    lblFreeHours.Text = hoursFree.ToString() + " Spare Hours";
                }
            }
            else
            {
                lblFreeHours.Text = "No Spare Hours";
                if (OTNeeded > 0)
                    lblTotalOTNeeded.Text = OTNeeded.ToString() + " Over Time Needed";
                else
                    lblTotalOTNeeded.Text = "No Over Time Needed";
            }

            if (OTNeeded > 0)
                lblTotalOTNeeded.Text = OTNeeded.ToString() + " Hours Over Time Needed";
            else
                lblTotalOTNeeded.Text = " No Over Time Needed";
            if (hoursFree > 0)
            {
                lblFreeHours.Text = hoursFree.ToString() + " Hours spare";
                lblTotalOTNeeded.Text = " No Over Time Needed";
            }
            else
                lblFreeHours.Text = " No Hours spare";
        }


        private void fixDates()
        {
            //here we are going to go over the dates selected and add them 
            //need to go back 7 days
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                // MessageBox.Show(tempDate.ToString("yyyy-MM-dd"));
                for (int i = 0; i < dgDays.Rows.Count - 1; i++)
                {
                    DateTime tempDate = Convert.ToDateTime(dgDays.Rows[i].Cells[programmingDateIndex].Value);
                    using (SqlCommand cmd = new SqlCommand("select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',6)", conn)) //herehere
                        tempDate = Convert.ToDateTime(cmd.ExecuteScalar());

                    dgDays.Rows[i].Cells[programmingDateIndex].Value = tempDate.ToString("yyyy-MM-dd");

                }
                conn.Close();
            }

        }



        private void dgOverTime_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            //upload the days dgv to a table and email that bad boy
            //staff_overtime_temp

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //first we need to wipe the table for the previous data
                string sql = "DELETE FROM dbo.staff_overtime_temp";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                //now we insert
                for (int i = 0; i < dgDays.Rows.Count; i++)
                {
                    double otNeeded = 0;
                    if (String.IsNullOrEmpty(dgDays.Rows[i].Cells[otNeededIndex].Value.ToString()))
                        otNeeded = 0.0;
                    else
                        otNeeded = Convert.ToInt32(dgDays.Rows[i].Cells[otNeededIndex].Value);

                    int workHours = 0;
                    if (dgDays.Rows[i].Cells[workHoursIndex].Value?.ToString() == null)
                        workHours = 0;
                    else
                        workHours = Convert.ToInt32(dgDays.Rows[i].Cells[workHoursIndex].Value);


                    sql = "INSERT INTO dbo.staff_overtime_temp (date,doors,nonDoors,workHours,otNeeded) VALUES (" +
                    "'" + dgDays.Rows[i].Cells[programmingDateIndex].Value.ToString() + "'," + //date
                    "" + dgDays.Rows[i].Cells[doorsIndex].Value.ToString() + "," + //doors
                    "" + dgDays.Rows[i].Cells[nonDoorsIndex].Value.ToString() + "," +//nonDoors
                    "" + workHours + "," +//workHours
                    "" + otNeeded.ToString() + ")"; //otNeeded

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();

                }
                //usp_email_programming_OT
                //here we fire the procedure 
                using (SqlCommand cmd = new SqlCommand("usp_email_programming_OT", conn)
                { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = dteStart.Value.ToString("yyyy-MM-dd");
                    cmd.Parameters.Add("@endDate", SqlDbType.VarChar).Value = dteEnd.Value.ToString("yyyy-MM-dd");
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Email Sent", "!", MessageBoxButtons.OK);
                btnEmail.Enabled = false;
            }
        }

        private void dgSat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmSatProgramming frm = new frmSatProgramming(Convert.ToDateTime(dgSat.Rows[e.RowIndex].Cells[0].Value), 0);
            frm.ShowDialog();
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

        }

        private void btnAddTempDoors_Click(object sender, EventArgs e)
        {
            //all the workings out for this are in overtime();
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
            btnSearch.PerformClick();
        }

        private void dgStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //needs to open a form to display all the absents etc
            frmUserAbsent frmUA = new frmUserAbsent(Convert.ToInt32(dgStaff.Rows[e.RowIndex].Cells[0].Value), dteStart.Value.ToString("yyyy-MM-dd"), dteEnd.Value.ToString("yyyy-MM-dd"));
            frmUA.ShowDialog();
            btnSearch.PerformClick();

        }

        private void btnForecast_Click(object sender, EventArgs e)
        {
            //count everything prior to
            DateTime getDate = DateTime.Today;
            if (getDate == dteStart.Value)
            {
                //this cant be done so cancel it
                MessageBox.Show("The start date can not be the same as today's date", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if (getDate > dteStart.Value)
            {
                MessageBox.Show("The start date can not be less than today's date", "ERROR", MessageBoxButtons.OK);
                return;
            }

            //now from here we just count what spare hours we have from getdate() and add it too the total spare hours 
            //first step will be counting the days between getdate and startdate and working out how mnay hours to add etc
            //....also going to need to check if any of the boys are absent on that date.........................................................
            int countDays = (getDate - dteStart.Value).Days;
            if (countDays < 0)
                countDays = countDays * -1;
            // countDays = Math.Round(countDays);
            MessageBox.Show(countDays.ToString());

            //now we have the number of days between getdate and  the start date

            //start working out the number of hours available
            double hoursAvailable = 0;
            double hoursRemove = 0;
            string sql = "";
            DateTime tempDate = getDate;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                for (double i = 0; i < countDays; i++)
                {
                    //first check if its a sat/sun and if it is then we skip this iteration
                    if (tempDate.DayOfWeek == DayOfWeek.Saturday || tempDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //add a day to tempdate and then move on
                        tempDate = tempDate.AddDays(1);
                        continue;
                    }
                    for (int x = 0; x < dgStaff.Rows.Count; x++)
                    {
                        //work out if its a friday
                        if (tempDate.DayOfWeek == DayOfWeek.Friday)
                        {
                            sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) = 'Friday' THEN 7 ELSE 0 END),0) as [monday-thursday]" +
                                     " FROM dbo.absent_holidays WHERE date_absent = '" + tempDate.ToString("yyyy-MM-dd") + "' AND staff_id =  " + dgStaff.Rows[x].Cells[0].Value.ToString();
                            hoursAvailable = hoursAvailable + 7;
                        }
                        else //mon - thurs
                        {
                            sql = "SELECT COALESCE(SUM(CASE WHEN DATENAME(DW,date_absent) <>'Friday' THEN 8 ELSE 0 END),0) as [monday-thursday]" +
                                     " FROM dbo.absent_holidays WHERE date_absent = '" + tempDate.ToString("yyyy-MM-dd") + "' AND  staff_id =  " + dgStaff.Rows[x].Cells[0].Value.ToString();
                            hoursAvailable = hoursAvailable + 8;
                        }

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            conn.Open();
                            hoursRemove = hoursRemove + Convert.ToInt32(cmd.ExecuteScalar());
                            conn.Close();
                        }
                    }
                    tempDate = tempDate.AddDays(1);
                }
            }


            //now we look in provisional
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                tempDate = getDate;
                DateTime provisionalStartDate;
                DateTime provisionalEndDate;


                //loop through each user and see if they have a provisonal date that matches up to the dgvdate
                for (int x = 0; x < dgStaff.Rows.Count; x++)
                {
                    tempDate = getDate;
                    //get users provisional dates and such
                    sql = "SELECT date_start FROM dbo.staff_provisional_absences WHERE staff_id = " + dgStaff.Rows[x].Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        provisionalStartDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    sql = "SELECT date_end FROM dbo.staff_provisional_absences WHERE staff_id = " + dgStaff.Rows[x].Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        provisionalEndDate = Convert.ToDateTime(cmd.ExecuteScalar());

                    //count the days between the start and end date of provisional days
                    double countDaysProv = (provisionalStartDate - provisionalEndDate).Days;
                    if (countDaysProv < 0)
                        countDaysProv = countDaysProv * -1;

                    DateTime tempDateProv = provisionalStartDate;
                    //loop through all of the days 
                    for (int z = 0; z < countDays; z++)
                    {
                        if (tempDateProv == tempDate)
                        {
                            if (tempDateProv.DayOfWeek == DayOfWeek.Saturday || tempDateProv.DayOfWeek == DayOfWeek.Sunday)
                            {
                                tempDate = tempDate.AddDays(1);
                                tempDateProv = tempDateProv.AddDays(1);
                                continue;
                            }
                            //check if temp is a friday
                            if (tempDateProv.DayOfWeek == DayOfWeek.Friday)
                            {
                                hoursRemove = hoursRemove + 7;
                                tempDateProv = tempDateProv.AddDays(1);
                            }
                            else
                            {
                                hoursRemove = hoursRemove + 8;
                                tempDateProv = tempDateProv.AddDays(1);
                            }
                        }

                        tempDate = tempDate.AddDays(1);
                    }

                }

                conn.Close();
            }
            //loop for that is over now 
            //assuming that that is right 
            MessageBox.Show("Hours Available: " + hoursAvailable.ToString());
            MessageBox.Show("Hours Remove: " + hoursRemove.ToString());
            hoursAvailable = hoursAvailable - hoursRemove;
            MessageBox.Show("Spare hours from last week: " + hoursAvailable.ToString());

            //now here we update the labels 8D
            //hours avail is the total from last week afaik

            lblFreeHours.Text = (Convert.ToDouble(_hoursSpare) + hoursAvailable).ToString() + " Hours Free";

            decimal hoursFree = _hoursSpare + Convert.ToDecimal(hoursAvailable);
            decimal OTNeeded = _overTimeNeeded;

            if (hoursFree > 0)
            {
                if (OTNeeded > 0)
                {
                    if ((OTNeeded > hoursFree))
                    {
                        lblTotalOTNeeded.Text = (OTNeeded - hoursFree).ToString() + " Over Time Needed";
                        lblFreeHours.Text = "No Spare Hours";
                    }
                    else
                    {
                        lblTotalOTNeeded.Text = "No Over Time Needed";
                        lblFreeHours.Text = (hoursFree - OTNeeded).ToString() + " Spare Hours";
                    }
                }
                else
                {
                    lblTotalOTNeeded.Text = "No Over Time Needed";
                    lblFreeHours.Text = hoursFree.ToString() + " Spare Hours";
                }
            }
            else
            {
                lblFreeHours.Text = "No Spare Hours";
                if (OTNeeded > 0)
                    lblTotalOTNeeded.Text = OTNeeded.ToString() + " Over Time Needed";
                else
                    lblTotalOTNeeded.Text = "No Over Time Needed";
            }

        }
    }
}
