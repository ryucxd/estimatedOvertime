﻿namespace estimatedOvertime
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
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
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
            this.btnAvoidOT.Location = new System.Drawing.Point(166, 264);
            this.btnAvoidOT.Name = "btnAvoidOT";
            this.btnAvoidOT.Size = new System.Drawing.Size(121, 25);
            this.btnAvoidOT.TabIndex = 7;
            this.btnAvoidOT.Text = "Avoid Over Time";
            this.btnAvoidOT.UseVisualStyleBackColor = true;
            this.btnAvoidOT.Click += new System.EventHandler(this.btnAvoidOT_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 295);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(442, 143);
            this.dataGridView2.TabIndex = 8;
            // 
            // lblOTdoors
            // 
            this.lblOTdoors.AutoSize = true;
            this.lblOTdoors.Location = new System.Drawing.Point(475, 322);
            this.lblOTdoors.Name = "lblOTdoors";
            this.lblOTdoors.Size = new System.Drawing.Size(35, 13);
            this.lblOTdoors.TabIndex = 9;
            this.lblOTdoors.Text = "label1";
            // 
            // lblOTHours
            // 
            this.lblOTHours.AutoSize = true;
            this.lblOTHours.Location = new System.Drawing.Point(475, 345);
            this.lblOTHours.Name = "lblOTHours";
            this.lblOTHours.Size = new System.Drawing.Size(35, 13);
            this.lblOTHours.TabIndex = 10;
            this.lblOTHours.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 450);
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
    }
}

