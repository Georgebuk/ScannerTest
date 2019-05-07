using AForge.Video;
using AForge.Video.DirectShow;
using HotelClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace ScannerTest
{
    public partial class Form1 : Form
    {
        private IVideoSource videoSource;
        int frameCount;
        static HttpClient client = new HttpClient();
        Hotel selectedHotel;
       
        public Form1()
        {
            InitializeComponent();
            scannerControlPanel.BorderStyle = BorderStyle.FixedSingle;
            BtnScanQRCode.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private async void BtnFindHotel_Click(object sender, EventArgs e)
        {

            scannerControlPanel.Controls.Clear();
            selectedHotel = await HotelRestService.Instance.getRoomsForHotel(
                Convert.ToInt32(hotelNoBox.Text));
            foreach (Room r in selectedHotel.RoomsInHotel)
            {
                Scanner s = new Scanner
                {
                    roomName = r.RoomNumber.ToString()
                };
                if (!r.IsAvailable)
                    s.IsAvailable = false;
                scannerControlPanel.Controls.Add(s);
            }
            BtnScanQRCode.Enabled = true;

        }

        private void BtnScanQRCode_Click(object sender, EventArgs e)
        {
            using (var form = new ScannerPage())
            {
                form.ShowDialog();
                int roomID = form.FoundRoom;
                scannerControlPanel.Controls.Clear();
                foreach (Room r in selectedHotel.RoomsInHotel)
                {
                    Scanner s = new Scanner
                    {
                        roomName = r.RoomNumber.ToString()
                    };

                    if (!r.IsAvailable)
                        s.IsAvailable = false;

                    if (r.RoomID == roomID)
                        s.IsScanned = true;


                    scannerControlPanel.Controls.Add(s);
                }
            }
        }

    }
}
