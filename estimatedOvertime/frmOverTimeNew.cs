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
    public partial class frmOverTimeNew : Form
    {
        public DateTime monday { get; set; }
        public DateTime sunday { get; set; }
        public frmOverTimeNew(DateTime temp) // frmWasteOfTime
        {
            InitializeComponent();
            //first step is get monday + sunday between the date clicked 
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

            loadDGVProgramming();
            loadDGVOther();
            format();
            insertData();
            //check everyone has an entry for the dates below (theres no insert in the add overtime button because we're adding it in here






            string sql = "select b.id AS [ID], b.forename + ' ' + b.surname as [Full Name], a.prior_work_day as [Prior Work Day OT],a.post_work_day as [Post Work Day OT] from dbo.staff_overtime a LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                       "WHERE [date] >= '" + monday.ToString("yyyy-MM-dd") + "' AND  [date] <= '" + monday.ToString("yyyy-MM-dd") + "' AND b.isEngineer = -1 AND b.id <> 260 AND b.id <> 3 AND b.id <> 29  AND b.id <> 14 AND a.dept = 7  Order by forename ASC";
        }


        private void format()
        {
            dgOverTime.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgOverTime.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgOverTime.Columns[15].Visible = false;

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
                    dt.Rows[0][i] = temp.ToString("yyyy-MM-dd");
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

            string sql = "select id, forename + ' ' + surname as [name] FROM [user_info].dbo.[user] WHERE isEngineer = -1 AND id <> 260 AND id <> 3 AND id<> 29  AND id <> 14 ";
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
                                 "WHERE [date] >= '" + temp.ToString("yyyy-MM-dd") + "' AND  [date] <= '" + temp.ToString("yyyy-MM-dd") + "' AND b.id = " + staff + "  Order by date ASC"; //going by a single staff means we can just search their ID
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


                dgOverTime.DataSource = dt;

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
                    dt.Rows[0][i] = temp.ToString("yyyy-MM-dd");
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
                                 "WHERE [date] >= '" + temp.ToString("yyyy-MM-dd") + "' AND  [date] <= '" + temp.ToString("yyyy-MM-dd") + "' AND b.id = " + staff + "  Order by date ASC"; //going by a single staff means we can just search their ID
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


                dgOther.DataSource = dt;

                for (int i = 0; i < count; i++)
                {
                    string staff_id = boys.Rows[i][0].ToString();
                    dt.Rows[i + 2][dt.Columns.Count - 1] = staff_id;
                }
                conn.Close();
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOverTimeNew_Shown(object sender, EventArgs e)
        {
            dgOverTime.ClearSelection(); //removes that annoying highlight that is in the top left
        }

        private void btnCommit_Click(object sender, EventArgs e)
        { 
            DateTime temp = monday;
            //update programming ot first
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int row = 2; row < dgOverTime.Rows.Count; row++)  //DOWN THE GRID
                {
                    temp = monday;
                    string staff_id = dgOverTime.Rows[row].Cells[dgOverTime.Columns.Count - 1].Value.ToString();
                    for (int column = 1; column < dgOverTime.Columns.Count - 1; column++) //ACROSS THE GRID            -1 because the final column is just the staff IDs
                    {
                        //get the morning and afternoon
                        double morning = Convert.ToDouble(dgOverTime.Rows[row].Cells[column].Value.ToString());
                        double afternoon = Convert.ToDouble(dgOverTime.Rows[row].Cells[column + 1].Value.ToString());  //add one to the column because its across one spot
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
            }
            this.Close();
        }



        private void insertData()
        {
            DateTime temp = monday;
            //update programming ot first
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int row = 2; row < dgOverTime.Rows.Count; row++)  //DOWN THE GRID
                {
                     temp = monday;
                    string staff_id = dgOverTime.Rows[row].Cells[dgOverTime.Columns.Count - 1].Value.ToString();
                    for (int column = 1; column < dgOverTime.Columns.Count - 1; column++) //ACROSS THE GRID            -1 because the final column is just the staff IDs
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
    }
}
