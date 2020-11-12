namespace estimatedOvertime
{
    partial class frmOverTmeInput
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
            this.dgOverTime = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).BeginInit();
            this.SuspendLayout();
            // 
            // dgOverTime
            // 
            this.dgOverTime.AllowUserToAddRows = false;
            this.dgOverTime.AllowUserToDeleteRows = false;
            this.dgOverTime.AllowUserToResizeColumns = false;
            this.dgOverTime.AllowUserToResizeRows = false;
            this.dgOverTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOverTime.Location = new System.Drawing.Point(12, 27);
            this.dgOverTime.Name = "dgOverTime";
            this.dgOverTime.RowHeadersVisible = false;
            this.dgOverTime.Size = new System.Drawing.Size(288, 227);
            this.dgOverTime.TabIndex = 0;
            this.dgOverTime.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgOverTime_EditingControlShowing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Insert OverTime for 20/20/2020";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(168, 260);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(83, 23);
            this.btnCommit.TabIndex = 2;
            this.btnCommit.Text = "Add Overtime";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(45, 260);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(83, 23);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Cancel";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // frmOverTmeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 291);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgOverTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOverTmeInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Programming OverTime";
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOverTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button BtnExit;
    }
}