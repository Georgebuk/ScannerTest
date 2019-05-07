namespace ScannerTest
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
            this.btnFindHotel = new System.Windows.Forms.Button();
            this.lblHotelID = new System.Windows.Forms.Label();
            this.scannerControlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnScanQRCode = new System.Windows.Forms.Button();
            this.hotelNoBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnFindHotel
            // 
            this.btnFindHotel.Location = new System.Drawing.Point(15, 71);
            this.btnFindHotel.Name = "btnFindHotel";
            this.btnFindHotel.Size = new System.Drawing.Size(130, 23);
            this.btnFindHotel.TabIndex = 0;
            this.btnFindHotel.Text = "Get Hotel";
            this.btnFindHotel.UseVisualStyleBackColor = true;
            this.btnFindHotel.Click += new System.EventHandler(this.BtnFindHotel_Click);
            // 
            // lblHotelID
            // 
            this.lblHotelID.AutoSize = true;
            this.lblHotelID.Location = new System.Drawing.Point(12, 29);
            this.lblHotelID.Name = "lblHotelID";
            this.lblHotelID.Size = new System.Drawing.Size(77, 13);
            this.lblHotelID.TabIndex = 2;
            this.lblHotelID.Text = "Enter Hotel ID:";
            // 
            // scannerControlPanel
            // 
            this.scannerControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scannerControlPanel.Location = new System.Drawing.Point(226, 12);
            this.scannerControlPanel.Name = "scannerControlPanel";
            this.scannerControlPanel.Size = new System.Drawing.Size(552, 373);
            this.scannerControlPanel.TabIndex = 3;
            // 
            // BtnScanQRCode
            // 
            this.BtnScanQRCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnScanQRCode.Location = new System.Drawing.Point(3, 362);
            this.BtnScanQRCode.Name = "BtnScanQRCode";
            this.BtnScanQRCode.Size = new System.Drawing.Size(217, 23);
            this.BtnScanQRCode.TabIndex = 4;
            this.BtnScanQRCode.Text = "Scan";
            this.BtnScanQRCode.UseVisualStyleBackColor = true;
            this.BtnScanQRCode.Click += new System.EventHandler(this.BtnScanQRCode_Click);
            // 
            // hotelNoBox
            // 
            this.hotelNoBox.FormattingEnabled = true;
            this.hotelNoBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.hotelNoBox.Location = new System.Drawing.Point(15, 45);
            this.hotelNoBox.Name = "hotelNoBox";
            this.hotelNoBox.Size = new System.Drawing.Size(130, 21);
            this.hotelNoBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 397);
            this.Controls.Add(this.hotelNoBox);
            this.Controls.Add(this.BtnScanQRCode);
            this.Controls.Add(this.scannerControlPanel);
            this.Controls.Add(this.lblHotelID);
            this.Controls.Add(this.btnFindHotel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindHotel;
        private System.Windows.Forms.Label lblHotelID;
        private System.Windows.Forms.FlowLayoutPanel scannerControlPanel;
        private System.Windows.Forms.Button BtnScanQRCode;
        private System.Windows.Forms.ComboBox hotelNoBox;
    }
}

