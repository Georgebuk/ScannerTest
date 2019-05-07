namespace ScannerTest
{
    partial class Scanner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblConnected = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblScannerID = new System.Windows.Forms.Label();
            this.lblRoomLbl = new System.Windows.Forms.Label();
            this.lblScannerLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(88, 115);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(43, 13);
            this.lblConnected.TabIndex = 11;
            this.lblConnected.Text = "Locked";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Location = new System.Drawing.Point(52, 45);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(0, 13);
            this.lblRoomName.TabIndex = 10;
            // 
            // lblScannerID
            // 
            this.lblScannerID.AutoSize = true;
            this.lblScannerID.Location = new System.Drawing.Point(72, 13);
            this.lblScannerID.Name = "lblScannerID";
            this.lblScannerID.Size = new System.Drawing.Size(0, 13);
            this.lblScannerID.TabIndex = 9;
            // 
            // lblRoomLbl
            // 
            this.lblRoomLbl.AutoSize = true;
            this.lblRoomLbl.Location = new System.Drawing.Point(8, 45);
            this.lblRoomLbl.Name = "lblRoomLbl";
            this.lblRoomLbl.Size = new System.Drawing.Size(38, 13);
            this.lblRoomLbl.TabIndex = 8;
            this.lblRoomLbl.Text = "Room:";
            this.lblRoomLbl.Click += new System.EventHandler(this.lblRoomLbl_Click);
            // 
            // lblScannerLbl
            // 
            this.lblScannerLbl.AutoSize = true;
            this.lblScannerLbl.Location = new System.Drawing.Point(8, 13);
            this.lblScannerLbl.Name = "lblScannerLbl";
            this.lblScannerLbl.Size = new System.Drawing.Size(64, 13);
            this.lblScannerLbl.TabIndex = 7;
            this.lblScannerLbl.Text = "Scanner ID:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(47, 93);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 54);
            this.textBox1.TabIndex = 6;
            // 
            // Scanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.lblScannerID);
            this.Controls.Add(this.lblRoomLbl);
            this.Controls.Add(this.lblScannerLbl);
            this.Controls.Add(this.textBox1);
            this.Name = "Scanner";
            this.Size = new System.Drawing.Size(216, 173);
            this.Load += new System.EventHandler(this.Scanner_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Scanner_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblScannerID;
        private System.Windows.Forms.Label lblRoomLbl;
        private System.Windows.Forms.Label lblScannerLbl;
        private System.Windows.Forms.TextBox textBox1;
    }
}
