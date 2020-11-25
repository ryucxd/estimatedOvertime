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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvOtherDept = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSat)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherDept)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "To:";
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(254, 33);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 8;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(12, 33);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(460, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search ";
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
            this.dgDays.Location = new System.Drawing.Point(6, 32);
            this.dgDays.Name = "dgDays";
            this.dgDays.RowHeadersVisible = false;
            this.dgDays.Size = new System.Drawing.Size(576, 316);
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
            this.dgStaff.Location = new System.Drawing.Point(601, 32);
            this.dgStaff.Name = "dgStaff";
            this.dgStaff.ReadOnly = true;
            this.dgStaff.RowHeadersVisible = false;
            this.dgStaff.Size = new System.Drawing.Size(176, 142);
            this.dgStaff.TabIndex = 12;
            this.dgStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStaff_CellDoubleClick);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(12, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(200, 20);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Programming Start Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(628, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Available staff";
            // 
            // lblTotalOTNeeded
            // 
            this.lblTotalOTNeeded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalOTNeeded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOTNeeded.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalOTNeeded.Location = new System.Drawing.Point(589, 389);
            this.lblTotalOTNeeded.Name = "lblTotalOTNeeded";
            this.lblTotalOTNeeded.Size = new System.Drawing.Size(193, 26);
            this.lblTotalOTNeeded.TabIndex = 15;
            this.lblTotalOTNeeded.Text = "No Overtime Needed";
            this.lblTotalOTNeeded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOTAssigned
            // 
            this.lblOTAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOTAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTAssigned.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOTAssigned.Location = new System.Drawing.Point(589, 475);
            this.lblOTAssigned.Name = "lblOTAssigned";
            this.lblOTAssigned.Size = new System.Drawing.Size(193, 26);
            this.lblOTAssigned.TabIndex = 16;
            this.lblOTAssigned.Text = "No Overtime Assigned";
            this.lblOTAssigned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "   = No Overtime Needed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleVioletRed;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(156, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "   = Overtime is Needed";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(298, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "   = Overtime Has Been Added";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(254, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Programming End Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgOverTime
            // 
            this.dgOverTime.AllowUserToAddRows = false;
            this.dgOverTime.AllowUserToDeleteRows = false;
            this.dgOverTime.AllowUserToResizeColumns = false;
            this.dgOverTime.AllowUserToResizeRows = false;
            this.dgOverTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOverTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOverTime.Location = new System.Drawing.Point(601, 214);
            this.dgOverTime.Name = "dgOverTime";
            this.dgOverTime.ReadOnly = true;
            this.dgOverTime.RowHeadersVisible = false;
            this.dgOverTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgOverTime.Size = new System.Drawing.Size(176, 134);
            this.dgOverTime.TabIndex = 21;
            this.dgOverTime.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOverTime_CellContentDoubleClick);
            this.dgOverTime.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOverTime_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(586, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Staff Working Over Time";
            // 
            // btnEmail
            // 
            this.btnEmail.Enabled = false;
            this.btnEmail.Location = new System.Drawing.Point(586, 30);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(120, 23);
            this.btnEmail.TabIndex = 23;
            this.btnEmail.Text = "Send Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lblFreeHours
            // 
            this.lblFreeHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreeHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreeHours.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFreeHours.Location = new System.Drawing.Point(589, 432);
            this.lblFreeHours.Name = "lblFreeHours";
            this.lblFreeHours.Size = new System.Drawing.Size(193, 26);
            this.lblFreeHours.TabIndex = 24;
            this.lblFreeHours.Text = "No Spare Hours";
            this.lblFreeHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dgSat.Location = new System.Drawing.Point(6, 389);
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
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(577, 24);
            this.label8.TabIndex = 26;
            this.label8.Text = "Weekend OverTime";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddTempDoors
            // 
            this.btnAddTempDoors.Enabled = false;
            this.btnAddTempDoors.Location = new System.Drawing.Point(585, 78);
            this.btnAddTempDoors.Name = "btnAddTempDoors";
            this.btnAddTempDoors.Size = new System.Drawing.Size(120, 23);
            this.btnAddTempDoors.TabIndex = 27;
            this.btnAddTempDoors.Text = "Provisional Booking in";
            this.btnAddTempDoors.UseVisualStyleBackColor = true;
            this.btnAddTempDoors.Click += new System.EventHandler(this.btnAddTempDoors_Click);
            // 
            // txtTempDoors
            // 
            this.txtTempDoors.Location = new System.Drawing.Point(459, 80);
            this.txtTempDoors.Name = "txtTempDoors";
            this.txtTempDoors.Size = new System.Drawing.Size(120, 20);
            this.txtTempDoors.TabIndex = 28;
            this.txtTempDoors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempDoors_KeyDown);
            this.txtTempDoors.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempDoors_KeyPress);
            // 
            // btnForecast
            // 
            this.btnForecast.Enabled = false;
            this.btnForecast.Location = new System.Drawing.Point(474, 8);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(108, 23);
            this.btnForecast.TabIndex = 29;
            this.btnForecast.Text = "Forecast";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 535);
            this.tabControl1.TabIndex = 30;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgDays);
            this.tabPage1.Controls.Add(this.btnForecast);
            this.tabPage1.Controls.Add(this.dgStaff);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblTotalOTNeeded);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lblOTAssigned);
            this.tabPage1.Controls.Add(this.dgSat);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblFreeHours);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dgOverTime);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programming";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvOtherDept);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 493);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Other Department";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvOtherDept
            // 
            this.dgvOtherDept.AllowUserToAddRows = false;
            this.dgvOtherDept.AllowUserToDeleteRows = false;
            this.dgvOtherDept.AllowUserToResizeColumns = false;
            this.dgvOtherDept.AllowUserToResizeRows = false;
            this.dgvOtherDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOtherDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherDept.Location = new System.Drawing.Point(6, 14);
            this.dgvOtherDept.Name = "dgvOtherDept";
            this.dgvOtherDept.RowHeadersVisible = false;
            this.dgvOtherDept.Size = new System.Drawing.Size(784, 473);
            this.dgvOtherDept.TabIndex = 12;
            this.dgvOtherDept.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOtherDept_CellDoubleClick);
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(12, 77);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(200, 23);
            this.label.TabIndex = 31;
            this.label.Text = "Select Department";
            this.label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(459, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(336, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Provisionally add doors evenly across the days added";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 648);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtTempDoors);
            this.Controls.Add(this.btnAddTempDoors);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estimated Over Time";
            ((System.ComponentModel.ISupportInitialize)(this.dgDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSat)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherDept)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvOtherDept;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label9;
    }
}