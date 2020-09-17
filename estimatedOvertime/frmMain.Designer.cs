namespace estimatedOvertime
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgDays = new System.Windows.Forms.DataGridView();
            this.dgStaff = new System.Windows.Forms.DataGridView();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "To:";
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(254, 32);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 8;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(12, 32);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(460, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgDays
            // 
            this.dgDays.AllowUserToAddRows = false;
            this.dgDays.AllowUserToDeleteRows = false;
            this.dgDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDays.Location = new System.Drawing.Point(12, 83);
            this.dgDays.Name = "dgDays";
            this.dgDays.RowHeadersVisible = false;
            this.dgDays.Size = new System.Drawing.Size(442, 355);
            this.dgDays.TabIndex = 11;
            // 
            // dgStaff
            // 
            this.dgStaff.AllowUserToAddRows = false;
            this.dgStaff.AllowUserToDeleteRows = false;
            this.dgStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStaff.Location = new System.Drawing.Point(477, 83);
            this.dgStaff.Name = "dgStaff";
            this.dgStaff.RowHeadersVisible = false;
            this.dgStaff.Size = new System.Drawing.Size(176, 185);
            this.dgStaff.TabIndex = 12;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(124, 67);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(218, 13);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Days inbetween selected programming dates";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Available staff";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dgStaff);
            this.Controls.Add(this.dgDays);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wrd13\'";
            ((System.ComponentModel.ISupportInitialize)(this.dgDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgDays;
        private System.Windows.Forms.DataGridView dgStaff;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
    }
}