using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelClassLibrary;

namespace ScannerTest
{
    public partial class Scanner : UserControl
    {
        private bool isScanned;
        private bool isAvailable;

        public Scanner()
        {
            InitializeComponent();
        }

        private void lblRoomLbl_Click(object sender, EventArgs e)
        {

        }

        private void Scanner_Load(object sender, EventArgs e)
        {

        }

        public int scannerID
        {
            get { return Convert.ToInt32(lblScannerID.Text); }
            set { lblScannerID.Text = value.ToString(); }
        }

        public string roomName
        {
            get { return lblRoomLbl.Text; }
            set { lblRoomName.Text = value; }
        }

        public Color connectedBoxColor
        {
            set { textBox1.BackColor = value; }
        }

        public string connectedBoxText
        {
            set { lblConnected.Text = value; }
        }

        private void ScannerControl_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Scanner_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);

        }

        public bool IsScanned {
            set
            {
                isScanned = value;
                if (value)
                {
                    connectedBoxColor = Color.Green;
                    connectedBoxText = "Open";
                }
                
            }
        }

        public bool IsAvailable
        {
            set
            {
                isAvailable = value;
                if(!value)
                {
                    connectedBoxColor = Color.DimGray;
                    connectedBoxText = "Unavailable";
                }
            }
        }
    }
}
