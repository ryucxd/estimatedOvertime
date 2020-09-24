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
    public partial class frmTempAbsentDates : Form
    {
        public int staff_id { get; set; }
        public frmTempAbsentDates(int passedID)
        {
            InitializeComponent();
            staff_id = passedID;
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            //staff_provisional_absences
            //first we delete any instances of THAT user 
            string sql = "DELETE FROM dbo.staff_provisional_absences WHERE staff_id = " + staff_id;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                //now we insert the dates :}
                sql = "INSERT INTO dbo.staff_provisional_absences (staff_id,date_start,date_end) VALUES (" + staff_id + ", '" + dteStart.Value.ToString("yyyy-MM-dd") + "','" + dteEnd.Value.ToString("yyyy-MM-dd") + "')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                    conn.Close();
            }
            this.Close();
        }
    }
}
