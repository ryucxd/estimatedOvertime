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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.btnOTEmail = new System.Windows.Forms.Button();
            this.lblOTDATE = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgOther = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(216, 33);
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
            this.lblTotalOTNeeded.Location = new System.Drawing.Point(586, 389);
            this.lblTotalOTNeeded.Name = "lblTotalOTNeeded";
            this.lblTotalOTNeeded.Size = new System.Drawing.Size(193, 43);
            this.lblTotalOTNeeded.TabIndex = 15;
            this.lblTotalOTNeeded.Text = "No Overtime Needed";
            this.lblTotalOTNeeded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOTAssigned
            // 
            this.lblOTAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOTAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTAssigned.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOTAssigned.Location = new System.Drawing.Point(589, 474);
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
            this.btnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmail.Enabled = false;
            this.btnEmail.Location = new System.Drawing.Point(342, 33);
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
            this.lblFreeHours.Location = new System.Drawing.Point(589, 440);
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
            this.btnAddTempDoors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTempDoors.Enabled = false;
            this.btnAddTempDoors.Location = new System.Drawing.Point(342, 81);
            this.btnAddTempDoors.Name = "btnAddTempDoors";
            this.btnAddTempDoors.Size = new System.Drawing.Size(120, 23);
            this.btnAddTempDoors.TabIndex = 27;
            this.btnAddTempDoors.Text = "Provisional Booking in";
            this.btnAddTempDoors.UseVisualStyleBackColor = true;
            this.btnAddTempDoors.Click += new System.EventHandler(this.btnAddTempDoors_Click);
            // 
            // txtTempDoors
            // 
            this.txtTempDoors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTempDoors.Location = new System.Drawing.Point(215, 84);
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
            this.tabControl1.Size = new System.Drawing.Size(540, 535);
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
            this.tabPage2.Controls.Add(this.dgvEmail);
            this.tabPage2.Controls.Add(this.btnOTEmail);
            this.tabPage2.Controls.Add(this.lblOTDATE);
            this.tabPage2.Controls.Add(this.btnCommit);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.dgOther);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(532, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OVERTIME";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvEmail
            // 
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.AllowUserToDeleteRows = false;
            this.dgvEmail.AllowUserToResizeColumns = false;
            this.dgvEmail.AllowUserToResizeRows = false;
            this.dgvEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmail.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEmail.Location = new System.Drawing.Point(3, 26);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.RowHeadersVisible = false;
            this.dgvEmail.Size = new System.Drawing.Size(526, 14);
            this.dgvEmail.TabIndex = 23;
            this.dgvEmail.Visible = false;
            // 
            // btnOTEmail
            // 
            this.btnOTEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOTEmail.Location = new System.Drawing.Point(418, 26);
            this.btnOTEmail.Name = "btnOTEmail";
            this.btnOTEmail.Size = new System.Drawing.Size(108, 23);
            this.btnOTEmail.TabIndex = 22;
            this.btnOTEmail.Text = "Email";
            this.btnOTEmail.UseVisualStyleBackColor = true;
            this.btnOTEmail.Click += new System.EventHandler(this.btnOTEmail_Click);
            // 
            // lblOTDATE
            // 
            this.lblOTDATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOTDATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTDATE.Location = new System.Drawing.Point(6, 3);
            this.lblOTDATE.Name = "lblOTDATE";
            this.lblOTDATE.Size = new System.Drawing.Size(520, 20);
            this.lblOTDATE.TabIndex = 21;
            this.lblOTDATE.Text = "   ";
            this.lblOTDATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCommit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommit.Location = new System.Drawing.Point(187, 476);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(159, 27);
            this.btnCommit.TabIndex = 20;
            this.btnCommit.Text = "SAVE OVERTIME";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 428);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(520, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Other Department OverTime";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(520, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Programming OverTime";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgOther
            // 
            this.dgOther.AllowUserToAddRows = false;
            this.dgOther.AllowUserToDeleteRows = false;
            this.dgOther.AllowUserToResizeColumns = false;
            this.dgOther.AllowUserToResizeRows = false;
            this.dgOther.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOther.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOther.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgOther.Location = new System.Drawing.Point(6, 451);
            this.dgOther.Name = "dgOther";
            this.dgOther.RowHeadersVisible = false;
            this.dgOther.Size = new System.Drawing.Size(520, 19);
            this.dgOther.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(6, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(520, 370);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
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
            this.dgvOtherDept.Location = new System.Drawing.Point(785, 12);
            this.dgvOtherDept.Name = "dgvOtherDept";
            this.dgvOtherDept.RowHeadersVisible = false;
            this.dgvOtherDept.Size = new System.Drawing.Size(0, 10);
            this.dgvOtherDept.TabIndex = 12;
            this.dgvOtherDept.Visible = false;
            this.dgvOtherDept.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOtherDept_CellDoubleClick);
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(15, 72);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(418, 26);
            this.label.TabIndex = 31;
            this.label.Text = "View Programming or General Overtime";
            this.label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(215, 61);
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
            this.ClientSize = new System.Drawing.Size(554, 648);
            this.Controls.Add(this.dgvOtherDept);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSat)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgOther;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label lblOTDATE;
        private System.Windows.Forms.Button btnOTEmail;
        private System.Windows.Forms.DataGridView dgvEmail;
    }
}