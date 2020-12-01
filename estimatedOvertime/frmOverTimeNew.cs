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

            MessageBox.Show("monday = " + monday.ToShortDateString());
            MessageBox.Show("sunday = " + sunday.ToShortDateString());

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
                            y  = y + 1;
                        }
                            temp = temp.AddDays(1);   //add a day to the temp date for the sql string
                    }

                }

                dt.Columns.Add(blank + " ");


                dgOverTime.DataSource = dt;

                for (int i = 0; i < count;i++)
                {
                    string staff_id = boys.Rows[i][0].ToString();
                    dt.Rows[i + 2][dt.Columns.Count -1] = staff_id;
                }
                conn.Close();
            }


            sql = "select b.id AS [ID], b.forename + ' ' + b.surname as [Full Name], a.prior_work_day as [Prior Work Day OT],a.post_work_day as [Post Work Day OT] from dbo.staff_overtime a LEFT JOIN[user_info].dbo.[user] b ON a.staff_id = b.id " +
                       "WHERE [date] >= '" + monday.ToString("yyyy-MM-dd") + "' AND  [date] <= '" + monday.ToString("yyyy-MM-dd") + "' AND b.isEngineer = -1 AND b.id <> 260 AND b.id <> 3 AND b.id <> 29  AND b.id <> 14 AND a.dept = 7  Order by forename ASC";



            //format

            dgOverTime.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        }
    }
}
