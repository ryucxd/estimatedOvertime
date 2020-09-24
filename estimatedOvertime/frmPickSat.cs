using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estimatedOvertime
{
    public partial class frmPickSat : Form
    {
        public frmPickSat(DateTime start, DateTime end)
        {
            InitializeComponent();

            //add datagridview columns

            dataGridView1.Columns.Add("Saturday", "Saturday");


            //use the two dates to pick out any saturdays between them
            double countDays = (start - end).TotalDays;
            if (countDays < 0)
                countDays = countDays * -1;

            DateTime tempDate = start;
            for (int i = 0; i < countDays; i++)
            {
                if (tempDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    var sat = dataGridView1.Rows.Add();
                    dataGridView1.Rows[sat].Cells["Saturday"].Value = tempDate.ToString("yyyy-MM-dd");
                }
                tempDate = tempDate.AddDays(1);
            }
            //now that we have added the saturdays we have to find the closest saturday to the END date 
            //for example end user picks mon-fri but wants to add overtime in on the saturday
            tempDate = end;
            for (int i = 0; i < 7;i++)
            {
                if (tempDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    var sat = dataGridView1.Rows.Add();
                    dataGridView1.Rows[sat].Cells["Saturday"].Value = tempDate.ToString("yyyy-MM-dd");
                    i = 99;
                }
                tempDate = tempDate.AddDays(1);
            }

            //formatting

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


      //      dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //remove colour if its the same?
            if (dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.DeepSkyBlue)
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;

            //loop through everything and check for other colours and null them
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.DeepSkyBlue)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
            }

            //now we set the colour of the selected row 
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
            dataGridView1.ClearSelection();
        }

        private void frmPickSat_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int validation = 0;
            int index = 0;
            for (int i = 0; i < dataGridView1.Rows.Count;i++)
            {
                if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.DeepSkyBlue)
                {
                    validation = -1;
                    index = i;
                }
            }

            if (validation == -1)
            {
                //here we open the actual saturday form and from there we let the end user insert overtime
                this.Hide();
                frmSatProgramming frm = new frmSatProgramming(Convert.ToDateTime(dataGridView1.Rows[index].Cells[0].Value.ToString()), -1);
                frm.ShowDialog();
                this.Close();
            }

        }
    }
}
