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
            this.lblTotalOTNeeded = new System.Windows.Forms.Label();
            this.lblOTAssigned = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgOverTime = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEmail = new System.Windows.Forms.Button();
            this.lblFreeHours = new System.Windows.Forms.Label();
            this.dgSat = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddTempDoors = new System.Windows.Forms.Button();
            this.txtTempDoors = new System.Windows.Forms.TextBox();
            this.btnForecast = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "To:";
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(254, 28);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 8;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(12, 28);
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
            this.dgDays.AllowUserToResizeColumns = false;
            this.dgDays.AllowUserToResizeRows = false;
            this.dgDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDays.Location = new System.Drawing.Point(12, 71);
            this.dgDays.Name = "dgDays";
            this.dgDays.RowHeadersVisible = false;
            this.dgDays.Size = new System.Drawing.Size(576, 292);
            this.dgDays.TabIndex = 11;
            this.dgDays.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDays_CellDoubleClick);
            // 
            // dgStaff
            // 
            this.dgStaff.AllowUserToAddRows = false;
            this.dgStaff.AllowUserToDeleteRows = false;
            this.dgStaff.AllowUserToResizeColumns = false;
            this.dgStaff.AllowUserToResizeRows = false;
            this.dgStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStaff.Location = new System.Drawing.Point(603, 71);
            this.dgStaff.Name = "dgStaff";
            this.dgStaff.ReadOnly = true;
            this.dgStaff.RowHeadersVisible = false;
            this.dgStaff.Size = new System.Drawing.Size(176, 138);
            this.dgStaff.TabIndex = 12;
            this.dgStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStaff_CellDoubleClick);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(53, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(119, 13);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Programming Start Date";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Available staff";
            // 
            // lblTotalOTNeeded
            // 
            this.lblTotalOTNeeded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalOTNeeded.AutoSize = true;
            this.lblTotalOTNeeded.Location = new System.Drawing.Point(629, 385);
            this.lblTotalOTNeeded.Name = "lblTotalOTNeeded";
            this.lblTotalOTNeeded.Size = new System.Drawing.Size(107, 13);
            this.lblTotalOTNeeded.TabIndex = 15;
            this.lblTotalOTNeeded.Text = "No Overtime Needed";
            // 
            // lblOTAssigned
            // 
            this.lblOTAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOTAssigned.AutoSize = true;
            this.lblOTAssigned.Location = new System.Drawing.Point(629, 408);
            this.lblOTAssigned.Name = "lblOTAssigned";
            this.lblOTAssigned.Size = new System.Drawing.Size(112, 13);
            this.lblOTAssigned.TabIndex = 16;
            this.lblOTAssigned.Text = "No Overtime Assigned";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "   = No Overtime Needed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleVioletRed;
            this.label4.Location = new System.Drawing.Point(161, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "   = Overtime is Needed";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(303, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "   = Overtime Has Been Added";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Programming End Date";
            // 
            // dgOverTime
            // 
            this.dgOverTime.AllowUserToAddRows = false;
            this.dgOverTime.AllowUserToDeleteRows = false;
            this.dgOverTime.AllowUserToResizeColumns = false;
            this.dgOverTime.AllowUserToResizeRows = false;
            this.dgOverTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOverTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOverTime.Location = new System.Drawing.Point(603, 233);
            this.dgOverTime.Name = "dgOverTime";
            this.dgOverTime.ReadOnly = true;
            this.dgOverTime.RowHeadersVisible = false;
            this.dgOverTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgOverTime.Size = new System.Drawing.Size(176, 130);
            this.dgOverTime.TabIndex = 21;
            this.dgOverTime.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOverTime_CellContentDoubleClick);
            this.dgOverTime.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOverTime_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(629, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Staff Working Over Time";
            // 
            // btnEmail
            // 
            this.btnEmail.Enabled = false;
            this.btnEmail.Location = new System.Drawing.Point(574, 29);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(93, 23);
            this.btnEmail.TabIndex = 23;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lblFreeHours
            // 
            this.lblFreeHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreeHours.AutoSize = true;
            this.lblFreeHours.Location = new System.Drawing.Point(629, 430);
            this.lblFreeHours.Name = "lblFreeHours";
            this.lblFreeHours.Size = new System.Drawing.Size(112, 13);
            this.lblFreeHours.TabIndex = 24;
            this.lblFreeHours.Text = "No Overtime Assigned";
            // 
            // dgSat
            // 
            this.dgSat.AllowUserToAddRows = false;
            this.dgSat.AllowUserToDeleteRows = false;
            this.dgSat.AllowUserToResizeColumns = false;
            this.dgSat.AllowUserToResizeRows = false;
            this.dgSat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSat.Location = new System.Drawing.Point(12, 385);
            this.dgSat.Name = "dgSat";
            this.dgSat.RowHeadersVisible = false;
            this.dgSat.Size = new System.Drawing.Size(577, 113);
            this.dgSat.TabIndex = 25;
            this.dgSat.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSat_CellDoubleClick);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Weekend OverTime";
            // 
            // btnAddTempDoors
            // 
            this.btnAddTempDoors.Enabled = false;
            this.btnAddTempDoors.Location = new System.Drawing.Point(673, 29);
            this.btnAddTempDoors.Name = "btnAddTempDoors";
            this.btnAddTempDoors.Size = new System.Drawing.Size(120, 23);
            this.btnAddTempDoors.TabIndex = 27;
            this.btnAddTempDoors.Text = "Provisional Booking in";
            this.btnAddTempDoors.UseVisualStyleBackColor = true;
            this.btnAddTempDoors.Click += new System.EventHandler(this.btnAddTempDoors_Click);
            // 
            // txtTempDoors
            // 
            this.txtTempDoors.Location = new System.Drawing.Point(673, 5);
            this.txtTempDoors.Name = "txtTempDoors";
            this.txtTempDoors.Size = new System.Drawing.Size(120, 20);
            this.txtTempDoors.TabIndex = 28;
            this.txtTempDoors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempDoors_KeyDown);
            this.txtTempDoors.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempDoors_KeyPress);
            // 
            // btnForecast
            // 
            this.btnForecast.Location = new System.Drawing.Point(632, 464);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(93, 23);
            this.btnForecast.TabIndex = 29;
            this.btnForecast.Text = "Forecast";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 510);
            this.Controls.Add(this.btnForecast);
            this.Controls.Add(this.txtTempDoors);
            this.Controls.Add(this.btnAddTempDoors);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgSat);
            this.Controls.Add(this.lblFreeHours);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgOverTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOTAssigned);
            this.Controls.Add(this.lblTotalOTNeeded);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSat)).EndInit();
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
        private System.Windows.Forms.Label lblTotalOTNeeded;
        private System.Windows.Forms.Label lblOTAssigned;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgOverTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblFreeHours;
        private System.Windows.Forms.DataGridView dgSat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddTempDoors;
        private System.Windows.Forms.TextBox txtTempDoors;
        private System.Windows.Forms.Button btnForecast;
    }
}