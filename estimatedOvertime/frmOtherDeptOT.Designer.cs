namespace estimatedOvertime
{
    partial class frmOtherDeptOT
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
            this.BtnExit = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgOverTime = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(45, 258);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(83, 23);
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "Cancel";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(168, 258);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(83, 23);
            this.btnCommit.TabIndex = 6;
            this.btnCommit.Text = "Add Overtime";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Insert OverTime for 20/20/2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgOverTime
            // 
            this.dgOverTime.AllowUserToAddRows = false;
            this.dgOverTime.AllowUserToDeleteRows = false;
            this.dgOverTime.AllowUserToResizeColumns = false;
            this.dgOverTime.AllowUserToResizeRows = false;
            this.dgOverTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOverTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOverTime.Location = new System.Drawing.Point(12, 25);
            this.dgOverTime.Name = "dgOverTime";
            this.dgOverTime.RowHeadersVisible = false;
            this.dgOverTime.Size = new System.Drawing.Size(288, 227);
            this.dgOverTime.TabIndex = 4;
            // 
            // frmOtherDeptOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 291);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgOverTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOtherDeptOT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOtherDeptOT";
            ((System.ComponentModel.ISupportInitialize)(this.dgOverTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgOverTime;
    }
}