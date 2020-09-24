namespace estimatedOvertime
{
    partial class frmTempAbsentDates
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.btnGO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(12, 26);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 0;
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(252, 26);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 1;
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(184, 52);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(95, 23);
            this.btnGO.TabIndex = 2;
            this.btnGO.Text = "Add Absences";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // frmTempAbsentDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 83);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTempAbsentDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert Absent Dates";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Button btnGO;
    }
}