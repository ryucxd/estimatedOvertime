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
    public partial class frmLates : Form
    {
        public frmLates(DateTime passedDate)
        {
            InitializeComponent();

            string sql = " select a.id,d.[NAME], a.date_order as [Order Date],a.date_completion as [Completion Date] from dbo.door a LEFT OUTER JOIN dbo.door_program AS b ON a.id = b.door_id LEFT OUTER JOIN dbo.door_type AS c ON a.door_type_id = c.id " +
                "LEFT OUTER JOIN dbo.SALES_LEDGER as d ON a.customer_acc_ref = d.ACCOUNT_REF WHERE(b.programed_by_id IS NULL) AND(a.status_id = 1 OR a.status_id = 2) AND(c.double_y_n IS NOT  NULL) AND(c.slimline_y_n IS NULL OR c.slimline_y_n = 0) " +
                "AND(a.date_completion IS NOT NULL) AND(a.door_type_id <> 48) AND(a.door_type_id <> 113) AND(a.order_number <> 'Bridge Street Cut Downs') AND a.date_completion <  '" + passedDate.ToString("yyyy-MM-dd") + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.Columns.Add("Program Date");
                    //now we add program date for everyone
                    foreach (DataRow row in dt.Rows)
                    {
                        //need to grab the comp date and remove 6 working daysd
                        DateTime tempDate = Convert.ToDateTime(row["Completion Date"].ToString());
                        sql = "select dbo.func_work_days('" + tempDate.ToString("yyyy-MM-dd") + "',6)";
                        using (SqlCommand cmd2 = new SqlCommand(sql, conn)) //herehere
                        {
                           tempDate = Convert.ToDateTime(cmd2.ExecuteScalar());
                        }
                        row["Program Date"] = tempDate.ToString("yyyy-MM-dd");
                    }
                    dataGridView1.DataSource = dt;
                }
                conn.Close();
            }
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
