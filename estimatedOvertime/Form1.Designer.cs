namespace estimatedOvertime
{
    partial class Form1
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
            this.btnGo = new System.Windows.Forms.Button();
            this.lblDoors = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblHours = new System.Windows.Forms.Label();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAvoidOT = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblOTdoors = new System.Windows.Forms.Label();
            this.lblOTHours = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOTTitle = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblNoOverTimeNeeded = new System.Windows.Forms.Label();
            this.lblOT = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(166, 78);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(121, 25);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Search ";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblDoors
            // 
            this.lblDoors.AutoSize = true;
            this.lblDoors.Location = new System.Drawing.Point(475, 124);
            this.lblDoors.Name = "lblDoors";
            this.lblDoors.Size = new System.Drawing.Size(35, 13);
            this.lblDoors.TabIndex = 1;
            this.lblDoors.Text = "label1";
            this.lblDoors.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(442, 143);
            this.dataGridView1.TabIndex = 2;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(475, 146);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "label1";
            this.lblHours.Visible = false;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(12, 52);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 4;
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(254, 52);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "To:";
            // 
            // btnAvoidOT
            // 
            this.btnAvoidOT.Enabled = false;
            this.btnAvoidOT.Location = new System.Drawing.Point(224, 264);
            this.btnAvoidOT.Name = "btnAvoidOT";
            this.btnAvoidOT.Size = new System.Drawing.Size(121, 25);
            this.btnAvoidOT.TabIndex = 7;
            this.btnAvoidOT.Text = "Avoid Over Time";
            this.btnAvoidOT.UseVisualStyleBackColor = true;
            this.btnAvoidOT.Click += new System.EventHandler(this.btnAvoidOT_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowDrop = true;
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 295);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(442, 143);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.Visible = false;
            // 
            // lblOTdoors
            // 
            this.lblOTdoors.AutoSize = true;
            this.lblOTdoors.Location = new System.Drawing.Point(475, 170);
            this.lblOTdoors.Name = "lblOTdoors";
            this.lblOTdoors.Size = new System.Drawing.Size(35, 13);
            this.lblOTdoors.TabIndex = 9;
            this.lblOTdoors.Text = "label1";
            this.lblOTdoors.Visible = false;
            // 
            // lblOTHours
            // 
            this.lblOTHours.AutoSize = true;
            this.lblOTHours.Location = new System.Drawing.Point(475, 345);
            this.lblOTHours.Name = "lblOTHours";
            this.lblOTHours.Size = new System.Drawing.Size(35, 13);
            this.lblOTHours.TabIndex = 10;
            this.lblOTHours.Text = "label1";
            this.lblOTHours.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(525, 90);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(138, 13);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "We assume 1 door per hour";
            this.lblTitle.Visible = false;
            // 
            // lblOTTitle
            // 
            this.lblOTTitle.AutoSize = true;
            this.lblOTTitle.Location = new System.Drawing.Point(525, 320);
            this.lblOTTitle.Name = "lblOTTitle";
            this.lblOTTitle.Size = new System.Drawing.Size(147, 13);
            this.lblOTTitle.TabIndex = 12;
            this.lblOTTitle.Text = "We assume 0.5 door per hour";
            this.lblOTTitle.Visible = false;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(833, 26);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(121, 25);
            this.btnRestart.TabIndex = 13;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblNoOverTimeNeeded
            // 
            this.lblNoOverTimeNeeded.AutoSize = true;
            this.lblNoOverTimeNeeded.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOverTimeNeeded.Location = new System.Drawing.Point(525, 202);
            this.lblNoOverTimeNeeded.Name = "lblNoOverTimeNeeded";
            this.lblNoOverTimeNeeded.Size = new System.Drawing.Size(197, 18);
            this.lblNoOverTimeNeeded.TabIndex = 14;
            this.lblNoOverTimeNeeded.Text = "NO OVERTIME NEEDED";
            this.lblNoOverTimeNeeded.Visible = false;
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOT.Location = new System.Drawing.Point(525, 404);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(197, 18);
            this.lblOT.TabIndex = 15;
            this.lblOT.Text = "NO OVERTIME NEEDED";
            this.lblOT.Visible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Location = new System.Drawing.Point(80, 264);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(121, 25);
            this.btnCalculate.TabIndex = 16;
            this.btnCalculate.Text = "Calculate Over Time";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 450);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblOT);
            this.Controls.Add(this.lblNoOverTimeNeeded);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblOTTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblOTHours);
            this.Controls.Add(this.lblOTdoors);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnAvoidOT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDoors);
            this.Controls.Add(this.btnGo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estimated Overtime";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblDoors;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAvoidOT;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblOTdoors;
        private System.Windows.Forms.Label lblOTHours;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOTTitle;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblNoOverTimeNeeded;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Button btnCalculate;
    }
}

